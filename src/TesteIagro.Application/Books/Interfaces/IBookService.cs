using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Domain.Books.Filtros;

namespace TesteIagro.Application.Books.Interfaces
{
    public interface IBookService
    {
        List<BookDto> ObterListagemDeLivros(ListagemDeLivrosFiltro filtro);
    }
}
