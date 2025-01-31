using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Natalia.Autorizacao.Domain.Requests.Usuarios;
using Natalia.Autorizacao.Infrastructure.Services;
using System.Data;

namespace Natalia.Autorizacao.Infrastructure.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string _connectionString { get; set; }

        public UsuarioRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Autenticacao");
        }

        public async Task<bool> VerificarUsuario(string cpf, string nome)
        {
            var query = StringExtensions.ObterQuery("");

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var resultado = dbConnection.QueryFirstOrDefaultAsync(query,
                new
                {
                    cpf,
                    nome
                });
                return await resultado > 0;
            }
        }
    }
}
