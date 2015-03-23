using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
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
        public IMailService MailService { get; set; }
        public IMessageService MessageService { get; set; }
        public ITaxesService TaxesService { get; set; }

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

                    //TOADO: Code de marde à refaire !!! 
                    client.Taxes = new Taxes { Id = 1 }; 
                    Customer clientCreer = DAOClient.ObtenirClient(DAOClient.Creer(client));
                    MailService.SendEmail(clientCreer.User.Email,
                        ParameterService.GetValue(Constant.ADMIN_MAIL),
                        string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE), clientCreer.Enterprise.Name),
                        string.Format(ParameterService.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE), clientCreer.Enterprise.Name, clientCreer.Enterprise.SubDomainName, clientCreer.User.Id));
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
                MessageService.ThrowMessage(ErrorCode.SC_USER_NOT_EXIST_ON_CONFIRM);
            }
            return false;
        }
        public bool EnvoyerMotPasseOublie(string courriel)
        {
            User user = DAOUser.GetUserByEmail(courriel);
            if (user != null)
            {
                string password = user.Password;
                string login = user.Login;
                Customer customer = DAOClient.ObtenirClient(user);

                if (customer != null)
                {
                    string corpsMessage = string.Format(
                        ParameterService.GetValue(Constant.MAIL_BODY_FORGET_PASSWORD),
                        customer.Enterprise.Name, login, password);
                    return MailService.SendEmail(courriel,
                                                    ParameterService.GetValue(Constant.ADMIN_MAIL),
                                                    ParameterService.GetValue(Constant.MAIL_SUBJECT_FORGET_PASSWORD),
                                                    corpsMessage);
                }
                return false;
            }
            return false;
        }
    }
}

