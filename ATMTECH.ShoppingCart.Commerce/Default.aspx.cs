using System.Collections.Generic;
using System.Linq;
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
                ListeProduit.Produits = value;
                ListeProduit.Langue = Presenter.CurrentLanguage;
                Session["ListeProduitEnVente"] = value;
                SlideShow.Produits = value.Where(x => x.PercentageSave > 35).ToList();
                SlideShow.Langue = Presenter.CurrentLanguage;
            }
        }
    }
}