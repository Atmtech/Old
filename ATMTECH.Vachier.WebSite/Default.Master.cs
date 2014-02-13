using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.Vachier.Entities;
using ATMTECH.Vachier.Views;
using ATMTECH.Vachier.Views.Interface;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.Vachier.WebSite
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

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
        public void ShowMessage(Message message)
        {

        }

        public IList<CountryIp> ListeVille
        {
            set
            {
                dataListVille.DataSource = value;
                dataListVille.DataBind();
            }
        }
        public IList<CountryIp> ListePays
        {
            set
            {
                dataListPays.DataSource = value;
                dataListPays.DataBind();
            }
        }

        public string AjouterMerde
        {
            get { return txtAjouter.Text; }
            set { txtAjouter.Text = value; }
        }

        public string RechercheMerde
        {

            get { return txtRecherche.Text; }
            set { txtRecherche.Text = value; }
        }

        public string ChierSurCelebre
        {
            get { return cboCelebre.SelectedValue; }
            set { cboCelebre.SelectedValue = value; }
        }

        public string AjouterMerdeCelebre
        {

            get { return txtProposer.Text; }
            set { txtProposer.Text = value; }
        }

        public string Insulte
        {

            get { return cboInsulte.SelectedValue; }
            set { cboInsulte.SelectedValue = value; }
        }

        public IList<Insulte> ListeInsulte
        {

            set
            {
                cboInsulte.DataTextField = BaseEntity.DESCRIPTION;
                cboInsulte.DataValueField = BaseEntity.ID;
                cboInsulte.DataSource = value;
                cboInsulte.DataBind();
            }
        }

        public IList<Merdeux> ListeMerdeux
        {

            set
            {
                cboCelebre.DataTextField = BaseEntity.DESCRIPTION;
                cboCelebre.DataValueField = BaseEntity.ID;
                cboCelebre.DataSource = value;
                cboCelebre.DataBind();
            }
        }

        protected void OnChercher(object sender, EventArgs e)
        {
            Presenter.RechercherMerde();
        }

        protected void OnAjouter(object sender, EventArgs e)
        {
            Presenter.AjouterMerde();
        }

        protected void OnAjouterCelebre(object sender, EventArgs e)
        {
            Presenter.AjouterMerdeCelebre();
        }

        protected void OnChier(object sender, EventArgs e)
        {
            Presenter.ChierSurCelebre();
        }

        protected void OnAnnulerChercher(object sender, EventArgs e)
        {
            Presenter.AnnulerRecherche();
        }

    }
}