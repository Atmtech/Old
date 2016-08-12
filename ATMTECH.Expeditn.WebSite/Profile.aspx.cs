using System;
using System.Web;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Profile : PageBase<ProfilePresenter, IProfilePresenter>, IProfilePresenter
    {
      
        protected void lnkEnregistrerUtilisateurClick(object sender, EventArgs e)
        {
            Presenter.Enregistrer();
        }

        public string Nom { get { return txtLastName.Text; } set { txtLastName.Text = value; } }
        public string Prenom { get { return txtFirstName.Text; } set { txtFirstName.Text = value; } }
        public string Courriel { get { return txtEmail.Text; } set { txtEmail.Text = value; } }
        public string MotPasse { get { return txtPassword.Text; } set { txtPassword.Text = value; } }
        public string RootPath { get { return Server.MapPath(""); } }

        public string Image
        {
            set
            {
                imgUtilisateur.ImageUrl = value;
            }
        }

        protected void lnkChangerImageClick(object sender, EventArgs e)
        {
            SaveImageFile();
        }

        public void SaveImageFile()
        {
            try
            {
                HttpFileCollection hfc = Request.Files;
                string files = string.Empty;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile httpPostedFile = hfc[i];
                    if (httpPostedFile.ContentLength > 0)
                    {
                        Presenter.EnregistrerImage(httpPostedFile);
                        //files +=
                        //    string.Format(
                        //        "<b>Fichier: </b>{0} <b>Taille:</b> {1} <b>Type:</b> {2} Transfert réussi <br/>",
                        //        httpPostedFile.FileName, httpPostedFile.ContentLength, httpPostedFile.ContentType);
                    }
                }

               // lblTransferedFile.Text = files;
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
        }
    }
}