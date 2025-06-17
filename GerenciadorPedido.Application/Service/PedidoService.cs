using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Service.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;

namespace GerenciadorPedido.Application.Service
{
    public class PedidoService : ServiceBase<PedidoModel, PedidoDominio>, IPedidoService
    {
        public PedidoService(IPedidoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        protected override void Validar(PedidoModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarAtualizar(PedidoModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarInserir(PedidoModel model)
        {
            //throw new NotImplementedException();
        }
    }
}
