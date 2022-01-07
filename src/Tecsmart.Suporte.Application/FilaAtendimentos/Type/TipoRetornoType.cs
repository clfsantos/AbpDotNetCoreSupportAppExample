using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.FilaAtendimentos.Type
{
    public enum TipoRetornoType
    {
        [Display(Name = "Tecsmart")]
        Tecsmart = 1,
        [Display(Name = "Cliente")]
        Cliente = 2,
    }

}
