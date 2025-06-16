using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Service.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio;

namespace GerenciadorPedido.Application.Service
{
    public class ProdutoService : ServiceBase<ProdutoModel, ProdutoDominio>, IProdutoService
    {
        public ProdutoService(IProdutoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
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
