using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class CatalogueProduitPresenter : BaseShoppingCartPresenter<ICatalogueProduitPresenter>
    {
        public IProductService ProductService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public CatalogueProduitPresenter(ICatalogueProduitPresenter view)
            : base(view)
        {
        }

        public void AfficherListeProduit()
        {
            Customer customer = CustomerService.AuthenticateCustomer;

            if (!string.IsNullOrEmpty(View.Recherche))
            {
                View.Produits = ProductService.GetProducts(customer.Enterprise.Id, customer.User.Id, View.Recherche);
            }
            else
            {
                View.Produits = ProductService.GetProducts(customer.Enterprise.Id, customer.User.Id);
            }
        }
    }
}
