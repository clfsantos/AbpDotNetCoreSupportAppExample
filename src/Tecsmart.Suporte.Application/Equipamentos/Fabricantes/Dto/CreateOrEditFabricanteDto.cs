using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Equipamentos.Fabricantes.Dto
{
    public class CreateOrEditFabricanteDto : EntityDto<int?>
    {
        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

    }
}
