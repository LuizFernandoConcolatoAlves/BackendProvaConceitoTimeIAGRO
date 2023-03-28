namespace TesteIagro.Domain.Specifications.Dtos
{
    public class SpecificationDto
    {
        public string? DataDePublicacao { get; set; }
        public string? Autor { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public List<string> Ilustradores { get; set; } = new List<string>();
        public List<string> Generos { get; set; } = new List<string>();

        protected SpecificationDto() { }

        public SpecificationDto(string? dataDePublicacao, string? autor, int quantidadeDePaginas, List<string> ilustradores, List<string> generos)
        {
            DataDePublicacao = dataDePublicacao;
            Autor = autor;
            QuantidadeDePaginas = quantidadeDePaginas;
            Ilustradores = ilustradores;
            Generos = generos;
        }
    }
}
