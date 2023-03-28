using AutoMapper;
using TesteIagro.Domain._Base.Enum;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Domain.Books.Filtros;
using TesteIagro.Infra.Data.Books.Interfaces;
using TesteIagro.Infra.Files.LeitorDeArquivos.Interfaces;
using TesteIagro.Infra.Utils.Helpers;
using TesteIagro.Infra.Utils.Resources;

namespace TesteIagro.Infra.Data.Books.Consultas
{
    public class BookConsulta : IBookConsulta
    {
        private readonly ILeitorDeArquivosJsonService<BookJsonDto> _leitorDeArquivosJsonService;
        private readonly IMapper _mapper;

        public BookConsulta
        (
            ILeitorDeArquivosJsonService<BookJsonDto> leitorDeArquivosJsonService,
            IMapper mapper
        )
        {
            _leitorDeArquivosJsonService = leitorDeArquivosJsonService;
            _mapper = mapper;
        }

        public List<BookDto> ObterLivros(ListagemDeLivrosFiltro filtro)
        {
            var booksJsonDto = RetonarListaDeLivrosDoArquivoJson();

            if (booksJsonDto == null || !booksJsonDto.Any())
                return new List<BookDto>();

            return FiltrarEOrdenarDados(filtro, booksJsonDto);
        }

        public BookDto? ObterLivroPorId(long id)
        {
            var booksJsonDto = RetonarListaDeLivrosDoArquivoJson();

            if (booksJsonDto == null || !booksJsonDto.Any())
                return null;

            var livro = booksJsonDto.FirstOrDefault(b => b.Id == id);

            if (livro == null)
                return null;

            return _mapper.Map<BookDto>(livro);
        }

        private List<BookJsonDto> RetonarListaDeLivrosDoArquivoJson() => _leitorDeArquivosJsonService.LerArquivoJsonEConverterParaEntidade(PathArquivosResource.PathBookJson);

        private List<BookDto> FiltrarEOrdenarDados(ListagemDeLivrosFiltro filtro, List<BookJsonDto> booksJsonDto)
        {
            var registrosFiltrados = booksJsonDto
                .Where(b => (filtro.Id == Constantes.Zero || b.Id == filtro.Id) &&
                            (string.IsNullOrWhiteSpace(filtro.Nome) || StringHelper.VerificarSeParteDaStringExisteSemAcentoEFormato(b.Name, filtro.Nome)) &&
                            (!filtro.Preco.HasValue || b.Price == filtro.Preco) &&
                            (!filtro.DataDePublicacao.HasValue || b.Specifications?.OriginallyPublished == filtro.DataDePublicacao) &&
                            (string.IsNullOrWhiteSpace(filtro.Autor) || StringHelper.VerificarSeParteDaStringExisteSemAcentoEFormato(b.Specifications.Author, filtro.Autor)) &&
                            (!filtro.QuantidadeDePaginas.HasValue || b.Specifications?.PageCount == filtro.QuantidadeDePaginas) &&
                            (string.IsNullOrWhiteSpace(filtro.Ilustrador) || StringHelper.VerificarSeParteDaStringExisteEmListaSemAcentoEFormato(b.Specifications.Illustrator, filtro.Ilustrador)) &&
                            (string.IsNullOrWhiteSpace(filtro.Genero) || StringHelper.VerificarSeParteDaStringExisteEmListaSemAcentoEFormato(b.Specifications.Genres, filtro.Genero)));

            var registrosFiltradosEOrdenados = OrdenarDados(registrosFiltrados, filtro.Ordenacao);

            return _mapper.Map<List<BookDto>>(registrosFiltradosEOrdenados);
        }

        private List<BookJsonDto> OrdenarDados(IEnumerable<BookJsonDto> registrosFiltrados, OrdenacaoEnum Ordenacao)
        {
            if (Ordenacao == OrdenacaoEnum.ASC)
                return registrosFiltrados.OrderBy(r => r.Price).ToList();
            else
                return registrosFiltrados.OrderByDescending(r => r.Price).ToList();
        }
    }
}
