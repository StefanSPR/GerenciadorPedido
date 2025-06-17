using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Service.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;

namespace GerenciadorPedido.Application.Service
{
    public class ClienteService : ServiceBase<ClienteModel, ClienteDominio>, IClienteService
    {
        private readonly IClienteRepositorio _repositorioCliente;
        public ClienteService(IClienteRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
            _repositorioCliente = repositorio;
        }

        public IEnumerable<ClienteModel> SelecionarPorNomeEmail(string descricao)
        {
            IEnumerable<ClienteDominio> dominios = _repositorioCliente.GetByNameEmail(descricao);
            return _mapper.Map< IEnumerable<ClienteModel>>(dominios);
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
