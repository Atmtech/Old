using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Default1 : PageBase<AccueilPresenter, IAccueilPresenter>, IAccueilPresenter
    {
        public IList<Product> ListeProduitEnVente
        {
            get { return (IList<Product>)Session["ListeProduitEnVente"]; }
            set
            {
                string html = "<div style='float: left; text-align: center;'><img src='Images/Product/{0}' width='160px' style='border: solid 1px gray' /><br />{1}<br /><strike>{2}</strike>{3}</div>";
                foreach (Product product in value)
                {
                    Literal literal = new Literal
                        {
                            Text = string.Format(html, product.PrincipalFileUrl, product.NameFrench, product.UnitPrice,
                                                 product.SalePrice)
                        };
                    placeHolderListeProduitEnVente.Controls.Add(literal);
                }
                Session["ListeProduitEnVente"] = value;
            }
        }
    }
}