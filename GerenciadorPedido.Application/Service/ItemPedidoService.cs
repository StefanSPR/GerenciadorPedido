using AutoMapper;
using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Service.Base;
using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Infra.Interface;

namespace GerenciadorPedido.Application.Service
{
    public class ItemPedidoService : ServiceBase<ItemPedidoModel, ItemPedidoDominio>, IItemPedidoService
    {
        public ItemPedidoService(IItemPedidoRepositorio repositorio, IMapper mapper) : base(repositorio, mapper)
        {
        }

        protected override void Validar(ItemPedidoModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarAtualizar(ItemPedidoModel model)
        {
            //throw new NotImplementedException();
        }

        protected override void ValidarInserir(ItemPedidoModel model)
        {
            //throw new NotImplementedException();
        }
    }
}
