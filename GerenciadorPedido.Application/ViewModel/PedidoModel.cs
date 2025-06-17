using GerenciadorPedido.Application.ViewModel.Base;
using GerenciadorPedido.Shared.Enum;

namespace GerenciadorPedido.Application.ViewModel
{
    public class PedidoModel : BaseModelId
    {
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedidoEnum Status { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
