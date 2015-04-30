﻿using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class PageMaitrePresenter : BaseShoppingCartPresenter<IPageMaitrePresenter>
    {
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }
        public IClientService ClientService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IDAOListeDistribution DAOListeDistribution { get; set; }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            EstSiteHorsLigne();
            AfficherInformation();
        }
        public void EstSiteHorsLigne()
        {
            string isOffline = ParameterService.GetValue(Constant.IS_OFFLINE);
            if (string.IsNullOrEmpty(isOffline)) return;
            if (isOffline == "1")
            {
                NavigationService.Redirect(Pages.Pages.MAINTENANCE);
            }
        }
        public void AfficherInformation()
        {
            View.AffichageLangue = LocalizationService.CurrentLanguage;

            Customer customer = ClientService.ClientAuthentifie;
            if (customer == null) return;
            View.EstConnecte = true;
            View.NomClient = customer.User.FirstNameLastName;
            
            Order commande = CommandeService.ObtenirCommandeSouhaite(customer);

            if (commande == null) return;
            if (commande.OrderLines.Count == 0)
            {
                View.AffichagePanier = string.Empty;
                return;
            }

            string nombreItem = commande.OrderLines == null ? "0" : commande.OrderLines.Count.ToString();
            string grandTotal = commande.GrandTotal.ToString("C");

            string affichagePanier;
            if (commande.Coupon != null)
            {
                string grandTotalAvecCoupon = commande.GrandTotalWithCoupon.ToString("C");
                affichagePanier = string.Format("{0} - {1} item(s)", grandTotalAvecCoupon, nombreItem);
            }
            else
            {
                affichagePanier = string.Format("{0} - {1} item(s)", grandTotal, nombreItem);
            }



            View.AffichagePanier = affichagePanier;
        }
        public void FermerSession()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
        public void RejoindreListeDiffusion()
        {
            MailingList mailingList = new MailingList
                {
                    IsActive = true,
                    Email = View.CourrielListeDiffusion
                };
            DAOListeDistribution.Save(mailingList);
            NavigationService.Redirect(Pages.Pages.MAILING_LIST);
        }
        public void MettreSiteEnFrancais()
        {
            LocalizationService.CurrentLanguage = LocalizationLanguage.FRENCH;
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
        public void MettreSiteEnAnglais()
        {
            LocalizationService.CurrentLanguage = LocalizationLanguage.ENGLISH;
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
    }
}