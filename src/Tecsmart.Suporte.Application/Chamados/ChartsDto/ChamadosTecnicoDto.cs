using Abp.AutoMapper;
using System;

namespace Tecsmart.Suporte.Chamados.ChartsDto
{
    public class ChamadosTecnicoDto
    {
        public string ResponsavelFkName { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataAbertura { get; set; }

    }
}
