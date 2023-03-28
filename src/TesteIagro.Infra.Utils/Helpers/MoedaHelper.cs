using System.Globalization;

namespace TesteIagro.Infra.Utils.Helpers
{
    public static class MoedaHelper
    {
        public static string RetornarValorEmFormatoDeMoeda(decimal valor)
        {
            return valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}
