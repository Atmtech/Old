using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class InformationClientPresenter : BaseShoppingCartPresenter<IInformationClientPresenter>
    {
        public InformationClientPresenter(IInformationClientPresenter view)
            : base(view)
        {
        }

        public IClientService ClientService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IAddressService AddressService { get; set; }
        public IDAOCity DAOCity { get; set; }
        public IDAOCountry DAOCountry { get; set; }
        public IEnvoiPostalService EnvoiPostalService { get; set; }
        public IGoogleMapService GoogleMapService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherInformationClient();
            AfficherCommandePasse();
        }
        public void AfficherCommandePasse()
        {
            Customer customer = ClientService.ClientAuthentifie;
            if (customer != null)
            {
                View.ListeCommandePasse = CommandeService.ObtenirCommande(customer);
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }
        public void AfficherInformationClient()
        {
            Customer customer = ClientService.ClientAuthentifie;
            if (customer != null)
            {
                View.Prenom = customer.User.FirstName;
                View.Nom = customer.User.LastName;
                View.Courriel = customer.User.Email;
                View.MotPasse = customer.User.Password;
                View.MotPasseConfirmation = customer.User.Password;
                View.CodePostalLivraison = customer.PostalCodeShipping;

                if (string.IsNullOrEmpty(customer.AddressBilling))
                {
                    View.EstAucuneAdresseFacturation = true;
                }
                else
                {
                    View.AdresseLongueFacturation = customer.AddressBilling;
                }

                if (string.IsNullOrEmpty(customer.AddressShipping))
                {
                    View.EstAucuneAdresseLivraison = true;
                }
                else
                {
                    View.AdresseLongueLivraison = customer.AddressShipping;
                }
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }
        public void EnregistrerMotPasse()
        {
            if (string.IsNullOrEmpty(View.MotPasse))
            {
                MessageService.ThrowMessage(CodeErreur.ADM_CREATION_NOM_UTILISATEUR_OBLIGATOIRE);
                return;
            }

            if (View.MotPasse != View.MotPasseConfirmation)
            {
                MessageService.ThrowMessage(CodeErreur.SC_MOT_PASSE_INEGALE_AVEC_CONFIRMATION);
                return;
            }

            Customer customer = ClientService.ObtenirClient(ClientService.ClientAuthentifie.Id);
            customer.User.Password = View.MotPasse;
            ClientService.Enregistrer(customer);
            MessageService.ThrowMessage(CodeErreur.ADM_ENREGISTRER_AVES_SUCCES);
        }
        public void Enregistrer()
        {
            if (string.IsNullOrEmpty(View.Courriel))
            {
                MessageService.ThrowMessage(CodeErreur.ADM_CREATION_NOM_UTILISATEUR_OBLIGATOIRE);
                return;
            }


            if (EnvoiPostalService.EstCodePostalValideAvecPurolator(View.CodePostalLivraison) == false)
            {
                MessageService.ThrowMessage(CodeErreur.SC_CODE_POSTAL_INVALIDE);
                return;
            }

            Customer customer = ClientService.ClientAuthentifie;
            customer.AddressBilling = View.AdresseLongueFacturation;
            customer.AddressShipping = View.AdresseLongueLivraison;
            customer.PostalCodeShipping = View.CodePostalLivraison;
            customer.User.FirstName = View.Prenom;
            customer.User.LastName = View.Nom;
            customer.User.Email = View.Courriel;

            ClientService.Enregistrer(customer);
            MessageService.ThrowMessage(CodeErreur.ADM_ENREGISTRER_AVES_SUCCES);
        }
    }
}