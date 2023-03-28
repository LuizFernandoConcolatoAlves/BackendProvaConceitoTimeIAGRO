using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TesteIagro.Infra.Utils.Helpers
{
    public class ConversorDeDataJsonHelper : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dataString = JToken.Load(reader).Value<string>();

            var ano = ObterAno(dataString);
            var mes = ObterMes(dataString);
            var dia = ObterDia(dataString);

            return new DateTime(ano, mes, dia);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private int ObterAno(string? dataString)
        {
            if (dataString == null)
                return Constantes.Um;

            var ano = dataString.Split(',')[1]?.Trim();

            if (ano == null)
                return Constantes.Um;

            return Convert.ToInt32(ano);
        }

        private int ObterMes(string? dataString)
        {
            if (dataString == null)
                return Constantes.Um;

            var mesEmExtenso = dataString.Split(' ')[0]?.Trim();

            if (mesEmExtenso == null)
                return Constantes.Um;

            return MesExtensoEmInglesParaInteiroHelper.Converter(mesEmExtenso);
        }

        private int ObterDia(string? dataString)
        {
            if (dataString == null)
                return Constantes.Um;

            var dataSemMes = dataString.Split(' ')[1]?.Trim();
            var dia = dataSemMes?.Split(',')[0]?.Trim();

            if (dia == null)
                return Constantes.Um;

            return Convert.ToInt32(dia);
        }
    }
}
