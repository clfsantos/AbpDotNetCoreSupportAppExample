using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class CreateOrEditAnexoDto : EntityDto<int?>, IShouldNormalize
    {
        [Required]
        public int ChamadoId { get; set; }

        [Required]
        public DateTime DataUpload { get; set; }

        public string Nome { get; set; }

        public string Caminho { get; set; }

        public long? UsuarioId { get; set; }

        public void Normalize()
        {
            DataUpload = DateTime.Now;
        }
    }
}
