using Newtonsoft.Json;
using TesteIagro.Domain.Specifications.Dtos;

namespace TesteIagro.Domain.Books.Dtos
{
    public class BookJsonDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("specifications")]
        public SpecificationJsonDto? Specifications { get; private set; }
    }
}
