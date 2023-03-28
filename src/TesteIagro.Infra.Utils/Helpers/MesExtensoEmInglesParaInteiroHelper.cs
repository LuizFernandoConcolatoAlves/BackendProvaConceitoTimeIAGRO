using TesteIagro.Infra.Utils.Resources;

namespace TesteIagro.Infra.Utils.Helpers
{
    public static class MesExtensoEmInglesParaInteiroHelper
    {
        public static int Converter(string mesEmExtenso)
        {
            switch (mesEmExtenso.ToLower())
            {
                case MesesResource.January:
                        return Constantes.Um;
                case MesesResource.February:
                        return Constantes.Dois;
                case MesesResource.March:
                        return Constantes.Tres;
                case MesesResource.April:
                        return Constantes.Quatro;
                case MesesResource.May:
                        return Constantes.Cinco;
                case MesesResource.June:
                        return Constantes.Seis;
                case MesesResource.July:
                        return Constantes.Sete;
                case MesesResource.August:
                        return Constantes.Oito;
                case MesesResource.September:
                        return Constantes.Nove;
                case MesesResource.October:
                        return Constantes.Dez;
                case MesesResource.November:
                        return Constantes.Onze;
                case MesesResource.December:
                        return Constantes.Doze;
                default:
                        return Constantes.Um;
            }
        }
    }
}
