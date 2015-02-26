using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class InformationClientPresenter : BaseShoppingCartPresenter<IInformationClientPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public IAddressService AddressService { get; set; }
        public IDAOCity DAOCity { get; set; }

        public InformationClientPresenter(IInformationClientPresenter view)
            : base(view)
        {
        }

        public void AfficherInformationClient()
        {
            Customer customer = CustomerService.AuthenticateCustomer;
            if (customer != null)
            {
                View.Prenom = customer.User.FirstName;
                View.Nom = customer.User.LastName;
                View.Courriel = customer.User.Email;
                View.MotPasse = customer.User.Password;
                View.MotPasseConfirmation = customer.User.Password;

                View.NoCiviqueLivraison = customer.ShippingAddress.No;
                View.RueLivraison = customer.ShippingAddress.Way;
                View.CodePostalLivraison = customer.ShippingAddress.PostalCode;
                View.PaysLivraison = customer.ShippingAddress.Country.Id;
                View.VilleLivraison = customer.ShippingAddress.City.Description;

                View.NoCiviqueFacturation = customer.BillingAddress.No;
                View.RueFacturation = customer.BillingAddress.Way;
                View.CodePostalFacturation = customer.BillingAddress.PostalCode;
                View.PaysFacturation = customer.BillingAddress.Country.Id;
                View.VilleFacturation = customer.BillingAddress.City.Description;
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

        public void Enregistrer()
        {

            if (string.IsNullOrEmpty(View.Courriel))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
                return;
            }

            if (string.IsNullOrEmpty(View.MotPasse))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
                return;
            }

            if (View.MotPasse != View.MotPasseConfirmation)
            {
                MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
                return;
            }

            Customer customer = CustomerService.AuthenticateCustomer;
            Address adresseLivraison = AddressService.GetShippingAddress(customer)[0];
            Address adresseFacturation = AddressService.GetBillingAddress(customer)[0];

            EnregistrerAdresse(adresseLivraison, View.NoCiviqueLivraison, View.RueLivraison, View.CodePostalLivraison, View.VilleLivraison, View.PaysLivraison);
            EnregistrerAdresse(adresseFacturation, View.NoCiviqueFacturation, View.RueFacturation, View.CodePostalFacturation, View.VilleFacturation, View.PaysFacturation);

            customer.User.FirstName = View.Prenom;
            customer.User.LastName = View.Nom;
            customer.User.Email = View.Courriel;
            customer.User.Password = View.MotPasse;

            CustomerService.SaveCustomer(customer);

            MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_SAVE_IS_CORRECT);
        }

        public Address EnregistrerAdresse(Address adresse, string noCivique, string rue, string CodePostal, string ville, int pays)
        {
            if (adresse == null)
            {
                adresse = new Address
                    {
                        No = noCivique,
                        Way = rue,
                        PostalCode = CodePostal,
                        Country = new Country { Id = pays },
                        City = TrouverVille(ville)
                    };

                return AddressService.SaveNewAddress(adresse);
            }

            adresse.No = noCivique;
            adresse.Way = rue;
            adresse.PostalCode = CodePostal;
            adresse.Country = new Country { Id = pays };
            adresse.City = TrouverVille(ville);

            return AddressService.SaveAddress(adresse);
        }

        private City TrouverVille(string ville)
        {
            City city = DAOCity.FindCity(ville);
            if (city == null)
            {
                int id = DAOCity.CreateCity(new City { Code = ville, Description = ville });
                return DAOCity.GetCity(id);
            }
            return city;
        }

    }
}


