using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Constant;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using Image = System.Web.UI.WebControls.Image;

namespace ATMTECH.ShoppingCart.Commerce.UserControls
{
    public partial class ListeCouleur : UserControl
    {
        public string Langue { get; set; }
        public IList<Stock> Stocks
        {
            get { return (IList<Stock>)Session["Stocks"]; }
            set
            {
                if (value != null)
                {
                    dataListListeImagesCouleur.DataSource = value;
                    dataListListeImagesCouleur.DataBind();
                }
            }
        }

        protected void dataListListeImagesCouleurOnItemDataBound(object sender, DataListItemEventArgs e)
        {
            Stock stock = (Stock)e.Item.DataItem;
            Image image = e.Item.FindControl("imageCouleur") as Image;
            if (image != null)
            {
                image.AlternateText = Langue == LocalizationLanguage.FRENCH ? stock.ColorFrench : stock.ColorEnglish;
            }
        }

        //public IList<Couleur> ListeCouleurs
        //{
        //    get { return (IList<Couleur>)Session["ListeCouleurs"]; }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            //placeHolderCouleur.Controls.Clear();    
        //            //string html = string.Empty;
        //            //foreach (Couleur couleur in value)
        //            //{
        //            //    html += Langue == LocalizationLanguage.FRENCH
        //            //                ? "<div title='" + couleur.Francais + "' style='margin-top:4px; background-color:" +
        //            //                  couleur.EquivalentWeb +
        //            //                  ";border:solid 1px gray; width: 20px; height:20px;float: left;margin-left: 5px;'>&nbsp;</div>"
        //            //                : "<div title='" + couleur.Anglais + "' style='margin-top:4px;background-color:" +
        //            //                  couleur.EquivalentWeb +
        //            //                  ";border:solid 1px gray; width: 20px; height:20px;float: left;margin-left: 5px;'>&nbsp;</div>";
        //            //}

        //            //html += "<div style='clear: both;'></div>";
        //            //Literal literal = new Literal { Text = html };
        //            //placeHolderCouleur.Controls.Add(literal);
        //        }
        //    }
        //}
    }



}