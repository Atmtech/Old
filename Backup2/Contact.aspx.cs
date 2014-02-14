using System;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.Views.Pages;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class Contact : PageBaseFishingAtWork, IContactPresenter
    {
        public ContactPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        protected void SendMailClick(object sender, EventArgs e)
        {
            Presenter.SendMail();
        }

        protected void CancelSendMailClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.DEFAULT);
        }

        public string Name
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string Body
        {
            get { return CKEditorMail.Text; }
        }
    }
}