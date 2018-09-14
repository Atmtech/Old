using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ATMTECH.AirTerreMer.WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IList<Reservation> obtenirReservation = new DAOAirTerreMer().ObtenirReservation();
                if (obtenirReservation.Count > 0)
                {
                    IEnumerable<Reservation> reservations = obtenirReservation.Where(x => x.DateReservation > DateTime.Now);
                    if (reservations.Any())
                    {
                        DateTime dateTime = obtenirReservation.Where(x => x.DateReservation > DateTime.Now).Min(x => x.DateReservation);
                        placeholderCompteRebour.Controls.Add(new Literal { Text = " <div class=\"countdown pt-5 mt-2\" data-due-date=\"" + dateTime.ToShortDateString() + "\" ></ div > " });
                    }
                    
                }
                
                ddlBudget.DataSource = new DAOAirTerreMer().ObtenirListeBudget();
                ddlBudget.DataBind();
                ddlNombreConvive.DataSource = new DAOAirTerreMer().ObtenirListeConvive();
                ddlNombreConvive.DataBind();
                ddlDate.DataSource = new DAOAirTerreMer().ObtenirListeDateReservation();
                ddlDate.DataValueField = "Date";
                ddlDate.DataTextField = "Affichage";
                ddlDate.DataBind();

                rptMenu.DataSource = obtenirReservation.Where(x => string.IsNullOrEmpty(x.NomMenu) == false).OrderByDescending(x => x.DateReservation).Take(12).ToList();
                rptMenu.DataBind();

                ddlPreferenceCulinaire1.DataSource = new DAOAirTerreMer().ObtenirListePreferenceCulinaire();
                ddlPreferenceCulinaire1.DataBind();

                ddlPreferenceCulinaire2.DataSource = new DAOAirTerreMer().ObtenirListePreferenceCulinaire();
                ddlPreferenceCulinaire2.DataBind();

                ddlPreferenceCulinaire3.DataSource = new DAOAirTerreMer().ObtenirListePreferenceCulinaire();
                ddlPreferenceCulinaire3.DataBind();

                ddlPreferenceCulinaire4.DataSource = new DAOAirTerreMer().ObtenirListePreferenceCulinaire();
                ddlPreferenceCulinaire4.DataBind();

                ddlPreferenceCulinaire5.DataSource = new DAOAirTerreMer().ObtenirListePreferenceCulinaire();
                ddlPreferenceCulinaire5.DataBind();

                ddlPreferenceCulinaire6.DataSource = new DAOAirTerreMer().ObtenirListePreferenceCulinaire();
                ddlPreferenceCulinaire6.DataBind();
            }
        }

        private bool EstValide()
        {
            if (string.IsNullOrEmpty(txtPrenom.Text)) return false;
            if (string.IsNullOrEmpty(txtNom.Text)) return false;
            if (string.IsNullOrEmpty(txtCourriel.Text)) return false;
            if (string.IsNullOrEmpty(txtTelephone.Text)) return false;
            if (string.IsNullOrEmpty(ddlBudget.Text)) return false;
            if (string.IsNullOrEmpty(ddlNombreConvive.Text)) return false;
            return true;
        }
        protected void btnReserverOnClick(object sender, EventArgs e)
        {
            if (EstValide())
            {


                Reservation reservation = new Reservation
                {
                    AllergieIntolerance = txtAllergie.Text,
                    BudgetEpicerieMaximal = ddlBudget.Text,
                    Courriel = txtCourriel.Text,
                    DateReservation = Convert.ToDateTime(ddlDate.SelectedValue),
                    InformationSupplementaire = txtAutreInformation.Text,
                    Nom = txtNom.Text,
                    NombreConvive = ddlNombreConvive.Text,
                    PreferenceCulinaire1 = ddlPreferenceCulinaire1.Text,
                    PreferenceCulinaire2 = ddlPreferenceCulinaire2.Text,
                    PreferenceCulinaire3 = ddlPreferenceCulinaire3.Text,
                    PreferenceCulinaire4 = ddlPreferenceCulinaire4.Text,
                    PreferenceCulinaire5 = ddlPreferenceCulinaire5.Text,
                    PreferenceCulinaire6 = ddlPreferenceCulinaire6.Text,
                    Prenom = txtPrenom.Text,
                    Telephone = txtTelephone.Text
                };
                new DAOAirTerreMer().AjouterReservation(reservation);

                txtAllergie.Text = string.Empty;
                ddlBudget.Text = string.Empty;
                txtCourriel.Text = string.Empty;

                txtAutreInformation.Text = string.Empty;
                txtNom.Text = string.Empty;
                ddlNombreConvive.Text = string.Empty;
                ddlPreferenceCulinaire1.Text = string.Empty;
                ddlPreferenceCulinaire2.Text = string.Empty;
                ddlPreferenceCulinaire3.Text = string.Empty;
                ddlPreferenceCulinaire4.Text = string.Empty;
                ddlPreferenceCulinaire5.Text = string.Empty;
                ddlPreferenceCulinaire6.Text = string.Empty;

                txtPrenom.Text = string.Empty;
                txtTelephone.Text = string.Empty;

                pnlMerci.Visible = true;
            }

        }
    }
}