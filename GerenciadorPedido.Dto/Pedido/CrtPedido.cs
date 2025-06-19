using GerenciadorPedido.Dto.ItemPedido;

namespace GerenciadorPedido.Dto.Pedido
{
    public class CrtPedido
    {

        public int ClienteId { get; set; }
        public IEnumerable<CrtItemPedido>? ItensPedido { get; set; }
    }
}
