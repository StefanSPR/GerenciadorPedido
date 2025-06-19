using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface.Base;

namespace GerenciadorPedido.Infra.Interface
{
    public interface IItemPedidoRepositorio : IRepositoryBase<ItemPedidoDominio>
    {
        IEnumerable<ItemPedidoDominio> GetByPedidoId(int id);
    }
}
