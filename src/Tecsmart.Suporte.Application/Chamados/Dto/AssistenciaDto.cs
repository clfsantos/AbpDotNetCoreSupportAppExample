using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class AssistenciaDto : EntityDto<int>
    {
        public int ChamadoId { get; set; }
        public DateTime ChamadoFkDataAbertura { get; set; }
        public int ChamadoFkStatus { get; set; }
        public int EquipamentoId { get; set; }
        public string EquipamentoFkClienteFkNomeFantasia { get; set; }
        public string EquipamentoFkDescricao { get; set; }
        public string EquipamentoFkModeloFKFabricanteFkNome { get; set; }
        public string EquipamentoFkModeloFkDescricao { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaProblemaFkDescricao { get; set; }
        public string DadosAdicionais { get; set; }
        public string DiasManutencao
        {
            get
            {
                return DateTime.Now.Date.Subtract(ChamadoFkDataAbertura.Date).Days.ToString();
            }
        }
    }
}
