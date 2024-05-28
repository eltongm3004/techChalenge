using ApiLoja.Core.Entities;
using ApiLoja.Core.Interfaces;
using ApiLoja.Core.Responses;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace ApiLoja.Adapters.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ClienteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open(); // Open the connection if it's not already open
            }
        }

        public void AddCliente(CadastroClienteRequest cliente)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    //var sql = @"INSERT INTO Endereco (CEP, Logradouro, Numero, Bairro, Cidade) 
                    //    OUTPUT INSERTED.Id
                    //    VALUES (@CEP, @Logradouro, @Numero, @Bairro, @Cidade)"; 
                    var sql = @"INSERT INTO ""Endereco"" (""CEP"", ""Logradouro"", ""Numero"", ""Bairro"", ""Cidade"")
                                VALUES (@CEP, @Logradouro, @Numero, @Bairro, @Cidade)
                                RETURNING ""Id"";";
                    int enderecoId = _dbConnection.ExecuteScalar<int>(sql, cliente.Endereco, transaction);

                    sql = @"INSERT INTO ""Cliente"" (""CPF"", ""Nome"", ""Login"", ""Senha"", ""IdEndereco"") VALUES (@CPF, @Nome, @Login, @Senha, @IdEndereco)";
                    _dbConnection.Execute(sql, new
                    {
                        CPF = cliente.CPF,
                        Nome = cliente.Nome,
                        Login = cliente.Login,
                        Senha = cliente.Senha,
                        IdEndereco = enderecoId
                    }, transaction);

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

        public GetClienteResponse GetClienteByCpf(string cpf)
        {
            //var sql = @"SELECT c.Nome, c.Login, e.CEP, e.Logradouro, e.Numero, e.Bairro, e.Cidade
            //            FROM Cliente c
            //            INNER JOIN Endereco e ON c.IdEndereco = e.Id
            //            WHERE c.CPF = @CPF";
            var sql = @"SELECT c.""Nome"", c.""Login"", e.""CEP"", e.""Logradouro"", e.""Numero"", e.""Bairro"", e.""Cidade""
                        FROM public.""Cliente"" c
                        INNER JOIN public.""Endereco"" e ON c.""IdEndereco"" = e.""Id""
                        WHERE c.""CPF"" = @CPF";

            return _dbConnection.Query<GetClienteResponse, Endereco, GetClienteResponse>(
                        sql,
                        (cliente, endereco) =>
                        {
                            cliente.Endereco = endereco;
                            return cliente;
                        },
                        new { CPF = cpf },
                        splitOn: "CEP" // Split the result on these columns to indicate the start of a new "Endereco" object
                    )
                    .FirstOrDefault();
        }
    }
}
