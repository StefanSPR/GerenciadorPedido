using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;
using GerenciadorPedido.Dto.Cliente;
using GerenciadorPedido.Dto.ItemPedido;
using GerenciadorPedido.Dto.Pedido;
using GerenciadorPedido.Dto.Produto;

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
            CreateMap<UpdCliente, ClienteModel>();
            CreateMap<CrtCliente, ClienteModel>();
        }
        private void MapProduto()
        {
            CreateMap<CrtProduto, ProdutoModel>();
            CreateMap<UpdProduto, ProdutoModel>();
            CreateMap<ProdutoDominio, ProdutoModel>();
            CreateMap<ProdutoModel, ProdutoDominio>();
        }
        private void MapPedido()
        {
            CreateMap<CrtPedido, PedidoModel>();
            CreateMap<PedidoDominio, PedidoModel>();
            CreateMap<PedidoModel, PedidoDominio>();
        }
        private void MapItemPedido()
        {
            CreateMap<CrtItemPedido, ItemPedidoModel>();
            CreateMap<ItemPedidoDominio, ItemPedidoModel>();
            CreateMap<ItemPedidoModel, ItemPedidoDominio>();

        }
    }
}
