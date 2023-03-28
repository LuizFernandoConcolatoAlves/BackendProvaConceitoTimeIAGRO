using System.Globalization;
using System.Text;

namespace TesteIagro.Infra.Utils.Extensions
{
    public static class StringExtension
    {
        public static string RemoverAcentuacao(this string texto)
        {
            return new string(texto
                .Normalize(NormalizationForm.FormD)
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
