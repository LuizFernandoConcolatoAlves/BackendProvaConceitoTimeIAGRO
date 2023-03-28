namespace TesteIagro.Infra.Utils.Resources
{
    public static class TesteIagroResource
    {
        public const string ASC = "ASC";
        public const string DESC = "DESC";
        public const string MsgNaoFoiPossivelLocalizarOLivroInformado = "Não foi possível localizar o livro informado.";
        public const string MsgValorDoFrete = "O valor do frete para o livro: {0}, será de {1}.";

        public static string FormatarResource(string mensagemPrincipal, params string[] parametros)
        {
            return string.Format(mensagemPrincipal, parametros);
        }
    }
}
