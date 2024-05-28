using ApiLoja.Core.Entities;
using ApiLoja.Core.Enums;
using ApiLoja.Core.Interfaces;
using ApiLoja.Core.Requests;
using ApiLoja.Core.Responses;
using Dapper;
using Microsoft.OpenApi.Extensions;
using System.Data;

namespace ApiLoja.Adapters.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnection _dbConnection;

        public PedidoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
        }

        public void AddPedido(FazerPedidoRequest pedido, int idClienteLogado, StatusPedido status)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var sql = @"INSERT INTO ""Pedido"" (""Data"",""IdCliente"", ""Status"") VALUES (@Data,@IdCliente,@Status) Returning ""Id"";";
                    var pedidoId = _dbConnection.Query<int>(sql, new { Data = pedido.Data, IdCliente = idClienteLogado, Status = status.ToString() }, transaction).Single();

                    foreach (var produto in pedido.IdProdutoXQtde)
                    {
                        var produtoSql = @"INSERT INTO ""PedidoProduto"" (""PedidoId"", ""ProdutoId"", ""Quantidade"") VALUES (@PedidoId, @ProdutoId, @Quantidade)";
                        _dbConnection.Execute(produtoSql, new { PedidoId = pedidoId, ProdutoId = produto.Key, Quantidade = produto.Value }, transaction);
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw; // Re-throw the exception to be handled elsewhere
                }
                finally
                {
                    _dbConnection.Dispose();
                }
            }
        }

        public void FakeCheckOut(int idPedido)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var sql = @"UPDATE ""Pedido"" SET ""Status"" = @Status WHERE ""Id"" = @Id";
                    StatusPedido status = StatusPedido.Pago;

                    _dbConnection.Execute(sql, new {Status = status.ToString(), Id = idPedido}, transaction);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw; // Re-throw the exception to be handled elsewhere
                }
                finally
                {
                    _dbConnection.Dispose();
                }
            }
        }

        public IEnumerable<GetAllPedidosResponse> GetAllPedidos()
        {
            var sql = @"SELECT pp.""PedidoId"", pd.""Status"", pd.""Data"", pd.""IdCliente"",pp.""ProdutoId"",p.""Categoria"",p.""Nome"",p.""Preco"", pp.""Quantidade"" FROM ""PedidoProduto"" pp
                            INNER JOIN ""Produto"" p ON pp.""ProdutoId"" = p.""Id""
                            INNER JOIN ""Pedido"" pd ON pp.""PedidoId"" = pd.""Id""";
            var pedidoDictionary = new Dictionary<int, GetAllPedidosResponse>();

            var result = _dbConnection.Query<GetAllPedidosResponse, ProdutoDto, GetAllPedidosResponse>(
                sql,
                (pedido, produto) =>
                {
                    if (!pedidoDictionary.TryGetValue(pedido.PedidoId, out var pedidoEntry))
                    {
                        pedidoEntry = new GetAllPedidosResponse
                        {
                            PedidoId = pedido.PedidoId,
                            Data = pedido.Data,
                            IdCliente = pedido.IdCliente,
                            Status = pedido.Status
                        };

                        pedidoDictionary.Add(pedido.PedidoId, pedidoEntry);
                    }

                    pedidoEntry.Produtos.Add(produto);
                    return pedidoEntry;
                },
                splitOn: "ProdutoId");

            return pedidoDictionary.Values;
        }
    }
}
