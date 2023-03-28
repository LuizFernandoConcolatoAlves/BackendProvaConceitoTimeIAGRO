using Bogus;
using TesteIagro.Common.Tests.Builders.Fakers;
using TesteIagro.Domain.Specifications.Dtos;
using TesteIagro.Infra.Utils.Helpers;

namespace TesteIagro.Common.Tests.Builders.Specifications
{
    public class SpecificationDtoBuilder
    {
        private string? _dataDePublicacao { get; set; }
        private string? _autor { get; set; }
        private int _quantidadeDePaginas { get; set; }
        private List<string> _ilustradores { get; set; }
        private List<string> _generos { get; set; }
        private static Faker _faker;

        public static SpecificationDtoBuilder Novo()
        {
            _faker = FakerBuilder.Novo().Build();

            var builder = new SpecificationDtoBuilder
            {
                _dataDePublicacao = DataHelper.FormatarData(DateTime.Now),
                _autor = _faker.Random.String2(length: Constantes.Vinte),
                _quantidadeDePaginas = _faker.Random.Int(min: Constantes.Um, max: Constantes.Cem),
                _ilustradores = new List<string> { _faker.Random.String2(length: Constantes.Vinte) },
                _generos = new List<string> { _faker.Random.String2(length: Constantes.Vinte) }
            };

            return builder;
        }

        public SpecificationDtoBuilder ComDataDePublicacao(DateTime data)
        {
            _dataDePublicacao = DataHelper.FormatarData(data);
            return this;
        }

        public SpecificationDtoBuilder ComAutor(string? autor)
        {
            _autor = autor;
            return this;
        }

        public SpecificationDtoBuilder ComQuantidadeDePaginas(int quantidadeDePaginas)
        {
            _quantidadeDePaginas = quantidadeDePaginas;
            return this;
        }

        public SpecificationDtoBuilder ComIlustradores(List<string> ilustradores)
        {
            _ilustradores = ilustradores;
            return this;
        }

        public SpecificationDtoBuilder ComGeneros(List<string> generos)
        {
            _generos = generos;
            return this;
        }

        public SpecificationDtoBuilder AdicionarIlustrador(string ilustrador)
        {
            if (_ilustradores == null)
                _ilustradores = new List<string>();

            _ilustradores.Add(ilustrador);
            return this;
        }

        public SpecificationDtoBuilder AdicionarGenero(string genero)
        {
            if (_generos == null)
                _generos = new List<string>();

            _generos.Add(genero);
            return this;
        }

        public SpecificationDto Build()
        {
            return new SpecificationDto(_dataDePublicacao, _autor, _quantidadeDePaginas, _ilustradores, _generos);
        }
    }
}
