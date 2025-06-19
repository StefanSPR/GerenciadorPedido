using GerenciadorPedido.Application.ViewModel.Base;

namespace GerenciadorPedido.Application.ViewModel
{
    public class ProdutoModel : BaseModelId
    {
        public ProdutoModel(string nome, string descricao, decimal preco, int quantidadeEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
