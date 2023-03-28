using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Domain.Books.Filtros;

namespace TesteIagro.Infra.Data.Books.Interfaces
{
    public interface IBookConsulta
    {
        List<BookDto> ObterLivros(ListagemDeLivrosFiltro filtro);
        BookDto? ObterLivroPorId(long id);
    }
}
