namespace TesteIagro.Infra.Files.LeitorDeArquivos.Interfaces
{
    public interface ILeitorDeArquivosJsonService<T>
    {
        List<T> LerArquivoJsonEConverterParaEntidade(string pathArquivo);
    }
}
