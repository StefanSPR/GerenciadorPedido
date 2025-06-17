using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Application.ViewModel.Create;
using GerenciadorPedido.Application.ViewModel.Update;
using GerenciadorPedido.Dominio;

namespace GerenciadorPedido.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {

        public MappingProfile()
        {
            MapProduto();
            MapCliente();
            MapPedido();
            MapItemPedido();
        }

        private void MapCliente()
        {
            CreateMap<ClienteDominio, ClienteModel>();
            CreateMap<ClienteModel, ClienteDominio>();
            CreateMap<DtoUpdCliente, ClienteModel>();
            CreateMap<DtoCrtCliente, ClienteModel>();
        }
        private void MapProduto()
        {
            CreateMap<DtoCrtProduto, ProdutoModel>();
            CreateMap<DtoUpdProduto, ProdutoModel>();
            CreateMap<ProdutoDominio, ProdutoModel>();
            CreateMap<ProdutoModel, ProdutoDominio>();
        }
        private void MapPedido()
        {
            CreateMap<PedidoDominio, PedidoModel>();
            CreateMap<PedidoModel, PedidoDominio>();
        }
        private void MapItemPedido()
        {
            CreateMap<ItemPedidoDominio, ItemPedidoModel>();
            CreateMap<ItemPedidoModel, ItemPedidoDominio>();

        }
    }
}
