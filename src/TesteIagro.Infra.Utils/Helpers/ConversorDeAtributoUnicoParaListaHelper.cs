using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TesteIagro.Infra.Utils.Helpers
{
    public class ConversorDeAtributoUnicoParaListaHelper<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var campo = JToken.Load(reader);

            if (campo.Type == JTokenType.Array)
            {
                return campo.ToObject<List<T>>();
            }

            return new List<T> { campo.ToObject<T>() };
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
