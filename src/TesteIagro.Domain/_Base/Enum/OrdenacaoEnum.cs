using System.ComponentModel;
using TesteIagro.Infra.Utils.Resources;

namespace TesteIagro.Domain._Base.Enum
{
    public enum OrdenacaoEnum
    {
        [Description(TesteIagroResource.ASC)]
        ASC = 1,
        [Description(TesteIagroResource.DESC)]
        DESC = 2
    }
}
