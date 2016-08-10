using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.GoogleMap;

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
        public decimal BudgetEstime { get { return Convert.ToDecimal(txtBudgetEstimeExpedition.Text); } set { txtBudgetEstimeExpedition.Text = value.ToString(); } }
        public string Longitude { get { return txtLongitude.Text; } set { txtLongitude.Text = value; } }
        public string Latitude { get { return txtLatitude.Text; } set { txtLatitude.Text = value; } }
        public string Region { get { return txtRegionExpedition.Text; } set { txtRegionExpedition.Text = value; } }
        public string Pays { get { return ddlPays.SelectedValue; } set { ddlPays.SelectedValue = value; } }
        public string Ville { get { return txtVilleExpedition.Text; } set { txtVilleExpedition.Text = value; } }

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

        protected void lnkPasserEtape2CreationExpeditionClick(object sender, EventArgs e)
        {
            int idExpedition = Presenter.EnregistrerExpedition();
            Presenter.RedirigerPageGererParticipant(idExpedition);
        }

    }
}