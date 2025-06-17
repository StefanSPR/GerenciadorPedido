using GerenciadorPedido.Dominio.Base;
using GerenciadorPedido.Shared.Enum;

namespace GerenciadorPedido.Dominio
{
    public class PedidoDominio : BaseId
    {
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedidoEnum Status { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
