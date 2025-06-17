using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio.Base;

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
            throw new NotImplementedException();
        }

        public override void Update(PedidoDominio entity)
        {
            throw new NotImplementedException();
        }
    }
}
