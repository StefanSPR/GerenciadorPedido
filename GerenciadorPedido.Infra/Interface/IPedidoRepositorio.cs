using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface.Base;
using GerenciadorPedido.Shared.Enum;

namespace GerenciadorPedido.Infra.Interface
{
    public interface IPedidoRepositorio : IRepositoryBase<PedidoDominio>
    {
        IEnumerable<PedidoDominio> GetByStatusECliente(StatusPedidoEnum? status, int? clienteId);
    }
}
