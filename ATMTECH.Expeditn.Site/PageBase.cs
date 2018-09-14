using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Site.Vues;

namespace ATMTECH.Expeditn.Site
{
    public class PageBase : Page
    {
        public Site PageMaitre => Page.Master as Site;
        public ExpeditionVue ExpeditionVue => new ExpeditionVue();
        public UtilisateurVue UtilisateurVue => new UtilisateurVue();
        public RecherchePrixVue RecherchePrixVue => new RecherchePrixVue();

        public void MettreBlancTextBox()
        {
            GetAllControls().Where(x => x is TextBox).ToList().ForEach(z=>(z as TextBox).Text = string.Empty) ;
        }

        public IEnumerable<Control> GetAllControls()
        {
            var allControls = new List<Control>();
            var currentControls = new Queue<Control>();
            currentControls.Enqueue(Page);

            while (currentControls.Count > 0)
            {
                var c = currentControls.Dequeue();
                if (!allControls.Contains(c))
                {
                    allControls.Add(c);
                    if (c.Controls != null && c.Controls.Count > 0)
                    {
                        foreach (Control e in c.Controls)
                        {
                            currentControls.Enqueue(e);
                        }
                    }
                }
            }
            return allControls;
        }

    }
}