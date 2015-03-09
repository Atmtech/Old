using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
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
                int id = DAOUser.CreateUser(client.User);
                User user = DAOUser.GetUser(id);
                user.IsActive = false;
                DAOUser.UpdateUser(user);
                client.User = user;
                Customer clientCreer = DAOClient.ObtenirClient(DAOClient.Creer(client));
                MailService.SendEmail(clientCreer.User.Email,
                    ParameterService.GetValue(Constant.ADMIN_MAIL),
                    string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE), clientCreer.Enterprise.Name),
                    string.Format(ParameterService.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE), clientCreer.Enterprise.Name, clientCreer.Enterprise.SubDomainName, clientCreer.User.Id));
                return clientCreer;
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
    }
}

