using Newtonsoft.Json;
using TesteIagro.Infra.Utils.Helpers;

namespace TesteIagro.Domain.Specifications.Dtos
{
    public class SpecificationJsonDto
    {
        [JsonProperty("originally published")]
        [JsonConverter(typeof(ConversorDeDataJsonHelper))]
        public DateTime OriginallyPublished { get; private set; }

        [JsonProperty("author")]
        public string? Author { get; private set; }

        [JsonProperty("page count")]
        public int PageCount { get; private set; }

        [JsonProperty("illustrator")]
        [JsonConverter(typeof(ConversorDeAtributoUnicoParaListaHelper<string>))]
        public List<string> Illustrator { get; private set; } = new List<string>();

        [JsonProperty("genres")]
        [JsonConverter(typeof(ConversorDeAtributoUnicoParaListaHelper<string>))]
        public List<string> Genres { get; private set; } = new List<string>();
    }
}
