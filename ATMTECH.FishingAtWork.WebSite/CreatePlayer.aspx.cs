using System;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.Views.Pages;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class CreatePlayer : PageBaseFishingAtWork, ICreatePlayerPresenter
    {
        public CreatePlayerPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
                SetCaptchaText();
            }
            Presenter.OnViewLoaded();
        }

        private void SetCaptchaText()
        {
            Random oRandom = new Random();
            int iNumber = oRandom.Next(100000, 999999);
            Session["Captcha"] = iNumber.ToString();
        }

        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }

        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public string UserName
        {
            get { return txtLogin.Text; }
            set { txtLogin.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        public string PasswordConfirmation
        {
            get { return txtConfirmPassword.Text; }
            set { txtConfirmPassword.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public bool CreateSuccess
        {
            set
            {
                if (value)
                {
                    pnlCreate.Visible = false;
                    pnlCreated.Visible = true;
                }
                else
                {
                    pnlCreate.Visible = true;
                    pnlCreated.Visible = false;
                }
            }
        }

        public string CaptchaTextBox
        {
            get { return txtCaptcha.Text; }
            set { txtCaptcha.Text = value; }
        }

        public string CaptchaSession
        {
            get { return Session["Captcha"].ToString(); }
        }

        protected void CreatePlayerClick(object sender, EventArgs e)
        {
            Presenter.CreatePlayer();
        }

        protected void CancelCreatePlayerClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.DEFAULT);
        }

        protected void ReloadCaptcha_click(object sender, EventArgs e)
        {
            SetCaptchaText();
        }

        protected void InitPlayerClick(object sender, EventArgs e)
        {
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";
            txtCaptcha.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}