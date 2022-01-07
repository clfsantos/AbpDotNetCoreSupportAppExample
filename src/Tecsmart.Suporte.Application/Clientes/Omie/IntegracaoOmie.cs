using System;
using System.Collections.Generic;

namespace Tecsmart.Suporte.Clientes.Omie
{
    public class Resposta
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<ClienteCadastro> clientes_cadastro { get; set; }
    }

    public class TagsCliente
    {
        public string tag { get; set; }
    }

    public class ClienteCadastro
    {
        private string _cep { get; set; }
        private string _cnpj_cpf { get; set; }

        public string bairro { get; set; }
        public string cep 
        { 
            get
            {
                return _cep?.Replace("/", "").Replace("-","");
            } 
            set
            {
                _cep = value;
            }
        }
        public string cidade_ibge { get; set; }
        public string cnpj_cpf
        {
            get
            {
                return _cnpj_cpf.Replace(".", "").Replace("/", "").Replace("-", "");
            }
            set
            {
                _cnpj_cpf = value;
            }
        }
        public long codigo_cliente_omie { get; set; }
        public string complemento { get; set; }
        public string contato { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string endereco_numero { get; set; }
        public string nome_fantasia { get; set; }
        public string razao_social { get; set; }
        public List<TagsCliente> tags { get; set; }
        public string telefone1_ddd { get; set; }
        public string telefone1_numero { get; set; }
        public string telefone1
        {
            get
            {
                string telefone = telefone1_ddd + telefone1_numero;
                telefone = telefone.Replace("-", "").Replace(".", "").Replace(" ", "").Replace("(", "").Replace(")", "").TrimStart(new Char[] { '0' });
                if (telefone.Length == 8 || telefone.Length == 9)
                {
                    telefone = "45" + telefone;
                }
                if (telefone.Length > 11)
                {
                    telefone = "45";
                }
                return telefone;
            }
        }

    }
}
