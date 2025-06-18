using Dapper;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio.Base;
using GerenciadorPedido.Shared.Enum;

namespace GerenciadorPedido.Infra.Repositorio
{
    public class PedidoRepositorio : RepositoryBase<PedidoDominio>, IPedidoRepositorio
    {
        public PedidoRepositorio(Contexto contexo) : base(contexo)
        {
        }

        protected override string TableName => "Pedido";

        public override int Insert(PedidoDominio entity)
        {
            return _contexo.Connection.QuerySingle<int>($@"INSERT INTO {TableName} (ClienteId, ValorTotal)
                    VALUES (@ClienteId, @ValorTotal)
                    SELECT @@Identity", new
            {
                ClienteId = entity.ClienteId,
                ValorTotal = entity.ValorTotal,
            });
        }

        public IEnumerable<PedidoDominio> GetByStatusECliente(StatusPedidoEnum? status, int? clienteId)
        {
            return _contexo.Connection.Query<PedidoDominio>($@"SELECT [Id],[ClienteId],[ValorTotal],[PedidoSatus],[DataCadastro]
                    FROM {TableName} 
                    WHERE ([PedidoSatus] = @PedidoStatus OR @PedidoStatus IS NULL) 
                    AND  (ClienteId = @ClienteId OR @ClienteId IS NULL) ", new { PedidoStatus = status, ClienteId = clienteId }).ToList();
        }

        public override void Update(PedidoDominio entity)
        {
            _contexo.Connection.Execute($@"UPDATE {TableName} SET ValorTotal = @ValorTotal, Satus = @Status, ClienteId = @ClienteId WHERE Id = @Id", 
                new { entity.ValorTotal, entity.PedidoStatus, entity.Id, entity.ClienteId });
        }
    }
}
