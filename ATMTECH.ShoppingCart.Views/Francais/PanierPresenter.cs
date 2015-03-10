using System.Collections.Generic;
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

        public void AfficherPanier()
        {
            Customer customer = ClientService.ClientAuthentifie;

            if (customer != null)
            {
                View.Commande = CommandeService.ObtenirCommandeSouhaite(customer);
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