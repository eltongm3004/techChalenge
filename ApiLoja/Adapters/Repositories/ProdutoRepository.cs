using ApiLoja.Core.Entities;
using ApiLoja.Core.Interfaces;
using ApiLoja.Core.Requests;
using Dapper;
using System.Data;

namespace ApiLoja.Adapters.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProdutoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open(); // Open the connection if it's not already open
            }
        }

        public void AddProduto(CriarProdutoRequest produto)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var sql = @"INSERT INTO ""Produto"" (""Nome"", ""Categoria"", ""Preco"") VALUES (@Nome, @Categoria, @Preco)";
                    _dbConnection.Execute(sql, produto, transaction);
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

        public void UpdateProduto(UpdateProdutoRequest produto)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var sql = @"UPDATE ""Produto"" SET ""Nome"" = @Nome, ""Categoria"" = @Categoria, ""Preco"" = @Preco WHERE ""Id"" = @Id";
                    _dbConnection.Execute(sql, produto, transaction);
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

        public void DeleteProduto(int id)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var sql = @"DELETE FROM ""Produto"" WHERE ""Id"" = @Id";
                    _dbConnection.Execute(sql, new { Id = id }, transaction);
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

        public List<Produto> GetAllProdutos()
        {
            var sql = @"SELECT * FROM ""Produto""";
            return _dbConnection.Query<Produto>(sql).ToList();
        }
        public List<Produto> GetProdutosByCategoria(string categoria)
        {
            var sql = @"SELECT * FROM ""Produto"" WHERE ""Categoria"" = @Categoria";
            return _dbConnection.Query<Produto>(sql, new { Categoria = categoria }).ToList();
        }
    }
}