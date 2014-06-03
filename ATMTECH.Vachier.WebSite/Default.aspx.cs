using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Vachier.Entities;
using ATMTECH.Vachier.Views;
using ATMTECH.Vachier.Views.Interface;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.Vachier.WebSite
{
    public partial class Default : PageBaseVachier<Default2Presenter, IDefault2Presenter>, IDefault2Presenter
    {
        protected void btnChercherClick(object sender, EventArgs e)
        {
            CacherTout();
            Presenter.RechercherMerde();
        }

        protected void btnEmmerderClick(object sender, EventArgs e)
        {
            CacherTout();
            Presenter.AjouterMerde();
        }

        protected void btnAjouterClick(object sender, EventArgs e)
        {
            CacherTout();
            pnlAjouter.Visible = true;
        }

        private void CacherTout()
        {
            pnlAjouter.Visible = false;
            pnlCherche.Visible = false;
        }
        protected void btnChercheClick(object sender, EventArgs e)
        {
            CacherTout();
            pnlCherche.Visible = true;
        }

        protected void btnAjouterCelebreClick(object sender, EventArgs e)
        {
            CacherTout();
        }

        protected void datalistTopItemCommandClick(object source, DataListCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void datalistMerdeItemCommandClick(object source, RepeaterCommandEventArgs repeaterCommandEventArgs)
        {
            if (repeaterCommandEventArgs.CommandName == "JaimeTaMerde")
            {
                Presenter.JaimeTaMerde(Convert.ToInt32(repeaterCommandEventArgs.CommandArgument));
            }
        }

        public IList<Entities.Vachier> Liste
        {
            set
            {
                datalistMerde.DataSource = value;
                datalistMerde.DataBind();
            }
        }
        public IList<Entities.Vachier> ListeTop
        {
            set
            {
                datalistTop.DataSource = value;
                datalistTop.DataBind();
            }
        }
        public Entities.Vachier MerdeDuMoment
        {
            set
            {
                lblMerdeDuMoment.Text = value.Description + " " + value.Insulte.Description;
                lblMerdeDuMomentDate.Text = value.DateCreated.ToString("D", CultureInfo.CreateSpecificCulture("fr-CA"));

            }
        }

        public string AjouterMerde
        {
            get { return txtMerdeux.Text; }
            set { txtMerdeux.Text = value; }
        }

        public string Insulte
        {

            get { return ddlInsulte.SelectedValue; }
            set { ddlInsulte.SelectedValue = value; }
        }

        public string RechercheMerde { get { return txtChercher.Text; } set { txtChercher.Text = value; } }


        public int CompteTotal
        {
            set
            {
                ddlListePage.Items.Clear();
                int totalPage = value / Convert.ToInt32(ddlNombreParPage.SelectedValue);
                // int page = 1;
                for (int i = totalPage; i >= 0; --i)
                {
                    if (i == 0) continue;
                    ListItem listItem = new ListItem { Value = i.ToString(), Text = i.ToString() };
                    ddlListePage.Items.Add(listItem);
                }
            }
        }
        public string TotalMarde { set { lblTotalMarde.Text = value; } }
        public IList<Insulte> ListeInsulte
        {

            set
            {
                ddlInsulte.DataTextField = BaseEntity.DESCRIPTION;
                ddlInsulte.DataValueField = BaseEntity.ID;
                ddlInsulte.DataSource = value;
                ddlInsulte.DataBind();
            }
        }

        public IList<Merdeux> ListeMerdeux
        {

            set
            {
                //cboCelebre.DataTextField = BaseEntity.DESCRIPTION;
                //cboCelebre.DataValueField = BaseEntity.ID;
                //cboCelebre.DataSource = value;
                //cboCelebre.DataBind();
            }
        }

        public IList<CountryIp> ListeVille
        {
            set
            {
                dataListVille.DataSource = value;
                dataListVille.DataBind();
            }
        }

        public int NombreParPage { get { return Convert.ToInt32(ddlNombreParPage.SelectedValue); } }
        public int PageCourante { get { return Convert.ToInt32(ddlListePage.SelectedValue); } }

        public IList<CountryIp> ListePays
        {
            set
            {
                dataListPays.DataSource = value;
                dataListPays.DataBind();
            }
        }

        protected void ddlListePageSelectedIndexChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(ddlListePage.SelectedValue);
            Liste = Presenter.ObtenirListe(page, Convert.ToInt32(ddlNombreParPage.SelectedValue));
        }


    }
}