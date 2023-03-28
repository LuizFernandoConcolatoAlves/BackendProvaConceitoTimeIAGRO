using Microsoft.Extensions.DependencyInjection;
using TesteIagro.Infra.Data.Books.Consultas;
using TesteIagro.Infra.Data.Books.Interfaces;

namespace TesteIagro.Infra.IoC.Providers
{
    public static class ConsultaProvider
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped(typeof(IBookConsulta), typeof(BookConsulta));
        }
    }
}
