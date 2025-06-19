using GerenciadorPedido.Dominio.Base;
using GerenciadorPedido.Shared.Enum;

namespace GerenciadorPedido.Dominio
{
    public class PedidoDominio : BaseId
    {
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedidoEnum PedidoStatus { get; set; }
        public DateTime DataCadastro { get; set; }

        public void AvancarStatus()
        {
            switch (PedidoStatus)
            {
                case StatusPedidoEnum.Novo:
                    PedidoStatus = StatusPedidoEnum.Processando;
                    break;
                case StatusPedidoEnum.Processando:
                    PedidoStatus = StatusPedidoEnum.Finalizado;
                    break;
            }
        }
    }
}
