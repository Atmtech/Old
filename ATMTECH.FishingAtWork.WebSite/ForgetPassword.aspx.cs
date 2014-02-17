//using System;
//using ATMTECH.FishingAtWork.Views;
//using ATMTECH.FishingAtWork.Views.Interface;
//using ATMTECH.FishingAtWork.WebSite.Base;

//namespace ATMTECH.FishingAtWork.WebSite
//{
//    public partial class ForgetPassword : PageBaseFishingAtWork, IForgetPasswordPresenter
//    {
//        public ForgetPasswordPresenter Presenter { get; set; }
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                Presenter.OnViewInitialized();
//            }
//            Presenter.OnViewLoaded();
//        }
//        protected void SendMail_click(object sender, EventArgs e)
//        {
//            Presenter.SendMail();
//            lblConfirmSendEmail.Visible = true;
//        }

//        public string Email
//        {
//            get { return txtEmail.Text; }
//            set { txtEmail.Text = value; }
//        }
//    }
//}