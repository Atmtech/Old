using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Commerce.UserControls
{
    public partial class SelectionnerAdresse : UserControl
    {
        public string AdresseLongue
        {
            get
            {
                return txtAdresse.Text;
                //if (Session["AdresseLongue" + ID] == null)
                //{
                //    Session["AdresseLongue" + ID] = string.Empty;
                //}
                //return Session["AdresseLongue" + ID].ToString();
            }
            set
            {
                txtAdresse.Text = value;
                //Session["AdresseLongue" + ID] = value;
            }
        }
        public string CodePostal
        {
            get
            {
                if (Session["CodePostal" + ID] == null)
                {
                    Session["CodePostal" + ID] = string.Empty;
                }
                return Session["CodePostal" + ID].ToString();
            }
            set
            {
                Session["CodePostal" + ID] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdAdresseRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectionnerAdresse")
            {
                AdresseLongue = e.CommandArgument.ToString();
                GoogleMapService google = new GoogleMapService();
                CodePostal = google.Rechercher(AdresseLongue)[0].CodePostal;
                grdAdresse.Visible = false;
            }
        }

        protected void btnRechercherClick(object sender, EventArgs e)
        {
            GoogleMapService google = new GoogleMapService();
            IList<GoogleAdresse> googleAdresses = google.Rechercher(txtAdresse.Text).Take(10).ToList();
            grdAdresse.Visible = true;
            grdAdresse.DataSource = googleAdresses;
            grdAdresse.DataBind();
        }
    }
}