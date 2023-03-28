using Microsoft.Extensions.DependencyInjection;
using TesteIagro.Application.Books.Interfaces;
using TesteIagro.Application.Books.Services;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Infra.Files.LeitorDeArquivos.Interfaces;
using TesteIagro.Infra.Files.LeitorDeArquivos.Services;

namespace TesteIagro.Infra.IoC.Providers
{
    public static class ServicesProvider
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped(typeof(ILeitorDeArquivosJsonService<BookJsonDto>), typeof(LeitorDeArquivosJsonService<BookJsonDto>));
            services.AddScoped(typeof(IBookService), typeof(BookService));
            services.AddScoped(typeof(ICalculardorDeFreteDeLivroService), typeof(CalculardorDeFreteDeLivroService)); 
        }
    }
}
