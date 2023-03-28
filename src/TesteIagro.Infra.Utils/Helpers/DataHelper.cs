namespace TesteIagro.Infra.Utils.Helpers
{
    public static class DataHelper
    {
        public static string FormatarData(DateTime data)
        {
            return data.ToString("dd/MM/yyyy");
        }
    }
}
