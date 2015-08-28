using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.ShoppingCart.Views.Francais;

namespace ATMTECH.ShoppingCart.Commerce.UserControls
{
    public partial class ListeCouleur : UserControl
    {
        public string Langue { get; set; }
        public IList<Couleur> Couleurs
        {
            get { return (IList<Couleur>)Session["Couleurs"]; }
            set
            {
                if (value != null)
                {
                    dataListListeImagesCouleur.DataSource = value;
                    dataListListeImagesCouleur.DataBind();
                }
            }
        }

    }



}