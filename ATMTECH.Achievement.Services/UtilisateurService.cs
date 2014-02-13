using System;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services.Interface;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;
using Parameter = ATMTECH.Web.Services.Base.ParameterConstant;

namespace ATMTECH.Achievement.Services
{
    public class UtilisateurService : BaseService, IUtilisateurService
    {
        public IDAOUser DAOUser { get; set; }
        public IMailService MailService { get; set; }
        public IParameterService ParameterService { get; set; }
        public IMessageService MessageService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public IDAOAmitie DAOAmitie { get; set; }

        public bool Creer(User utilisateur)
        {
            if (utilisateur != null)
            {
                int rtn = DAOUser.CreateUser(utilisateur);
                utilisateur.Id = rtn;
                utilisateur.IsActive = false;
                DAOUser.UpdateUser(utilisateur);
                bool ret = MailService.SendEmail(utilisateur.Email,
                                              ParameterService.GetValue(Parameter.ADMIN_MAIL),
                                               string.Format(ParameterService.GetValue(Parameter.MAIL_SUBJECT_CONFIRM_CREATE)),
                                              string.Format(ParameterService.GetValue(Parameter.MAIL_BODY_CONFIRM_CREATE)));
                if (ret == false)
                {
                    MessageService.ThrowMessage(Common.ErrorCode.ADM_SEND_MAIL_FAILED);
                    return false;
                }
                return true;

            }
            return false;
        }

        public bool ConfirmerCreation(User utilisateur)
        {

            if (utilisateur != null)
            {
                if (utilisateur.IsActive == false)
                {
                    utilisateur.IsActive = true;
                    DAOUser.UpdateUser(utilisateur);
                    AuthenticationService.SignIn(utilisateur.Login, utilisateur.Password);
                    return true;
                }
            }
            else
            {
                MessageService.ThrowMessage(Common.ErrorCode.ADM_USER_NOT_EXIST_ON_CONFIRM);
            }
            return false;
        }

        public void DemandeAmitie(User moiMeme, User ami)
        {
            Amitie amitie = new Amitie { Ami = ami, Utilisateur = moiMeme, EstConfirme = false };
            DAOAmitie.Update(amitie);
        }

        public void ConfirmerAmitie(Amitie amitie)
        {
            amitie.EstConfirme = true;
            DAOAmitie.Update(amitie);
        }
    }
}
