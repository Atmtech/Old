
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using ATMTECH.Common.Constant;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Services
{
    public class CourrielService : BaseService, ICourrielService
    {
        public IDAOCourriel DAOCourriel { get; set; }
        public IParameterService ParameterService { get; set; }
        public IMessageService MessageService { get; set; }
        public ILogService LogService { get; set; }
        public ILocalizationService LocalizationService { get; set; }

        public void EnvoyerConfirmationCreationUtilisateur(User utilisateur)
        {
            Courriel courriel = DAOCourriel.ObtenirMail("CONFIRMATION_CREATION_CLIENT");
            string sujet = RemplacerAvecNomChamp(ObtenirSujet(courriel), utilisateur);
            string corps = RemplacerAvecNomChamp(ObtenirCorps(courriel), utilisateur);
            EnvoyerCourriel(utilisateur.Login, courriel.From, sujet, corps);
        }

        public void EnvoyerMotPasseOublie(User utilisateur)
        {
            Courriel courriel = DAOCourriel.ObtenirMail("ENVOYER_MOT_PASSE_OUBLIE");
            string sujet = RemplacerAvecNomChamp(ObtenirSujet(courriel), utilisateur);
            string corps = RemplacerAvecNomChamp(ObtenirCorps(courriel), utilisateur);
            EnvoyerCourriel(utilisateur.Login, courriel.From, sujet, corps);
        }

        public bool EnvoyerCourriel(string to, string from, string subject, string body)
        {
            return ParameterService.GetValue("Environment") != "PROD" ? EnvoyerDeveloppement(to, from, subject, body) : EnvoyerProduction(to, from, subject, body, null, string.Empty);
        }
        private bool EnvoyerCourriel(string to, string from, string subject, string body, Stream file, string fileName)
        {
            return ParameterService.GetValue("Environment") != "PROD" ? EnvoyerDeveloppement(to, from, subject, body) : EnvoyerProduction(to, from, subject, body, file, fileName);
        }

        private bool EnvoyerProduction(string to, string from, string subject, string body, Stream file, string fileName)
        {
            if (string.IsNullOrEmpty(to))
            {
                MessageService.ThrowMessage(CodeErreur.ADM_AUCUNE_MENTION_TO_POUR_ENVOI_COURRIEL);
                return false;
            }

            MailAddress fromx = new MailAddress(from, "");
            MailAddress tox = new MailAddress(to, "");

            string subjectFormat = subject;
            MailMessage message = new MailMessage(fromx, tox) { IsBodyHtml = true, Body = body, Subject = subjectFormat };
            LogService.LogMail(message);
            return Envoyer(message, file, fileName);
        }
        private bool EnvoyerDeveloppement(string to, string from, string subject, string body)
        {
            MailAddress fromx = new MailAddress(from, "");
            MailAddress tox = new MailAddress(to, "");

            string subjectFormat = subject;//Pages.RemoveHtmlTag(subject);
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
                    //Page = ATMTECH.Common.Utils.Web.Pages.GetCurrentUrl(),// + Pages.GetCurrentPage(),
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
                        foreach (PropertyInfo propertyInfo2 in valeurPropriete.GetType().GetProperties())
                        {
                            if (propertyInfo2.PropertyType.Namespace == "System")
                            {
                                object value = propertyInfo2.GetValue(valeurPropriete, null);
                                if (value != null)
                                {
                                    string valeurEnfant = value.ToString();
                                    chaine = chaine.Replace(string.Format("[{0}]", propertyInfo2.Name), valeurEnfant);
                                }
                            }
                        }
                    }
                }
            }
            return chaine;
        }
        private string ObtenirSujet(Courriel courriel)
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
        private string ObtenirCorps(Courriel courriel)
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
