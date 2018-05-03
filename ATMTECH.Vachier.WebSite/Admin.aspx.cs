using System;

namespace ATMTECH.Vachier.WebSite
{
    public partial class Admin : PageBase
    {

        public int Depart
        {
            get
            {
                if (Session["Depart"] == null) Session["Depart"] = 0;
                return (int) Session["Depart"];
            }
            set {  Session["Depart"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAjouterInsulteOnClick(object sender, EventArgs e)
        {
            //Insulte insulte = new Insulte
            //{
            //    DateCreation = DateTime.Now,
            //    Description = "Ta mere est une salope",
            //    Localisation = DAOLogger.ObtenirInformationLocalisation("31.13.71.36"),
            //    Titre = "Titre"
            //};
            new DAOVachier().AjouterInsulte("Le titre","Description");
        }

        protected void btnAfficherInsulteOnClick(object sender, EventArgs e)
        {
            GridView1.DataSource = new DAOVachier().ObtenirInsulte(0);
            GridView1.DataBind();
        }

        protected void btnConvertirOnClick(object sender, EventArgs e)
        {
            new DAOVachier().ConvertirAncienVersNouveau(txtConnectionString.Text);

        }

        protected void btnAfficherProchainOnClick(object sender, EventArgs e)
        {
            
            GridView1.DataSource = new DAOVachier().ObtenirInsulte(Depart);
            GridView1.DataBind();
            Depart += 10;
        }

        protected void btnDropOnClick(object sender, EventArgs e)
        {
            new DAOVachier().SupprimerCollectionInsulte();
        }

        protected void btnDropLocalisationOnClick(object sender, EventArgs e)
        {
            new DAOVachier().SupprimerCollectionLocalisation();
        }
    }
}