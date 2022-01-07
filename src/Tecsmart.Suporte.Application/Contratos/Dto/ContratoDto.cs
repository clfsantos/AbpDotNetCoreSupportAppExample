using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Contratos.Dto
{
    public class ContratoDto : EntityDto<long>
    {
        public virtual long NumeroERP { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int Quantidade { get; set; }
    }
}
