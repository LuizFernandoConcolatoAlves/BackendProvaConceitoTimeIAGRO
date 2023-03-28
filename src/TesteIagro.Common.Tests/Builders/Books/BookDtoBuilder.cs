using Bogus;
using TesteIagro.Common.Tests.Builders.Fakers;
using TesteIagro.Common.Tests.Builders.Specifications;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Domain.Specifications.Dtos;
using TesteIagro.Infra.Utils.Helpers;

namespace TesteIagro.Common.Tests.Builders.Books
{
    public class BookDtoBuilder
    {
        private long _id;
        private string? _nome;
        private decimal _preco;
        private SpecificationDto? _especificacoes;
        private static Faker _faker;

        public static BookDtoBuilder Novo()
        {
            _faker = FakerBuilder.Novo().Build();

            var builder = new BookDtoBuilder
            {
                _id = _faker.Random.Long(min: Constantes.Um, max: Constantes.Cem),
                _nome = _faker.Random.String2(length: Constantes.Vinte),
                _especificacoes = SpecificationDtoBuilder.Novo().Build(),
                _preco = _faker.Random.Decimal(min: Constantes.Zero, max: Constantes.Cem)
            };

            return builder;
        }

        public BookDtoBuilder ComId(long id)
        {
            _id = id;
            return this;
        }

        public BookDtoBuilder ComNome(string? nome)
        {
            _nome = nome;
            return this;
        }

        public BookDtoBuilder ComPreco(decimal preco)
        {
            _preco = preco;
            return this;
        }

        public BookDtoBuilder ComEspecificacao(SpecificationDto? especificacao)
        {
            _especificacoes = especificacao;
            return this;
        }

        public BookDto Build()
        {
            return new BookDto(_id, _nome, _preco, _especificacoes);
        }
    }
}
