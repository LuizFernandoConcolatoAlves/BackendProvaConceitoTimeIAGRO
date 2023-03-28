using Microsoft.Extensions.DependencyInjection;
using TesteIagro.Infra.IoC.AutoMapper;
using TesteIagro.Infra.IoC.Providers;

namespace TesteIagro.Infra.IoC
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ConsultaProvider.Add(services);
            ServicesProvider.Add(services);

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
