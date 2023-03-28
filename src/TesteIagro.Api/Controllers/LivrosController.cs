using Microsoft.AspNetCore.Mvc;
using TesteIagro.Application.Books.Interfaces;
using TesteIagro.Domain.Books.Filtros;

namespace TesteIagro.Api.Controllers
{
    [Route("api/Livro")]
    [ApiController]
    public class LivrosController : Controller
    {
        /// <summary>
        /// Listagem de Livros
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="_bookService"></param>
        /// <returns></returns>
        [HttpGet("ObterLivros")]
        public IActionResult ObterLivros
        (
            [FromQuery] ListagemDeLivrosFiltro filtro,
            [FromServices] IBookService _bookService
        )
        {
            var livros = _bookService.ObterListagemDeLivros(filtro);

            return Ok(livros);
        }

        /// <summary>
        /// Método que calcula o valor do frete do Livro com base no Id do livro informado
        /// </summary>
        /// <param name="livroId"></param>
        /// <param name="_calculardorDeFreteDeLivroService"></param>
        /// <returns></returns>
        [HttpGet("CalcularValorDoFrete")]
        public IActionResult CalcularValorDoFrete
        (
            long livroId,
            [FromServices] ICalculardorDeFreteDeLivroService _calculardorDeFreteDeLivroService
        )
        {
            var livros = _calculardorDeFreteDeLivroService.CalcularValorDoFrete(livroId);

            return Ok(livros);
        }
    }
}
