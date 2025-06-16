using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;


namespace GerenciadorPedido.Infra
{
    public class Contexto : IDisposable
    {
        public IDbConnection Connection { get; }
        private readonly IConfiguration _configuration;

        //public Contexto(string connection)
        //{
        //    Connection = new SqlConnection(connection);
        //    Connection.Open();

        //}
        public Contexto(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        //public Contexo(string connectionString)
        //{
        //    Connection = new SqlConnection(connectionString);
        //    Connection.Open();
        //}

        public void Dispose() => Connection?.Dispose();
    }
}
