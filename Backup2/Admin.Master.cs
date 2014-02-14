using System;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class Admin1 : MasterPage, IDefaultMasterPresenter
    {
        public DefaultMasterPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get { throw new NotImplementedException(); }
        }

        public void ShowMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public bool IsLogged
        {
            set
            {
                if (value)
                {
                    //pnlMenuLogged.Visible = true;
                    //pnlMenuUnLogged.Visible = false;
                    //pnlMenuLoggedGame.Visible = true;
                }
                else
                {
                    //pnlMenuLogged.Visible = false;
                    //pnlMenuUnLogged.Visible = true;
                    //pnlMenuLoggedGame.Visible = false;
                }
            }
        }

        public Player PlayerLogged
        {
            set { }
        }

        public bool IsOnline
        {
            set
            {

                if (value)
                {
                    lblServerStatusOnline.Visible = true;
                    lblServerStatusOffline.Visible = false;
                    imgServerStatusOffline.Visible = false;
                    imgServerStatusOnline.Visible = true;
                }
                else
                {
                    lblServerStatusOnline.Visible = false;
                    lblServerStatusOffline.Visible = true;
                    imgServerStatusOffline.Visible = true;
                    imgServerStatusOnline.Visible = false;
                }

            }
        }
    }
}