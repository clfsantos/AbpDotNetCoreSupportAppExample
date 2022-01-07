using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Crachas.Type
{
    public enum TipoCartaoType
    {
        [Display(Name = "PVC")]
        Pvc = 1,
        [Display(Name = "ISO")]
        Iso = 2,
        [Display(Name = "MIFARE")]
        Mifare = 3
    }

    public enum TipoImpressaoType
    {
        [Display(Name = "FRENTE")]
        Frente = 1,
        [Display(Name = "FRENTE E VERSO")]
        FrenteVerso = 2
    }

    public enum StatusType
    {
        [Display(Name = "Pendente")]
        Pendente = 1,
        [Display(Name = "Em Andamento")]
        Andamento = 2,
        [Display(Name = "Concluído")]
        Concluido = 3
    }

    public enum ImpressoraType
    {
        [Display(Name = "EPSON L1300 UV")]
        EpsonL1300 = 1,
        [Display(Name = "DATACARD SP35 PLUS")]
        DATACARD = 2,
        [Display(Name = "PH3250FX")]
        PH3250FX = 3
    }
}
