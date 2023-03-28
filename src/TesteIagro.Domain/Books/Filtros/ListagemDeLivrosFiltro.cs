using TesteIagro.Domain._Base.Filtros;

namespace TesteIagro.Domain.Books.Filtros
{
    public class ListagemDeLivrosFiltro : BaseFiltroOrdenacao
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public DateTime? DataDePublicacao { get; set; }
        public string? Autor { get; set; }
        public int? QuantidadeDePaginas { get; set; }
        public string? Ilustrador { get; set; }
        public string? Genero { get; set; }
    }
}
