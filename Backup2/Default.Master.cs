using System;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.Views.Pages;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class Default : MasterPage, IDefaultMasterPresenter
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
            lblError.Text = message.Description;
            pnlError.Visible = true;
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

        public bool IsLogged
        {
            set
            {
                if (value)
                {
                    pnlMenuLogged.Visible = true;
                    pnlMenuUnLogged.Visible = false;
                    pnlMenuLoggedGame.Visible = true;
                }
                else
                {
                    pnlMenuLogged.Visible = false;
                    pnlMenuUnLogged.Visible = true;
                    pnlMenuLoggedGame.Visible = false;
                }
            }

        }

        public Player PlayerLogged
        {
            set
            {
                btnPlayerInformation.Text = String.Format("{0} ", value.User.FirstNameLastName);
                btnLevel.Text = value.Level.ToString();
                btnMoney.Text = value.Money.ToString("c");
                
            }
        }

        protected void SignOutClick(object sender, EventArgs e)
        {
            Presenter.SignOut();
        }

        protected void NewTripClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.NEW_TRIP);
        }

        protected void OpenTripClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.OPEN_TRIP);
        }

        protected void ShoppingClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.SHOPPING);
        }

        protected void RankingClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.RANKING);
        }

        protected void WallClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.WALL_POST);
        }

        protected void SiteListClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.SITE_LIST);
        }

        protected void RecordClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.RECORD);
        }

        protected void HomeClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.DEFAULT);
        }

        protected void PlayerListClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.PLAYER_LIST);
        }

        protected void LoginClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.LOGIN_PAGE);
        }

        protected void CreatePlayerClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.CREATE_PLAYER);
        }

        protected void ContactUsClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.CONTACT);
        }

        protected void PlayerInformationClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.PLAYER_INFORMATION);
        }
    }
}
