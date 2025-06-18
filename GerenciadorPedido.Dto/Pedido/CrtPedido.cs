using GerenciadorPedido.Dto.ItemPedido;

namespace GerenciadorPedido.Dto.Pedido
{
    public class CrtPedido
    {
        public CrtPedido(IEnumerable<CrtItemPedido> itensPedido)
        {
            ItensPedido = itensPedido;
        }

        public int? Id { get; set; }
        public int ClienteId { get; set; }
        public IEnumerable<CrtItemPedido> ItensPedido { get; set; }
    }
}
