using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Service.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;

namespace GerenciadorPedido.Application.Service
{
    public class ProdutoService : ServiceBase<ProdutoModel, ProdutoDominio>, IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoService(IProdutoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _produtoRepositorio = repositorio;
        }

        public IEnumerable<ProdutoModel> SelecionarPorNome(string nome)
        {

            IEnumerable<ProdutoDominio> dominios = _produtoRepositorio.GetByName(nome);
            return _mapper.Map<IEnumerable<ProdutoModel>>(dominios);
        }

        protected override void Validar(ProdutoModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarAtualizar(ProdutoModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarInserir(ProdutoModel model)
        {
            //throw new NotImplementedException();
        }
    }
}
