using System.Collections.Generic;
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
                dataListListeProduitEnVente.DataSource = value;
                dataListListeProduitEnVente.DataBind();
                Session["ListeProduitEnVente"] = value;
            }
        }
    }
}