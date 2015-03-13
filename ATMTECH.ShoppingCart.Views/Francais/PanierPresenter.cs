using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

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
                View.AdresseFacturation = commande.BillingAddress.DisplayAddress;
                View.AdresseLivraison = commande.ShippingAddress.DisplayAddress;
               
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

        public void FinaliserCommande()
        {
            View.CommandeFinalise = View.Commande;
            CommandeService.FinaliserCommande(View.Commande);
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

        public void ImprimerCommande()
        {
            CommandeService.ImprimerCommande(View.CommandeFinalise);
        }

        public void ModifierAdresse()
        {
            NavigationService.Redirect(Pages.Pages.CUSTOMER_INFORMATION);
        }
    }
}