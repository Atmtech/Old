using System.Collections.Generic;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class ClientService : BaseService, IClientService
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IDAOClient DAOClient { get; set; }
        public IValiderClientService ValiderClientService { get; set; }
        public IDAOUser DAOUser { get; set; }
        public IParameterService ParameterService { get; set; }
        public IMessageService MessageService { get; set; }
        public ITaxesService TaxesService { get; set; }
        public ICourrielService CourrielService { get; set; }


        public Customer ClientAuthentifie
        {
            get
            {
                return AuthenticationService.AuthenticateUser != null ? DAOClient.ObtenirClient(AuthenticationService.AuthenticateUser) : null;
            }
        }
        public Customer Creer(Customer client)
        {
            if (ValiderClientService.EstClientValide(client))
            {
                if (!ValiderClientService.EstClientExistant(client))
                {
                    int id = DAOUser.CreateUser(client.User);
                    User user = DAOUser.GetUser(id);
                    user.IsActive = false;
                    DAOUser.UpdateUser(user);
                    client.User = user;

                    //TODO: Code de marde à refaire !!! 
                    client.Taxes = new Taxes { Id = 1 };
                    Customer clientCreer = DAOClient.ObtenirClient(DAOClient.Creer(client));
                    CourrielService.EnvoyerConfirmationCreationClient(clientCreer);
                    return clientCreer;
                }
            }
            return null;
        }
        public Customer Enregistrer(Customer client)
        {
            if (ValiderClientService.EstClientValide(client))
            {
                DAOClient.Save(client);
            }
            return client;
        }
        public bool EstConfirme(int id)
        {
            User user = DAOUser.GetUser(id);
            if (user != null)
            {
                if (user.IsActive == false)
                {
                    user.IsActive = true;
                    DAOUser.UpdateUser(user);
                    AuthenticationService.SignIn(user.Login, user.Password);
                    return true;
                }
            }
            else
            {
                MessageService.ThrowMessage(CodeErreur.SC_USER_NOT_EXIST_ON_CONFIRM);
            }
            return false;
        }
        public bool EnvoyerMotPasseOublie(string courriel)
        {
            User user = DAOUser.GetUserByEmail(courriel);
            if (user != null)
            {
                Customer customer = DAOClient.ObtenirClient(user);
                if (customer != null)
                {
                    CourrielService.EnvoyerMotPasseOublie(customer);
                    MessageService.ThrowMessage(CodeErreur.SC_PASSWORD_RECOVERY_SENT);
                }
                return false;
            }
            return false;
        }
        public IList<Customer> ObtenirClient()
        {
            return DAOClient.GetAllActive();
        }
        public IList<User> ObtenirUtilisateur()
        {
            return DAOUser.GetAllUser();
        }
        public Customer ObtenirClient(int id)
        {
            return DAOClient.ObtenirClient(id);
        }
    }
}

