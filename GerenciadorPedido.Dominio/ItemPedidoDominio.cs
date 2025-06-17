using GerenciadorPedido.Dominio.Base;

namespace GerenciadorPedido.Dominio
{
    public class ItemPedidoDominio : BaseId
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
