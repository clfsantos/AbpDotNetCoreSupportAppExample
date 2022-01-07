using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;

namespace Tecsmart.Suporte.Clientes.Dto
{
    public class CreateOrEditClienteDto : EntityDto<int?>
    {
        public long? NumeroERP { get; set; }

        [DisplayName("CNPJ / CPF")]
        public string CpfCnpj { get; set; }

        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [DisplayName("Bloquear Cliente")]
        public bool IsClienteBloqueado { get; set; }

        [DisplayName("Cidade")]
        public int CidadeId { get; set; }

        [DisplayName("Cidade")]
        public string CidadeFkNome { get; set; }

        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DisplayName("Rua")]
        public string EnderecoRua { get; set; }

        [DisplayName("Número")]
        public int? EnderecoNumero { get; set; }

        [DisplayName("Bairro")]
        public string EnderecoBairro { get; set; }

        [DisplayName("Complemento")]
        public string EnderecoComplemento { get; set; }

        [DisplayName("CEP")]
        public string EnderecoCep { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("Contato")]
        public string Contato { get; set; }

        [DisplayName("Celular do RH")]
        public string CelularRh { get; set; }

        [DisplayName("E-Mail do RH")]
        public string EmailRh { get; set; }

        [DisplayName("Última Atualização Manual")]
        public DateTime? DataUpdateEmailOrCel { get; set; }

        [DisplayName("Observações do Cliente")]
        public string ClienteObs { get; set; }
    }
}
