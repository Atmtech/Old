using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.View
{
    [TestClass]
    public class InformationClientPresenterTest : BaseTest<InformationClientPresenter>
    {
        public Mock<IInformationClientPresenter> ViewMock
        {
            get { return ObtenirMock<IInformationClientPresenter>(); }
        }


        [TestMethod]
        public void AfficherInformationClient_SiAucunClientIdentifierOnRedirigeALAccueil()
        {
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns((Customer)null);
            InstanceTest.AfficherInformationClient();
            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT), Times.Once());
        }

        [TestMethod]
        public void AfficherInformationClient_SiClientEstIdentifieOnRempliLesInformationDeLaVue()
        {
            Customer customer = AutoFixture.Create<Customer>();

            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AfficherInformationClient();

            ViewMock.VerifySet(x => x.Prenom = customer.User.FirstName);
            ViewMock.VerifySet(x => x.Nom = customer.User.LastName);
            ViewMock.VerifySet(x => x.Courriel = customer.User.Email);
            ViewMock.VerifySet(x => x.MotPasse = customer.User.Password);
            ViewMock.VerifySet(x => x.MotPasseConfirmation = customer.User.Password);
            ViewMock.VerifySet(x => x.NoCiviqueLivraison = customer.ShippingAddress.No);
            ViewMock.VerifySet(x => x.RueLivraison = customer.ShippingAddress.Way);
            ViewMock.VerifySet(x => x.CodePostalLivraison = customer.ShippingAddress.PostalCode);
            ViewMock.VerifySet(x => x.PaysLivraison = customer.ShippingAddress.Country.Id);
            ViewMock.VerifySet(x => x.VilleLivraison = customer.ShippingAddress.City.Description);
            ViewMock.VerifySet(x => x.NoCiviqueFacturation = customer.BillingAddress.No);
            ViewMock.VerifySet(x => x.RueFacturation = customer.BillingAddress.Way);
            ViewMock.VerifySet(x => x.CodePostalFacturation = customer.BillingAddress.PostalCode);
            ViewMock.VerifySet(x => x.PaysFacturation = customer.BillingAddress.Country.Id);
            ViewMock.VerifySet(x => x.VilleFacturation = customer.BillingAddress.City.Description);
        }

        [TestMethod]
        public void AfficherInformationClient_SiAucuneAdresseLivraisonOnAffirmeAvoirAucuneAdresse()
        {
            Customer customer = AutoFixture.Create<Customer>();
            customer.ShippingAddress.No = null;
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AfficherInformationClient();
            ViewMock.VerifySet(x => x.EstAucuneAdresseLivraison = true);
        }

        [TestMethod]
        public void AfficherInformationClient_SiAucuneAdresseFacturationOnAffirmeAvoirAucuneAdresse()
        {
            Customer customer = AutoFixture.Create<Customer>();
            customer.BillingAddress.No = null;
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AfficherInformationClient();
            ViewMock.VerifySet(x => x.EstAucuneAdresseFacturation = true);
        }

        [TestMethod]
        public void EnregistrerAdresse_DevraitFaireUneRechercheAvecLaVilleSaisieVoirSiElleExiste()
        {
            InstanceTest.EnregistrerAdresse(null, "1", "Rue du havre", "G6H1A7", "Montréal", 1);

            ObtenirMock<IDAOCity>().Verify(test => test.FindCity(It.Is<string>(a => a == "Montréal")), Times.Once());
        }

        [TestMethod]
        public void EnregistrerAdresse_SiAucuneVilleIlFautLaCreer()
        {
            ObtenirMock<IDAOCity>().Setup(test => test.FindCity("Montréal")).Returns((City)null);

            InstanceTest.EnregistrerAdresse(null, "1", "Rue du havre", "G6H1A7", "Montréal", 1);

            ObtenirMock<IDAOCity>().Verify(x => x.CreateCity(It.Is<City>(a => a.Code == "Montréal")), Times.Once());
            ObtenirMock<IDAOCity>().Verify(x => x.CreateCity(It.Is<City>(a => a.Description == "Montréal")), Times.Once());
        }

        [TestMethod]
        public void EnregistrerAdresse_SiUneVilleAEteTrouveIlFautLassocier()
        {
            City city = AutoFixture.Create<City>();

            ObtenirMock<IDAOCity>().Setup(test => test.FindCity("Montréal")).Returns(city);

            InstanceTest.EnregistrerAdresse(null, "1", "Rue du havre", "G6H1A7", "Montréal", 1);

            ObtenirMock<IAddressService>().Verify(x => x.SaveNewAddress(It.Is<Address>(a => a.City.Description == city.Description)));
        }

        [TestMethod]
        public void EnregistrerAdresse_SiAdresseEstPasNullOnEnregistreAvecNouveauElement()
        {
            Address address = AutoFixture.Create<Address>();

            InstanceTest.EnregistrerAdresse(address, "1", "Rue du havre", "G6H1A7", "Montréal", 1121121212);

            ObtenirMock<IAddressService>().Verify(x => x.SaveAddress(It.Is<Address>(a => a.No == "1")));
            ObtenirMock<IAddressService>().Verify(x => x.SaveAddress(It.Is<Address>(a => a.Way == "Rue du havre")));
            ObtenirMock<IAddressService>().Verify(x => x.SaveAddress(It.Is<Address>(a => a.PostalCode == "G6H1A7")));
            ObtenirMock<IAddressService>().Verify(x => x.SaveAddress(It.Is<Address>(a => a.Country.Id == 1121121212)));
        }


        [TestMethod]
        public void Enregistrer_SiCourrielEstInexistantLancerErreur()
        {
            InstanceTest.Enregistrer();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY), Times.Once());
        }

        [TestMethod]
        public void Enregistrer_SiMotPasseEstInexistantLancerErreur()
        {
            ViewMock.Setup(x => x.Courriel).Returns("test");
            ViewMock.Setup(x => x.MotPasse).Returns("");
            InstanceTest.Enregistrer();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY), Times.Once());
        }

        [TestMethod]
        public void Enregistrer_SiMotPasseEstDifferentConfirmationLancerErreur()
        {
            ViewMock.Setup(x => x.Courriel).Returns("test");
            ViewMock.Setup(x => x.MotPasse).Returns("test");
            ViewMock.Setup(x => x.MotPasseConfirmation).Returns("xna");
            InstanceTest.Enregistrer();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM), Times.Once());
        }

        [TestMethod]
        public void Enregistrer_SurEnregistrementOnDoitSauvegarderAdresseLivraisonEtFacturation()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Address address = AutoFixture.Create<Address>();

            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            ObtenirMock<IDAOCity>().Setup(x => x.FindCity(address.City.Description)).Returns(address.City);

            ViewMock.Setup(x => x.Courriel).Returns("test");
            ViewMock.Setup(x => x.MotPasse).Returns("test");
            ViewMock.Setup(x => x.MotPasseConfirmation).Returns("test");

            InstanceTest.Enregistrer();

            ObtenirMock<IAddressService>().Verify(x => x.SaveAddress(It.IsAny<Address>()), Times.Exactly(2));

        }


        [TestMethod]
        public void Enregistrer_SurEnregistrementOnSauvegardeLesInformationDuClient()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Address address = AutoFixture.Create<Address>();
            customer.BillingAddress = address;
            customer.ShippingAddress = address;

            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            ObtenirMock<IDAOCity>().Setup(x => x.FindCity(address.City.Description)).Returns(address.City);

            ViewMock.Setup(x => x.Nom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.Courriel).Returns(customer.User.Email);
            ViewMock.Setup(x => x.Prenom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.MotPasse).Returns(customer.User.Password);
            ViewMock.Setup(x => x.MotPasseConfirmation).Returns(customer.User.Password);

            InstanceTest.Enregistrer();

            ObtenirMock<ICustomerService>().Verify(x => x.SaveCustomer(It.Is<Customer>(a => a.User.FirstName == customer.User.FirstName)));
            ObtenirMock<ICustomerService>().Verify(x => x.SaveCustomer(It.Is<Customer>(a => a.User.LastName == customer.User.LastName)));
            ObtenirMock<ICustomerService>().Verify(x => x.SaveCustomer(It.Is<Customer>(a => a.User.Email == customer.User.Email)));
            ObtenirMock<ICustomerService>().Verify(x => x.SaveCustomer(It.Is<Customer>(a => a.User.Password == customer.User.Password)));

        }

        [TestMethod]
        public void Enregistrer_SurEnregistrementOnDoitSauvegarderLadresseFacturation()
        {
            Customer customer = AutoFixture.Create<Customer>();
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);

            ViewMock.Setup(x => x.Nom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.Courriel).Returns(customer.User.Email);
            ViewMock.Setup(x => x.Prenom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.MotPasse).Returns(customer.User.Password);
            ViewMock.Setup(x => x.MotPasseConfirmation).Returns(customer.User.Password);

            ObtenirMock<IAddressService>()
                .Setup(x => x.SaveAddress(It.IsAny<Address>()))
                .Returns(customer.BillingAddress);

            ViewMock.Setup(x => x.NoCiviqueFacturation).Returns("10");

            InstanceTest.Enregistrer();

            ObtenirMock<ICustomerService>().Verify(x => x.SaveCustomer(It.Is<Customer>(a => a.BillingAddress.No == "10")));
        }

        [TestMethod]
        public void Enregistrer_SurEnregistrementOnDoitSauvegarderLadresseLivraison()
        {
            Customer customer = AutoFixture.Create<Customer>();
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);

            ViewMock.Setup(x => x.Nom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.Courriel).Returns(customer.User.Email);
            ViewMock.Setup(x => x.Prenom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.MotPasse).Returns(customer.User.Password);
            ViewMock.Setup(x => x.MotPasseConfirmation).Returns(customer.User.Password);

            ObtenirMock<IAddressService>()
                .Setup(x => x.SaveAddress(It.IsAny<Address>()))
                .Returns(customer.ShippingAddress);

            ViewMock.Setup(x => x.NoCiviqueLivraison).Returns("10");

            InstanceTest.Enregistrer();

            ObtenirMock<ICustomerService>().Verify(x => x.SaveCustomer(It.Is<Customer>(a => a.ShippingAddress.No == "10")));

        }


        [TestMethod]
        public void Enregistrer_SiToutEstOkOnDoitAvoirUnMessageDeConfirmation()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Address address = AutoFixture.Create<Address>();

            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            ObtenirMock<IDAOCity>().Setup(x => x.FindCity(address.City.Description)).Returns(address.City);

            ViewMock.Setup(x => x.Nom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.Courriel).Returns(customer.User.Email);
            ViewMock.Setup(x => x.Prenom).Returns(customer.User.LastName);
            ViewMock.Setup(x => x.MotPasse).Returns(customer.User.Password);
            ViewMock.Setup(x => x.MotPasseConfirmation).Returns(customer.User.Password);
            
            InstanceTest.Enregistrer();

            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(Web.Services.ErrorCode.ADM_SAVE_IS_CORRECT), Times.Once());
        }

        [TestMethod]
        public void AfficherListePays_OnRempli2ListeAvecPays()
        {
            IList<Country> countries = AutoFixture.CreateMany<Country>() as IList<Country>;
            ObtenirMock<IDAOCountry>().Setup(x => x.GetAllCountries()).Returns(countries);
            InstanceTest.AfficherListePays();

            ViewMock.VerifySet(x => x.ListePaysFacturation = countries);
            ViewMock.VerifySet(x => x.ListePaysLivraison = countries);
        }


    }
}
