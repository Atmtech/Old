using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Administration
{
    public partial class RapportCimaAncien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRapportClick(object sender, EventArgs e)
        {
            string conn = "Data Source=ATMTECH-HOST;Initial Catalog=sagacemarchand;Persist Security Info=True;User ID=sagacemarchand;Password=10sagacemarchand01";
           // string conn = @"Data Source=.\entrepot;Initial Catalog=EdGestionLocal;Integrated security=SSPI;Trusted_Connection=True;";
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string sql = "select actif,identifiant_produit, nom_produit, sum(quantite) as Quantite_Commande from ligne_commande ";
            sql += "inner join commande on commande.no_commande = ligne_commande.no_commande and commande.no_entreprise = 11 and commande.date_commande between '" + txtDepart.Text + "' and '" + txtFin.Text + "' ";
            sql += "inner join produit on produit.no_produit = ligne_commande.no_produit and produit.no_entreprise = 11 ";
            sql += "group by actif,produit.nom_produit, produit.identifiant_produit ";
            sql += "union ";
            sql += "SELECT actif,identifiant_produit, nom_produit, 0 as Quantite_Commande from produit ";
            sql += "WHERE no_produit not in (SELECT ligne_commande.no_produit FROM ligne_commande ";
            sql += "inner join commande on commande.no_commande = ligne_commande.no_commande and commande.no_entreprise = 11 and commande.date_commande between '" + txtDepart.Text + "' and '" + txtFin.Text + "') ";
            sql += "and produit.no_entreprise = 11 ";

            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection)
                {
                    CommandType = CommandType.Text
                };

            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            grdTest.DataSource = dataSet;
            grdTest.DataBind();
        }
    }
}