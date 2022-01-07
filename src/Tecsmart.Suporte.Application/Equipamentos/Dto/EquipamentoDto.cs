using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Equipamentos.Dto
{
    public class EquipamentoDto : EntityDto<int>
    {
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public string ClienteFkNomeFantasia { get; set; }
        public string ClienteFkRazaoSocial { get; set; }
        public string ClienteFkCpfCnpj { get; set; }
        public string ModeloFkDescricao { get; set; }
        public bool TesteOk { get; set; }
        public bool Inativo { get; set; }
        public DateTime? DataInclusao { get; set; }
    }
}
