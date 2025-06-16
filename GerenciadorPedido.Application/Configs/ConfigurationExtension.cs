using GerenciadorPedido.Application.Interface;
using GerenciadorPedido.Application.Profile;
using GerenciadorPedido.Application.Service;
using GerenciadorPedido.Infra.Interface;
using GerenciadorPedido.Infra.Repositorio;
using GerenciadorPedido.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorPedido.Application.Configs
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddConfigurationsExtension(this IServiceCollection services)
        {

            return services
                .AddSingleton<Contexto>()
                .AddAutoMapper()
                .AddRepositorios()
                .AddServices(); 
        }

        private static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            return services
                .AddScoped<IClienteRepositorio, ClienteRepositorio>()
                .AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                        .AddScoped<IClienteService, ClienteService>()
                        .AddScoped<IProdutoService, ProdutoService>();
        }
        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
