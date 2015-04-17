using System;
using ATMTECH.Administration.Views.Francais;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Web;

namespace ATMTECH.Administration.Commerce
{
    public partial class Rapport : PageBase<RapportPresenter, IRapportPresenter>, IRapportPresenter
    {
        public string NomRapport
        {
            get { return QueryString.GetQueryStringValue("rapport"); }
        }


        public DateTime DateDepart
        {
            get { return Convert.ToDateTime(txtDateDepart.Text); }
        }

        public DateTime DateFin
        {
            get { return Convert.ToDateTime(txtDateFin.Text); }
        }

        protected void btnGenererClick(object sender, EventArgs e)
        {
            Presenter.GenererRapport();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (NomRapport)
            {
                case "VenteParProduit":
                    pnlRapportAvecDate.Visible = true;
                    pnlRapportUneCommande.Visible = false;
                    break;
                case "UneCommande":
                    pnlRapportAvecDate.Visible = false;
                    pnlRapportUneCommande.Visible = true;
                    break;
                case "ListeCommande":
                    pnlRapportAvecDate.Visible = true;
                    pnlRapportUneCommande.Visible = false;
                    break;
            }
        }

    }
}