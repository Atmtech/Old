using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using ATMTECH.Common.Constant;
using ATMTECH.Common.Utils.Web;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class CourrielService : BaseService, ICourrielService
    {
        public IDAOCourriel DAOCourriel { get; set; }
        public IParameterService ParameterService { get; set; }
        public IMessageService MessageService { get; set; }
        public ILogService LogService { get; set; }
        public ILocalizationService LocalizationService { get; set; }

        public void EnvoyerConfirmationCreationClient(Customer client)
        {
            Mail courriel = DAOCourriel.ObtenirMail("CONFIRMATION_CREATION_CLIENT");
            string sujet = RemplacerAvecNomChamp(ObtenirSujet(courriel), client);
            string corps = RemplacerAvecNomChamp(ObtenirCorps(courriel), client);
            EnvoyerCourriel(client.User.Login, courriel.From, sujet, corps);
        }
        public void EnvoyerConfirmationCommande(Order commande)
        {
            Mail courriel = DAOCourriel.ObtenirMail("CONFIRMATION_COMMANDE");
            string sujet = RemplacerAvecNomChamp(ObtenirSujet(courriel), commande);
            string corps = RemplacerAvecNomChamp(ObtenirCorps(courriel), commande);
            EnvoyerCourriel(commande.Customer.User.Login, courriel.From, sujet, corps);
        }
        public void EnvoyerInformationCommande(Order commande)
        {
            Mail courriel = DAOCourriel.ObtenirMail("INFORMATION_COMMANDE");
            string sujet = RemplacerAvecNomChamp(ObtenirSujet(courriel), commande);
            string corps = RemplacerAvecNomChamp(ObtenirCorps(courriel), commande);
            EnvoyerCourriel(commande.Customer.User.Login, courriel.From, sujet, corps);
        }
        public void EnvoyerMotPasseOublie(Customer client)
        {
            Mail courriel = DAOCourriel.ObtenirMail("ENVOYER_MOT_PASSE_OUBLIE");
            string sujet = RemplacerAvecNomChamp(ObtenirSujet(courriel), client);
            string corps = RemplacerAvecNomChamp(ObtenirCorps(courriel), client);
            EnvoyerCourriel(client.User.Login, courriel.From, sujet, corps);
        }

        public bool EnvoyerCourriel(string to, string from, string subject, string body)
        {
            return ParameterService.GetValue("Environment") != "PROD" ? EnvoyerDeveloppement(to, from, subject, body) : EnvoyerProduction(to, from, subject, body, null, string.Empty);
        }
        public bool EnvoyerCourriel(string to, string from, string subject, string body, Stream file, string fileName)
        {
            return ParameterService.GetValue("Environment") != "PROD" ? EnvoyerDeveloppement(to, from, subject, body) : EnvoyerProduction(to, from, subject, body, file, fileName);
        }

        private bool EnvoyerProduction(string to, string from, string subject, string body, Stream file, string fileName)
        {
            if (string.IsNullOrEmpty(to))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_NO_EMAIL_TO);
                return false;
            }

            MailAddress fromx = new MailAddress(from, "");
            MailAddress tox = new MailAddress(to, "");

            string subjectFormat = Pages.RemoveHtmlTag(subject);
            MailMessage message = new MailMessage(fromx, tox) { IsBodyHtml = true, Body = body, Subject = subjectFormat };
            LogService.LogMail(message);
            return Envoyer(message, file, fileName);
        }
        private bool EnvoyerDeveloppement(string to, string from, string subject, string body)
        {
            MailAddress fromx = new MailAddress(from, "");
            MailAddress tox = new MailAddress(to, "");

            string subjectFormat = Pages.RemoveHtmlTag(subject);
            MailMessage message = new MailMessage(fromx, tox) { IsBodyHtml = true, Body = body, Subject = subjectFormat };
            LogService.LogMail(message);
            return true;
        }
        private bool Envoyer(MailMessage message, Stream file, string fileName)
        {

            SmtpClient client = new SmtpClient(ParameterService.GetValue("SmtpServer"),
                                               Convert.ToInt32(ParameterService.GetValue("SmtpServerPort"))) { EnableSsl = true };

            NetworkCredential myCreds = new NetworkCredential(ParameterService.GetValue("SmtpServerLogin"), ParameterService.GetValue("SmtpServerPassword"), "");
            client.Credentials = myCreds;

            if (file != null)
            {
                Attachment data = new Attachment(file, fileName);
                message.Attachments.Add(data);
            }

            try
            {
                client.Send(message);
            }
            catch (Exception exception)
            {
                DAOLogException daoLogException = new DAOLogException();
                LogException logException = new LogException
                {
                    InnerId = "INTERNAL",
                    Page = Pages.GetCurrentUrl() + Pages.GetCurrentPage(),
                    Description = exception.Message + " => EnvoyerCourriel " + client.Host + " " + client.Port + " " + myCreds.UserName + " " + myCreds.Password,
                    StackTrace = exception.StackTrace
                };
                daoLogException.Save(logException);
                return false;
            }

            return true;
        }
        private string RemplacerAvecNomChamp(string chaine, object entite)
        {
            foreach (PropertyInfo propertyInfo in entite.GetType().GetProperties())
            {
                object valeurPropriete = propertyInfo.GetValue(entite, null);
                if (valeurPropriete != null)
                {
                    if (propertyInfo.PropertyType.Namespace == "System")
                    {
                        chaine = chaine.Replace(string.Format("[{0}]", propertyInfo.Name), valeurPropriete.ToString());
                    }
                    else
                    {
                        PropertyInfo propertyInfoId = valeurPropriete.GetType().GetProperty("Id");
                        string valeurEnfant = propertyInfoId.GetValue(valeurPropriete, null).ToString();
                        chaine = chaine.Replace(string.Format("[{0}]", propertyInfo.Name), valeurEnfant);
                    }

                }

            }
            return chaine;
        }

        private string ObtenirSujet(Mail courriel)
        {
            switch (LocalizationService.CurrentLanguage)
            {
                case LocalizationLanguage.FRENCH:
                    return courriel.SubjectFr;
                case LocalizationLanguage.ENGLISH:
                    return courriel.SubjectEn;
                default:
                    return string.Empty;
            }
        }
        private string ObtenirCorps(Mail courriel)
        {
            switch (LocalizationService.CurrentLanguage)
            {
                case LocalizationLanguage.FRENCH:
                    return courriel.BodyFr;
                case LocalizationLanguage.ENGLISH:
                    return courriel.BodyEn;
                default:
                    return string.Empty;
            }

        }
    }
}

