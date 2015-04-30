using System.Text.RegularExpressions;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class ValiderClientService : BaseService, IValiderClientService
    {
        public IMessageService MessageService { get; set; }
        public IDAOUser DAOUser { get; set; }

        public bool EstCourrielValide(Customer client)
        {
            const string matchEmailPattern =
               @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";
            if (client.User.Email != null)
            {
                if (!Regex.IsMatch(client.User.Email, matchEmailPattern))
                {
                    MessageService.ThrowMessage(CodeErreur.SC_COURRIEL_EST_INVALIDE);
                    return false;
                }
            }

            return true;
        }
        public bool EstClientExistant(Customer client)
        {
            User user = DAOUser.GetUser(client.User.Login);
            if (user != null)
            {
                MessageService.ThrowMessage(CodeErreur.SC_CET_UTILISATEUR_EXISTE_DEJA);
                return true;
            }
            return false;
        }
        public bool EstNomUtilisateurValide(Customer client)
        {
            if (string.IsNullOrEmpty(client.User.Login))
            {
                MessageService.ThrowMessage(CodeErreur.ADM_CREATION_NOM_UTILISATEUR_OBLIGATOIRE);
                return false;
            }
            return true;
        }
        public bool EstMotPasseValide(Customer client)
        {
            if (string.IsNullOrEmpty(client.User.Password))
            {
                MessageService.ThrowMessage(CodeErreur.ADM_CREATION_NOM_UTILISATEUR_OBLIGATOIRE);
                return false;
            }
            return true;
        }
        public bool EstClientValide(Customer client)
        {
            if (EstCourrielValide(client) == false) return false;
           // if (EstClientExistant(client) == false) return false;
            if (EstNomUtilisateurValide(client) == false) return false;
            if (EstMotPasseValide(client) == false) return false;
            return true;
        }

    }
}

