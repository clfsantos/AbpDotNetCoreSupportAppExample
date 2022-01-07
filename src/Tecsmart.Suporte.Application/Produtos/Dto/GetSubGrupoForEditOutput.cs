using System.Collections.Generic;

namespace Tecsmart.Suporte.Produtos.Dto
{
    public class GetSubGrupoForEditOutput
    {
        public GetSubGrupoForEditOutput()
        {
            Grupos = new List<int>();
        }
        public CreateOrEditSubGrupoDto SubGrupo { get; set; }
        public List<int> Grupos { get; set; }
    }
}
