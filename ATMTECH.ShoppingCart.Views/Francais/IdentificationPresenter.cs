using System;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class IdentificationPresenter : BaseShoppingCartPresenter<IIdentificationPresenter>
    {
        public IdentificationPresenter(IIdentificationPresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }
        public IClientService ClientService { get; set; }

        public void Identification()
        {
            User user = AuthenticationService.SignIn(View.NomUtilisateurIdentification, View.MotPasseIdentification);
            if (user != null)
            {
                if (NavigationService.ListePageAcceder.Count > 2)
                {
                    FilArianne dernierePageConsulte =
                        NavigationService.ListePageAcceder[NavigationService.ListePageAcceder.Count - 2];
                    NavigationService.Redirect(dernierePageConsulte.Page.IndexOf(Pages.Pages.ADD_PRODUCT_TO_BASKET) > 0
                        ? dernierePageConsulte.Page
                        : Pages.Pages.DEFAULT);
                }
                else
                {
                    NavigationService.Redirect(Pages.Pages.DEFAULT);
                }
            }
        }
        public void CreerUtilisateur()
        {
            if (View.MotPasseCreation != View.MotPasseConfirmationCreation)
            {
                MessageService.ThrowMessage(CodeErreur.SC_MOT_PASSE_INEGALE_AVEC_CONFIRMATION);
            }

            User user = new User
                {
                    Email = View.CourrielCreation,
                    Login = View.CourrielCreation,
                    Password = View.MotPasseCreation,
                    FirstName = View.PrenomCreation,
                    LastName = View.NomCreation
                };
            Customer customer = new Customer
                {
                    User = user,
                    Enterprise = new Enterprise { Id = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)) }
                };

            if (ClientService.Creer(customer) != null)
            {
                MessageService.ThrowMessage(CodeErreur.ADM_CREATION_UTILISATEUR_EST_UN_SUCCES);
            }
        }
    }
}