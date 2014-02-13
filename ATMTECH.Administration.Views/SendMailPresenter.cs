using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class SendMailPresenter : BaseAdministrationPresenter<ISendMailPresenter>
    {
        public IMailService MailService { get; set; }
        public IParameterService ParameterService { get; set; }

        public SendMailPresenter(ISendMailPresenter view)
            : base(view)
        {
        }

        public void SendMail(string subject, string body)
        {
            MailService.SendEmail(ParameterService.GetValue("SmtpServerLogin"),
                                  ParameterService.GetValue("SmtpServerLogin"), subject, body);
        }
    }
}
