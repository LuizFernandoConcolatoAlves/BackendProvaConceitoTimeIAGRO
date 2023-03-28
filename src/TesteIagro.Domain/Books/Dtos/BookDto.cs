using TesteIagro.Domain.Specifications.Dtos;

namespace TesteIagro.Domain.Books.Dtos
{
    public class BookDto
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public SpecificationDto? Especificacao { get; private set; }

        protected BookDto() { }

        public BookDto(long id, string? nome, decimal preco, SpecificationDto? especificacao)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Especificacao = especificacao;
        }
    }
}
