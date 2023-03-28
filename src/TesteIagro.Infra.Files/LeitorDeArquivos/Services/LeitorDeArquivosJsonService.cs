using Newtonsoft.Json;
using TesteIagro.Infra.Files.LeitorDeArquivos.Interfaces;

namespace TesteIagro.Infra.Files.LeitorDeArquivos.Services
{
    public class LeitorDeArquivosJsonService<T> : ILeitorDeArquivosJsonService<T>
    {
        public List<T> LerArquivoJsonEConverterParaEntidade(string pathArquivo)
        {
            try
            {
                var jsonEmTexto = File.ReadAllText(pathArquivo);

                var reader = new JsonTextReader(new StringReader(jsonEmTexto));

                var serializer = new JsonSerializer();

                return serializer.Deserialize<List<T>>(reader);
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
    }
}
