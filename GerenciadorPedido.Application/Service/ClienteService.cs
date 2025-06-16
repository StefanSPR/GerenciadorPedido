using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Service.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio;

namespace GerenciadorPedido.Application.Service
{
    public class ClienteService : ServiceBase<ClienteModel, ClienteDominio>, IClienteService
    {
        public ClienteService(IClienteRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        protected override void Validar(ClienteModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarAtualizar(ClienteModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarInserir(ClienteModel model)
        {
            //throw new NotImplementedException();
        }
    }
}
