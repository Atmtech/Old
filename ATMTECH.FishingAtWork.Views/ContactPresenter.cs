using System.Text.RegularExpressions;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Services.ErrorCode;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class ContactPresenter : BaseFishingAtWorkPresenter<IContactPresenter>
    {
        public IMailService MailService { get; set; }
        public IParameterService ParameterService { get; set; }
        public IPlayerService PlayerService { get; set; }

        public ContactPresenter(IContactPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            Player player = PlayerService.AuthenticatePlayer;
            if (player != null)
            {
                View.Name = player.User.FirstNameLastName;
                View.Email = player.User.Email;
            }
        }
        private void ValidateEmail(string email)
        {
            const string matchEmailPattern =
                @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";

            if (!Regex.IsMatch(email, matchEmailPattern))
            {
                MessageService.ThrowMessage(ErrorCode.SC_INVALID_EMAIL);
            }
        }

        public void SendMail()
        {
            ValidateEmail(View.Email);

            bool ret = MailService.SendEmail(ParameterService.GetValue(Constant.ADMIN_MAIL), View.Email,
                                             string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE), View.Name), View.Body);
            if (ret == false)
            {
                MessageService.ThrowMessage(ErrorCode.SC_SEND_MAIL_FAILED);
            }
        }

    }
}
