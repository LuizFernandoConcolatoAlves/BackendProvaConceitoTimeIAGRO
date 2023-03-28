using TesteIagro.Application.Books.Interfaces;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Domain.Books.Filtros;
using TesteIagro.Infra.Data.Books.Interfaces;

namespace TesteIagro.Application.Books.Services
{
    public class BookService : IBookService
    {
        private readonly IBookConsulta _bookConsulta;

        public BookService
        (
            IBookConsulta bookConsulta
        )
        {
            _bookConsulta = bookConsulta;
        }

        public List<BookDto> ObterListagemDeLivros(ListagemDeLivrosFiltro filtro)
        {
            return _bookConsulta.ObterLivros(filtro);
        }
    }
}
