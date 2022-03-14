using BancoDeEspecies.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BancoDeEspecies.Application.Extensions
{
    public static class ServicesConfigurationExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServicesConfigurationExtensions));

            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<ILocalidadeService, LocalidadeService>();

            return services;
        }
    }
}
