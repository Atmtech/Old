using System;
using System.Reflection;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class CourrielService : BaseService, ICourrielService
    {
        public IMailService MailService { get; set; }
        public IDAOCourriel DAOCourriel { get; set; }

        public void EnvoyerConfirmationCreationClient(Customer client)
        {
            Mail courriel = DAOCourriel.ObtenirMail("CONFIRMATION_CREATION_CLIENT");
            string sujet = RemplacerAvecNomChamp(courriel.Subject, client);
            string corps = RemplacerAvecNomChamp(courriel.Body, client);
            MailService.SendEmail(client.User.Login, courriel.From, sujet, corps);
        }

        public void EnvoyerConfirmationCommande(Order commande)
        {
            Mail courriel = DAOCourriel.ObtenirMail("CONFIRMATION_COMMANDE");
            string sujet = RemplacerAvecNomChamp(courriel.Subject, commande);
            string corps = RemplacerAvecNomChamp(courriel.Body, commande);
            MailService.SendEmail(commande.Customer.User.Login, courriel.From, sujet, corps);
        }

        public void EnvoyerInformationCommande(Order commande)
        {
            Mail courriel = DAOCourriel.ObtenirMail("INFORMATION_COMMANDE");
            string sujet = RemplacerAvecNomChamp(courriel.Subject, commande);
            string corps = RemplacerAvecNomChamp(courriel.Body, commande);
            MailService.SendEmail(commande.Customer.User.Login, courriel.From, sujet, corps);
        }

        public void EnvoyerMotPasseOublie(Customer client)
        {
            Mail mail = DAOCourriel.ObtenirMail("ENVOYER_MOT_PASSE_OUBLIE");
            string sujet = RemplacerAvecNomChamp(mail.Subject, client);
            string corps = RemplacerAvecNomChamp(mail.Body, client);
            MailService.SendEmail(client.User.Login, mail.From, sujet, corps);
        }

        private string RemplacerAvecNomChamp(string chaine, object entite)
        {
            foreach (PropertyInfo propertyInfo in entite.GetType().GetProperties())
            {
                object valeurPropriete = propertyInfo.GetValue(entite, null);
                chaine = chaine.Replace(string.Format("[{0}]", propertyInfo.Name), valeurPropriete.ToString());
            }
            return chaine;
        }
    }
}

