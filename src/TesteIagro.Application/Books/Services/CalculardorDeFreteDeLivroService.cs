using TesteIagro.Application.Books.Interfaces;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Infra.Data.Books.Interfaces;
using TesteIagro.Infra.Utils.Helpers;
using TesteIagro.Infra.Utils.Resources;

namespace TesteIagro.Application.Books.Services
{
    public class CalculardorDeFreteDeLivroService : ICalculardorDeFreteDeLivroService
    {
        private readonly IBookConsulta _bookConsulta;

        public CalculardorDeFreteDeLivroService(IBookConsulta bookConsulta)
        {
            _bookConsulta = bookConsulta;
        }

        public string CalcularValorDoFrete(long livroId)
        {
            var livro = _bookConsulta.ObterLivroPorId(livroId);

            return RetornarValorDoFreteCalculado(livro);
        }

        private string RetornarValorDoFreteCalculado(BookDto? livro)
        {
            if (livro == null)
                return TesteIagroResource.MsgNaoFoiPossivelLocalizarOLivroInformado;

            var valorDoFrete = livro.Preco + (livro.Preco * Constantes.Vinte / Constantes.Cem);

            return TesteIagroResource.FormatarResource(TesteIagroResource.MsgValorDoFrete, livro.Nome, MoedaHelper.RetornarValorEmFormatoDeMoeda(valorDoFrete));
        }
    }
}
