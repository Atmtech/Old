using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
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
                commande = CommandeService.Enregistrer(commande);
                if (commande.OrderLines.Count == 0)
                {
                    NavigationService.Redirect(Pages.Pages.DEFAULT);
                }

                View.Commande = commande;

                if (!string.IsNullOrEmpty(commande.AddressBilling))
                {
                    View.AdresseFacturation = commande.AddressBilling;
                }
                else
                {
                    View.EstSansAdresseFacturation = true;
                    View.EstCommandable = false;
                }

                if (!string.IsNullOrEmpty(commande.AddressShipping) && !string.IsNullOrEmpty(commande.PostalCodeShipping))
                {
                    View.AdresseLivraison = commande.AddressShipping;
                }
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

            if (ClientService.ClientAuthentifie.Enterprise.IsPaypal)
            {
                CommandeService.FinaliserCommandeAvecPaypal(View.Commande);
            }
            else
            {
                CommandeService.FinaliserCommande(View.Commande);
                IList<QueryString> queryStrings = new List<QueryString>();
                queryStrings.Add(new QueryString(PagesId.ORDER_ID, View.Commande.Id.ToString()));
                NavigationService.Redirect(Pages.Pages.THANK_YOU_ORDER, queryStrings);
            }
        }
        public void SupprimerLigneCommande(int id)
        {
            OrderLine orderLine = View.Commande.OrderLines.FirstOrDefault(x => x.Id == id);
            CommandeService.SupprimerLigneCommande(orderLine);
        }
        public void RecalculerPanier(Dictionary<int, int> listeQuantite)
        {
            foreach (KeyValuePair<int, int> keyValuePair in listeQuantite)
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
                View.Commande = CommandeService.ValiderCoupon(View.Commande, View.Coupon);
            }
        }

        public void EffacerCoupon()
        {
            View.Commande = CommandeService.EffacerCoupon(View.Commande);
        }
    }
}