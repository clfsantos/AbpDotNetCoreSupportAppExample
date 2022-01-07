using System.Collections.Generic;

namespace Tecsmart.Suporte.Clientes.Omie.Contratos
{
    public class RespostaContrato
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<ContratoCadastro> contratoCadastro { get; set; }
    }

    public class ContratoCadastro
    {
        public Cabecalho cabecalho { get; set; }
        public List<ItensContrato> itensContrato { get; set; }
    }

    public class Cabecalho
    {
        public long nCodCli { get; set; }
    }

    public class ItensContrato
    {
        public ItemCabecalho itemCabecalho { get; set; }
        public ItemDescrServ itemDescrServ { get; set; }
    }

    public class ItemCabecalho
    {
        public long codItem { get; set; }
        public int quant { get; set; }
    }

    public class ItemDescrServ
    {
        public string descrCompleta { get; set; }
    }

}
