using GerenciadorPedido.Dominio.Base;

namespace GerenciadorPedido.Dominio
{
    public class ProdutoDominio : BaseId
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
