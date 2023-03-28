using TesteIagro.Infra.Utils.Extensions;

namespace TesteIagro.Infra.Utils.Helpers
{
    public static class StringHelper
    {
        public static bool VerificarSeParteDaStringExisteSemAcentoEFormato(string valor, string valorAComparar)
        {
            valor = valor.RemoverAcentuacao().ToLower();
            valorAComparar = valorAComparar.RemoverAcentuacao().ToLower();

            return valor.Contains(valorAComparar);
        }

        public static bool VerificarSeParteDaStringExisteEmListaSemAcentoEFormato(List<string> valores, string valorAComparar)
        {
            valorAComparar = valorAComparar.RemoverAcentuacao().ToLower();

            return valores.Select(v => v.RemoverAcentuacao().ToLower())
                          .Any(v => v.Contains(valorAComparar));
        }
    }
}
