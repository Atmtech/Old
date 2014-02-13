using System;
using System.IO;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class PlayerInformation : PageBaseFishingAtWork, IPlayerInformationPresenter
    {
        public PlayerInformationPresenter Presenter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public string Name
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
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

        public string Image
        {
            get { return imgAvatar.ImageUrl; }
            set { imgAvatar.ImageUrl = value; }
        }

        public string Login
        {
            get { return txtLogin.Text; }
            set { txtLogin.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        protected void SavePlayerClick(object sender, EventArgs e)
        {
            Presenter.SavePlayer();
            pnlChangePassword.Visible = false;
            lblCustomerInformationSaved.Visible = true;
        }

        protected void ChangePassword_click(object sender, EventArgs e)
        {
            pnlChangePassword.Visible = true;
        }

        protected void ChangeAvatarClick(object sender, EventArgs e)
        {
            windowUpload.OuvrirFenetre();
        }

        protected void StatisticClick(object sender, EventArgs e)
        {
          
        }

        protected void AchievementClick(object sender, EventArgs e)
        {
          
        }

        protected void SkillsClick(object sender, EventArgs e)
        {


        }

        protected void UpdateAvatarClick(object sender, EventArgs e)
        {
            // TODO: Remettre ca dans le presenter ... Avec les Bytes.
            string guid = Guid.NewGuid().ToString();
            if (fileUpload.FileBytes.Length < 50000)
            {
                File.Delete(MapPath(Image));
                Image = guid + fileUpload.FileName;
                
                fileUpload.SaveAs(MapPath("/images/Player/" + guid + fileUpload.FileName));
            }
            Presenter.SavePlayer();
            Presenter.NavigationService.Refresh();
        }
    }
}