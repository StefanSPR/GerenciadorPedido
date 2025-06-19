using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Service.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Shared.Enum;

namespace GerenciadorPedido.Application.Service
{
    public class PedidoService : ServiceBase<PedidoModel, PedidoDominio>, IPedidoService
    {
        #region Construtor
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IItemPedidoRepositorio _itemPedidoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        public PedidoService(IPedidoRepositorio repositorio, IMapper mapper, IClienteRepositorio clienteRepositorio, IItemPedidoRepositorio itemPedidoRepositorio, IProdutoRepositorio produtpRepositorio) : base(repositorio, mapper)
        {
            _pedidoRepositorio = repositorio;
            _clienteRepositorio = clienteRepositorio;
            _itemPedidoRepositorio = itemPedidoRepositorio;
            _produtoRepositorio = produtpRepositorio;
        }
        #endregion
        #region Public
        public override int Inserir(PedidoModel create)
        {
            Validar(create);
            ValidarInserir(create);
            create.ValorTotal = create?.ItensPedido?.Select(x => x.Quantidade * x.PrecoUnitario).Sum() ?? 0m;
            var dominio = _mapper.Map<PedidoDominio>(create);

            int idPedido = _pedidoRepositorio.Insert(dominio);

            var itensPedido = _mapper.Map<IEnumerable<ItemPedidoDominio>>(create.ItensPedido);
            foreach (var item in itensPedido)
            {
                item.PedidoId = idPedido;
                _itemPedidoRepositorio.Insert(item);
            }

            return idPedido;
        }

        public IEnumerable<PedidoModel> SelecionarPorStatusECliente(StatusPedidoEnum? status, int? clienteId)
        {
            var pedidos = _pedidoRepositorio.GetByStatusECliente(status, clienteId);
            var ret = _mapper.Map<IEnumerable<PedidoModel>>(pedidos).ToList();
            ret.ForEach(item =>
            {
                item.Cliente = _mapper.Map<ClienteModel?>(_clienteRepositorio.GetById(item.ClienteId));
            });
            return ret;
        }
        public override PedidoModel ObterPorId(int id)
        {
            var model = base.ObterPorId(id);
            model.ItensPedido = _mapper.Map<List<ItemPedidoModel>>( _itemPedidoRepositorio.GetByPedidoId(model.Id));
            foreach (var item in model.ItensPedido)
            {
                item.Produto = _mapper.Map<ProdutoModel>(_produtoRepositorio.GetById(item.ProdutoId));
            }
            return model;
        }

        public void Avancar(int id)
        {
            var pedido = _repositorio.GetById(id);
            if (pedido == null) throw new ArgumentException("Pedido Nulo");
            pedido.AvancarStatus(); 
            _pedidoRepositorio.Update(pedido);
        }
        #endregion

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
