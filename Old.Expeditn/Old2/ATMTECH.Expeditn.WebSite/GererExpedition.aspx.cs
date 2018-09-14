using System;
using System.Collections.Generic;
using System.Web;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class GererExpedition : PageBase<GererExpeditionPresenter, IGererExpeditionPresenter>, IGererExpeditionPresenter
    {
        public string IdExpedition { get { return QueryString.GetQueryStringValue(BaseEntity.ID); } }
        public string Nom { get { return txtNomExpedition.Text; } set { txtNomExpedition.Text = value; } }
        public DateTime Debut
        {
            get { return Convert.ToDateTime(txtDebutExpedition.Text); }
            set { txtDebutExpedition.Text = value.ToString(); }
        }
        public DateTime Fin
        {
            get { return Convert.ToDateTime(txtFinExpedition.Text); }
            set { txtFinExpedition.Text = value.ToString(); }
        }
        public decimal BudgetEstime { get { return string.IsNullOrEmpty(txtBudgetEstimeExpedition.Text) ? 0 : Convert.ToDecimal(txtBudgetEstimeExpedition.Text); } set { txtBudgetEstimeExpedition.Text = value.ToString(); } }
        public string Longitude { get { return txtLongitude.Text; } set { txtLongitude.Text = value; } }
        public string Latitude { get { return txtLatitude.Text; } set { txtLatitude.Text = value; } }
        public string Region { get { return txtRegionExpedition.Text; } set { txtRegionExpedition.Text = value; } }
        public string Pays { get { return ddlPays.SelectedValue; } set { ddlPays.SelectedValue = value; } }
        public string Ville { get { return txtVilleExpedition.Text; } set { txtVilleExpedition.Text = value; } }
        public string RootPath { get { return Server.MapPath(""); } }
        public string Image { set { imgExpedition.ImageUrl = value; } }

        public bool EstExpeditionPrive
        {
            get
            {
                return ddlEstPrive.SelectedValue == "1";
            }
            set
            {
                if (value)
                    ddlEstPrive.SelectedValue = "1";
                else
                {
                    ddlEstPrive.SelectedValue = "0";
                }
            }
        }

        public IList<Pays> ListePays
        {
            set
            {
                FillDropDown(ddlPays, value);
            }
        }

        protected void lnkEnregistrerExpeditionClick(object sender, EventArgs e)
        {
            Presenter.EnregistrerExpedition();
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