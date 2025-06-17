using GerenciadorPedido.Application.Interface.Base;
using GerenciadorPedido.Application.ViewModel;

namespace GerenciadorPedido.Application.Interface
{
    public interface IProdutoService : IServiceBase<ProdutoModel>
    {
        IEnumerable<ProdutoModel> SelecionarPorNome(string nome);
    }
}
