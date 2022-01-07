using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Crachas.Dto
{
    public class CrachaInfoDto
    {
        public int TotalPedido { get; set; }
        public int? TotalPerdido { get; set; }
        public int? TotalImpresso { get; set; }
        public double PorcentagemPerdido {
            get
            {
                if (TotalPerdido.HasValue && TotalImpresso.HasValue) {
                    return Math.Round(((double)TotalPerdido / (double)TotalImpresso) * 100, 2);
                } else
                {
                    return 0;
                }
                 
            } 
        }

        public int Pendentes { 
            get
            {
                if(TotalImpresso.HasValue)
                {
                    TotalImpresso = TotalImpresso;
                } else
                {
                    TotalImpresso = 0;
                }
                return TotalPedido - (int)TotalImpresso;
            }
        }

    }
}
