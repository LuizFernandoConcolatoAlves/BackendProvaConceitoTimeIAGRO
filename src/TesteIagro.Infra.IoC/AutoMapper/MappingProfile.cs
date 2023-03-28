using AutoMapper;
using TesteIagro.Domain.Books.Dtos;
using TesteIagro.Domain.Specifications.Dtos;

namespace TesteIagro.Infra.IoC.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookJsonDto, BookDto>()
                .ForMember(dtoDestino => dtoDestino.Nome, dtoOrigem => dtoOrigem.MapFrom(e => e.Name))
                .ForMember(dtoDestino => dtoDestino.Preco, dtoOrigem => dtoOrigem.MapFrom(e => e.Price))
                .ForMember(dtoDestino => dtoDestino.Especificacao, dtoOrigem => dtoOrigem.MapFrom(e => e.Specifications));

            CreateMap<SpecificationJsonDto, SpecificationDto>()
                .ForMember(dtoDestino => dtoDestino.DataDePublicacao, dtoOrigem => dtoOrigem.MapFrom(e => e.OriginallyPublished.ToString("dd/MM/yyyy")))
                .ForMember(dtoDestino => dtoDestino.Autor, dtoOrigem => dtoOrigem.MapFrom(e => e.Author))
                .ForMember(dtoDestino => dtoDestino.QuantidadeDePaginas, dtoOrigem => dtoOrigem.MapFrom(e => e.PageCount))
                .ForMember(dtoDestino => dtoDestino.Ilustradores, dtoOrigem => dtoOrigem.MapFrom(e => e.Illustrator))
                .ForMember(dtoDestino => dtoDestino.Generos, dtoOrigem => dtoOrigem.MapFrom(e => e.Genres));
        }
    }
}
