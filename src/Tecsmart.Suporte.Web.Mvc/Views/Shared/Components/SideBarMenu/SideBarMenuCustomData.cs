namespace Tecsmart.Suporte.Web.Views.Shared.Components.SideBarMenu
{
    public class SideBarMenuCustomData
    {
        public SideBarMenuCustomData(string classe, int qtd)
        {
            Classe = classe;
            Qtd = qtd;
        }
        public string Classe { get; set; }
        public int Qtd { get; set; }
    }
}
