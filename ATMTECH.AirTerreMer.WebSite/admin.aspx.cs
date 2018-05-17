using System;
using System.Web.UI.WebControls;

namespace ATMTECH.AirTerreMer.WebSite
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOkClick(object sender, EventArgs e)
        {
            if (txtUtilisateur.Text == "riov01" && txtMotPasse.Text == "10Crevette01")
            {
                pnlConnecte.Visible = false;
                pnlAuthentifie.Visible = true;
                rptReserve.DataSource = new DAOAirTerreMer().ObtenirReservation();
                rptReserve.DataBind();
            }
        }


        protected void rptReserveCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Menu")
            {
                int index = e.Item.ItemIndex;
                TextBox textBox = (TextBox)rptReserve.Items[index].FindControl("txtNomMenu");
                new DAOAirTerreMer().AjouterMenu(e.CommandArgument.ToString(), textBox.Text);
            }
        }

        protected void btnAjouterMenuClick(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation
            {
                DateReservation = Convert.ToDateTime(txtDateReservation.Text),
                Prenom = txtPrenom.Text,
                Nom = txtNom.Text,
                NomMenu = txtNomMenu.Text
            };
            new DAOAirTerreMer().AjouterReservation(reservation);

            rptReserve.DataSource = new DAOAirTerreMer().ObtenirReservation();
            rptReserve.DataBind();

        }
    }
}