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
                //ListeProduit.Produits = value;
                Session["ListeProduitEnVente"] = value;
            }
        }
        public IList<Product> ListeProduitSlideShow
        {
            get { return (IList<Product>)Session["ListeProduitSlideShow"]; }
            set
            {

                Session["ListeProduitSlideShow"] = value;
                SlideShowAccueil.Produits = value;
                SlideShowAccueil.Langue = Presenter.CurrentLanguage;
            }
        }
    }
}