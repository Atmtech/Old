using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Commerce.UserControls
{
    public partial class ListeProduit : UserControl
    {
        public bool AfficherBoutonTriEtNombreItem
        {
            get { return pnlBoutonTriNombreElement.Visible; }
            set
            {
                pnlBoutonTriNombreElement.Visible = value;
            }
        }
        public string Langue { get; set; }
        public int ProduitParRangee { get { return dataListListeProduitEnVente.RepeatColumns; } set { dataListListeProduitEnVente.RepeatColumns = value; } }
        public IList<Product> Produits
        {
            get { return (IList<Product>)Session["ListeProduitParCategorie"]; }
            set
            {
                Session["ListeProduitParCategorie"] = value;
                lblNombreElement.Text = value.Count.ToString();
                dataListListeProduitEnVente.DataSource = ObtenirListeProduitTrier(value);
                dataListListeProduitEnVente.DataBind();
            }
        }
        public string Tri { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(lblNombreElement.Text, out n))
            {
                lblNombreElement.Text = "0";
            }


        }

        private IList<Product> ObtenirListeProduitTrier(IList<Product> produits)
        {
            if (!string.IsNullOrEmpty(Tri))
            {
                switch (Tri)
                {
                    case "HighToLow":
                        return produits.OrderByDescending(x => x.UnitPrice).ToList();
                    case "LowToHigh":
                        return produits.OrderBy(x => x.UnitPrice).ToList();
                }
                return produits;
            }
            else
            {
                return produits;
            }
        }

        protected void btnTrierMoinsChereAuPlusChereClick(object sender, EventArgs e)
        {
            Tri = "LowToHigh";
            Produits = Produits;
        }

        protected void btnTrierDuPlusChereAuMoinsChereClick(object sender, EventArgs e)
        {
            Tri = "HighToLow";
            Produits = Produits;
        }
    }
}