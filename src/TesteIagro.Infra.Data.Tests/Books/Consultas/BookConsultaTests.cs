using AutoMapper;
using Bogus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteIagro.Common.Tests.Builders.Fakers;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Infra.Data.Books.Consultas;
using TesteIagro.Infra.Files.LeitorDeArquivos.Interfaces;
using Xunit;

namespace TesteIagro.Infra.Data.Tests.Books.Consultas
{
    public class BookConsultaTests
    {
        private readonly Faker _faker;
        private readonly Mock<ILeitorDeArquivosJsonService<BookJsonDto>> _leitorDeArquivosJsonServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BookConsulta _bookConsulta;

        public BookConsultaTests()
        {
            _faker = FakerBuilder.Novo().Build();

            _leitorDeArquivosJsonServiceMock = new Mock<ILeitorDeArquivosJsonService<BookJsonDto>>();
            _mapperMock = new Mock<IMapper>();

            _bookConsulta = new BookConsulta(_leitorDeArquivosJsonServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void DeveRetornarDadosFiltradosEOrdenados()
        {

            _bookConsulta.ObterLivros();
        }
    }
}
