using GerenciadorPedido.Application.ViewModel.Base;
using GerenciadorPedido.Shared.Enum;
using GerenciadorPedido.Shared;

namespace GerenciadorPedido.Application.ViewModel
{
    public class PedidoModel : BaseModelId
    {
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedidoEnum PedidoStatus { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DataCadastroDesc { get => DataCadastro.ToString("dd/MM/yyyy"); }

        public IEnumerable<ItemPedidoModel>? ItensPedido { get; set; }
        public ClienteModel? Cliente { get; set; }
        public string? StatusDesc { get => PedidoStatus.GetEnumDisplayName(); }
    }
}
