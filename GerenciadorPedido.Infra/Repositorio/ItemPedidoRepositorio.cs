using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio.Base;

namespace GerenciadorPedido.Infra.Repositorio
{
    public class ItemPedidoRepositorio : RepositoryBase<ItemPedidoDominio>, IItemPedidoRepositorio
    {
        public ItemPedidoRepositorio(Contexto contexo) : base(contexo)
        {
        }

        protected override string TableName => "ItemPedido";

        public override int Insert(ItemPedidoDominio entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ItemPedidoDominio entity)
        {
            throw new NotImplementedException();
        }
    }
}
