using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Views.Francais;

namespace ATMTECH.ShoppingCart.Commerce.UserControls
{
    public partial class ListeCouleur : UserControl
    {
        public string Langue { get; set; }
        public IList<Couleur> ListeCouleurs
        {
            get { return (IList<Couleur>)Session["ListeCouleurs"]; }
            set
            {
                if (value != null)
                {
                    string html = string.Empty;
                    foreach (Couleur couleur in value)
                    {
                        html += Langue == LocalizationLanguage.FRENCH
                                    ? "<div title='" + couleur.Francais + "' style='background-color:" +
                                      couleur.EquivalentWeb +
                                      ";border:solid 1px gray; width: 20px; height:20px;float: left;margin-left: 5px;'>&nbsp;</div>"
                                    : "<div title='" + couleur.Anglais + "' style='background-color:" +
                                      couleur.EquivalentWeb +
                                      ";border:solid 1px gray; width: 20px; height:20px;float: left;margin-left: 5px;'>&nbsp;</div>";
                    }

                    html += "<div style='clear: both;'></div>";
                    Literal literal = new Literal { Text = html };
                    placeHolderCouleur.Controls.Add(literal);
                }
            }
        }
    }



}