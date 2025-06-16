using Dapper;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio.Base;

namespace GerenciadorPedido.Infra.Repositorio
{
    public class ClienteRepositorio : RepositoryBase<ClienteDominio>, IClienteRepositorio
    {
        public ClienteRepositorio(Contexto contexo) : base(contexo)
        {
        }

        protected override string TableName => "CLIENTE";

        public override int Insert(ClienteDominio entity)
        {
            string cmd = @"INSERT INTO [Cliente] ([Nome], [Email], [Telefone])
                VALUES
                (@Nome, @Email, @Telefone)
                select @@Identity";
            return _contexo.Connection.Query<int>(cmd, new { entity.Nome, entity.Email, entity.Telefone }).First();
        }

        public override void Update(ClienteDominio entity)
        {
            string cmd = @"UPDATE [Cliente] SET [Nome] = @Nome, [Email] = Email, [Telefone] = @Telefone
                WHERE Id = @Id";
            _contexo.Connection.Execute(cmd, new { entity.Id,entity.Nome, entity.Email, entity.Telefone });
        }
    }
}
