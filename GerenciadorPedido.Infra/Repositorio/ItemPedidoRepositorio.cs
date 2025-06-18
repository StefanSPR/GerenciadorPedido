using Dapper;
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

            return _contexo.Connection.QuerySingle<int>(@"INSERT INTO ItemPedido (PedidoId, ProdutoId, Quantidade, PrecoUnitario)
        VALUES (@PedidoId, @ProdutoId, @Quantidade, @PrecoUnitario)

        SELECT @@Identity", new
            {
                PedidoId = entity.PedidoId,
                ProdutoId = entity.ProdutoId,
                Quantidade = entity.Quantidade,
                PrecoUnitario = entity.PrecoUnitario
            });
        }

        public override void Update(ItemPedidoDominio entity)
        {
            throw new NotImplementedException();
        }
    }
}
