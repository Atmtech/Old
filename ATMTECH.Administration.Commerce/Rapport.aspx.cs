using System;
using ATMTECH.Administration.Views.Francais;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Web;

namespace ATMTECH.Administration.Commerce
{
    public partial class Rapport : PageBase<RapportPresenter, IRapportPresenter>, IRapportPresenter
    {
        public string TitreRapport
        {
            set { lblTitre.Text = value; }
        }

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

        public int NoCommande
        {
            get { return Convert.ToInt32(txtNoCommande.Text); }
        }

        public Enterprise Entreprise
        {
            get
            {
                if ((Enterprise)Session["Enterprise"] == null)
                {
                    Session["Enterprise"] = new Enterprise { Id = 1 };
                }


                return (Enterprise)Session["Enterprise"];
            }
        }

        public string ResultatValidationPayPal
        {
            set { lblResultatValidationPayPal.Text = value; }
        }


        protected void btnGenererClick(object sender, EventArgs e)
        {
            Presenter.GenererRapport();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (NomRapport)
            {
                case "UneCommande":
                    pnlRapportAvecDate.Visible = false;
                    pnlRapportUneCommande.Visible = true;
                    break;
                default:
                    pnlRapportAvecDate.Visible = true;
                    pnlRapportUneCommande.Visible = false;
                    break;
            }
        }
    }
}