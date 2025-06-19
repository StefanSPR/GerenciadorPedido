using GerenciadorPedido.Application.Interface.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Shared.Enum;

namespace GerenciadorPedido.Application.Interface
{
    public interface IPedidoService : IServiceBase<PedidoModel>
    {
        void Avancar(int id);
        IEnumerable<PedidoModel> SelecionarPorStatusECliente(StatusPedidoEnum? status, int? clienteId);
    }
}
