using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class CatalogueProduitPresenter : BaseShoppingCartPresenter<ICatalogueProduitPresenter>
    {
        public CatalogueProduitPresenter(ICatalogueProduitPresenter view)
            : base(view)
        {
        }

        public IProductService ProductService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public void AfficherListeProduit()
        {
            Customer customer = CustomerService.AuthenticateCustomer;

            View.Produits = !string.IsNullOrEmpty(View.Recherche)
                                ? ProductService.GetProducts(customer.Enterprise.Id, customer.User.Id, View.Recherche)
                                : ProductService.GetProducts(customer.Enterprise.Id, customer.User.Id);
        }
    }
}