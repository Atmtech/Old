using System;
using System.Linq;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class AccueilPresenter : BaseShoppingCartPresenter<IAccueilPresenter>
    {
        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }

        public IProductService ProductService { get; set; }

        public void AfficherListeProduitEnVente()
        {
            int idEnterprise = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED));
            View.ListeProduitEnVente = ProductService.GetProducts(idEnterprise).Where(x => x.SalePrice != null).ToList();
        }
    }
}