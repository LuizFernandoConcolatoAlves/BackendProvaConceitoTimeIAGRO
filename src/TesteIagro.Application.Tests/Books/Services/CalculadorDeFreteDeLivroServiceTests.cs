using Bogus;
using Moq;
using TesteIagro.Application.Books.Services;
using TesteIagro.Common.Tests.Builders.Books;
using TesteIagro.Common.Tests.Builders.Fakers;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Infra.Data.Books.Interfaces;
using TesteIagro.Infra.Utils.Helpers;
using TesteIagro.Infra.Utils.Resources;
using Xunit;

namespace TesteIagro.Application.Tests.Books.Services
{
    public class CalculadorDeFreteDeLivroServiceTests
    {
        private readonly Faker _faker;
        private readonly Mock<IBookConsulta> _bookConsultaMock;
        private readonly CalculardorDeFreteDeLivroService _calculardorDeFreteDeLivroService;

        private readonly long _idValido;
        private readonly long _idInvalido;

        public CalculadorDeFreteDeLivroServiceTests()
        {
            _faker = FakerBuilder.Novo().Build();
            _bookConsultaMock = new Mock<IBookConsulta>();
            _calculardorDeFreteDeLivroService = new CalculardorDeFreteDeLivroService(_bookConsultaMock.Object);

            _idValido = _faker.Random.Long(min: 1, max: 100);
            _idInvalido = _faker.Random.Long(min: 101, max: 200);
        }


        [Fact]
        public void DeveCalcularValorDoFreteCorreto()
        {
            var bookDto = MontarCenario();
            var valorDoFreteCorreto = ValorCorretoDoFrete(bookDto.Nome, bookDto.Preco);

            var resultado = _calculardorDeFreteDeLivroService.CalcularValorDoFrete(_idValido);

            Assert.Equal(valorDoFreteCorreto, resultado);
        }

        [Fact]
        public void DeveRetornarMensagemDeLivroNaoEncontrado()
        {
             MontarCenario();
            var valorDoFreteCorreto = TesteIagroResource.MsgNaoFoiPossivelLocalizarOLivroInformado;

            var resultado = _calculardorDeFreteDeLivroService.CalcularValorDoFrete(_idInvalido);

            Assert.Equal(valorDoFreteCorreto, resultado);
        }

        private string ValorCorretoDoFrete(string nomeDoLivro, decimal valorDoLivro)
        {
            var valorDoFrete = valorDoLivro + (valorDoLivro * Constantes.Vinte / Constantes.Cem);
            return TesteIagroResource.FormatarResource(TesteIagroResource.MsgValorDoFrete, nomeDoLivro, MoedaHelper.RetornarValorEmFormatoDeMoeda(valorDoFrete));
        }

        private BookDto MontarCenario()
        {
            var bookDto = BookDtoBuilder
                .Novo()
                .ComId(_idValido)
                .Build();

            _bookConsultaMock
                .Setup(s => s.ObterLivroPorId(bookDto.Id))
                .Returns(bookDto);

            return bookDto;
        }
    }
}
