using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Equipamentos.Fabricantes.Dto
{
    public class CreateOrEditFabricanteDto : EntityDto<int?>
    {
        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Nome { get; set; }

    }
}
