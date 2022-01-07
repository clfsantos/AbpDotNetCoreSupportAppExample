using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Clientes.Dto
{
    public class ClienteViewDto : EntityDto<int>
    {
        public string CpfCnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public bool IsClienteMensalista { get; set; }
        public bool IsClienteBloqueado { get; set; }
        public long? NumeroERP { get; set; }
        public string Email { get; set; }
        public string EnderecoRua { get; set; }
        public int? EnderecoNumero { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoCep { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string CelularRh { get; set; }
        public string EmailRh { get; set; }
        public DateTime? DataUpdateEmailOrCel { get; set; }
        public string ClienteObs { get; set; }
    }
}
