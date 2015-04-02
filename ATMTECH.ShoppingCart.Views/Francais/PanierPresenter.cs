using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class PanierPresenter : BaseShoppingCartPresenter<IPanierPresenter>
    {
        public PanierPresenter(IPanierPresenter view)
            : base(view)
        {
        }

        public ICommandeService CommandeService { get; set; }
        public IClientService ClientService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherPanier();
        }


        public void AfficherPanier()
        {
            Customer customer = ClientService.ClientAuthentifie;

            if (customer != null)
            {
                Order commande = CommandeService.ObtenirCommandeSouhaite(customer);
                if (commande.OrderLines.Count == 0)
                {
                    NavigationService.Redirect(Pages.Pages.DEFAULT);
                }

                View.Commande = commande;
                if (commande.BillingAddress != null && commande.BillingAddress.Id != 0)
                    View.AdresseFacturation = commande.BillingAddress.DisplayAddress;
                else
                {
                    View.EstSansAdresseFacturation = true;
                    View.EstCommandable = false;
                }
                if (commande.ShippingAddress != null && commande.ShippingAddress.Id != 0)
                    View.AdresseLivraison = commande.ShippingAddress.DisplayAddress;
                else
                {
                    View.EstSansAdresseLivraison = true;
                    View.EstCommandable = false;
                }

            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

        public void FinaliserCommande()
        {
            CommandeService.ValiderCoupon(View.Commande, View.Coupon);
            CommandeService.FinaliserCommande(View.Commande);
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString(Pages.PagesId.ORDER_ID, View.Commande.Id.ToString()));
            NavigationService.Redirect(Pages.Pages.THANK_YOU_ORDER, queryStrings);
        }

        public void SupprimerLigneCommande(int id)
        {
            OrderLine orderLine = View.Commande.OrderLines.FirstOrDefault(x => x.Id == id);
            if (orderLine != null)
                orderLine.IsActive = false;
            CommandeService.Enregistrer(View.Commande);
        }

        public void RecalculerPanier(Dictionary<int, int> listeQuantite)
        {
            foreach (var keyValuePair in listeQuantite)
            {
                View.Commande.OrderLines[keyValuePair.Key].Quantity = keyValuePair.Value;
            }
            CommandeService.Enregistrer(View.Commande);
            AfficherPanier();
        }


        public void ModifierAdresse()
        {
            NavigationService.Redirect(Pages.Pages.CUSTOMER_INFORMATION);
        }

        public void ValiderCoupon()
        {
            if (!string.IsNullOrEmpty(View.Coupon))
            {
                CommandeService.ValiderCoupon(View.Commande, View.Coupon);
            }
        }
    }
}