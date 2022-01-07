using System.Collections.Generic;

namespace Tecsmart.Suporte.Produtos.Dto
{
    public class GetGrupoForEditOutput
    {
        public GetGrupoForEditOutput()
        {
            Produtos = new List<int>();
        }
        public CreateOrEditGrupoDto Grupo { get; set; }
        public List<int> Produtos { get; set; }
    }
}
