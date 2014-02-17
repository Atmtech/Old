//using System;
//using ATMTECH.FishingAtWork.Views.Pages;
//using ATMTECH.Views;
//using ATMTECH.Views.Interface;

//namespace ATMTECH.FishingAtWork.WebSite.UserControls
//{
//    public partial class Login : UserControlFishingAtWorkBase, ILoginPresenter
//    {
//        public LoginPresenter Presenter { get; set; }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                Presenter.OnViewInitialized();
//            }
//            Presenter.OnViewLoaded();
//        }

//        protected void SignInClick(object sender, EventArgs e)
//        {
//            Presenter.SignIn(Pages.DEFAULT);
//        }

//        public string FullName
//        {
//            get { return lblName.Text; }
//            set { lblName.Text = value; }
//        }

//        public string UserName
//        {
//            get { return txtUser.Text; }
//            set { txtUser.Text = value; }
//        }

//        public string Password
//        {
//            get { return txtPassword.Text; }
//            set { txtPassword.Text = value; }
//        }

//        public bool IsLogged
//        {
//            set
//            {
//                if (value)
//                {
//                    pnlLogin.Visible = false;
//                    pnlWelcome.Visible = true;
//                }
//                else
//                {
//                    pnlLogin.Visible = true;
//                    pnlWelcome.Visible = false;
//                }
//            }
//        }

//        public bool IsAdministrator
//        {
//            set { lnkAdministration.Visible = value; }
//        }

//        protected void CreateCustomerClick(object sender, EventArgs e)
//        {
//            Presenter.NavigationService.Redirect(Pages.CREATE_PLAYER);
//        }

//        protected void ForgetPasswordClick(object sender, EventArgs e)
//        {
//            Presenter.NavigationService.Redirect(Pages.FORGET_PASSWORD);
//        }

//        protected void SignOutClick(object sender, EventArgs e)
//        {
//            Presenter.SignOut(Pages.DEFAULT);
//        }
//    }
//}