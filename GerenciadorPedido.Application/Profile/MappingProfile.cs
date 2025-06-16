using GerenciadorPedido.Application.ViewModel;
using GerenciadorPedido.Dominio;

namespace GerenciadorPedido.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {

        public MappingProfile()
        {
            CreateMap<ProdutoDominio, ProdutoModel>();
            CreateMap<ProdutoModel, ProdutoDominio>();

            CreateMap<ClienteDominio, ClienteModel>();
            CreateMap<ClienteModel, ClienteDominio>();
        }
    }
}
