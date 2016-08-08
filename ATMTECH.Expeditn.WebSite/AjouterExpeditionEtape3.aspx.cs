using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class AjouterExpeditionEtape3 : PageBase<AjouterExpeditionEtape3Presenter, IAjouterExpeditionEtape3Presenter>, IAjouterExpeditionEtape3Presenter
    {
        public string IdExpedition
        {
            get { return QueryString.GetQueryStringValue(BaseEntity.ID); }
        }

        public IList<Etape> ListeEtape { get; set; }
        public IList<Vehicule> ListeVehicule { set { FillDropDown(ddlVehicule, value); } }
        public string IdVehicule { get { return ddlVehicule.SelectedValue; } }
        public string Nom { get { return txtNomEtape.Text; } set { txtNomEtape.Text = value; } }
        public DateTime Debut { get { return Convert.ToDateTime(txtDebutEtape.Text); } set { txtDebutEtape.Text = value.ToString(); } }
        public DateTime Fin { get { return Convert.ToDateTime(txtFinEtape.Text); } set { txtFinEtape.Text = value.ToString(); } }
        public string Distance { get { return txtDistance.Text; } set { txtDistance.Text = value; } }

        protected void lnkPasserEtape4CreationExpeditionClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void lnkAjouterActiviteExpeditionClick(object sender, EventArgs e)
        {
            Presenter.AjouterActivite();
        }
    }
}