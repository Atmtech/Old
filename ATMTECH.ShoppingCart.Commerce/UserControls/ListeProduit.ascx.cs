using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using Image = System.Web.UI.WebControls.Image;

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
                if (value != null)
                {
                    lblNombreElement.Text = value.Count.ToString();
                    dataListListeProduitEnVente.DataSource = ObtenirListeProduitTrier(value);
                    dataListListeProduitEnVente.DataBind();
                }
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

        protected void dataListListeProduitEnVenteOnItemDataBound(object sender, DataListItemEventArgs e)
        {
            Image image = e.Item.FindControl("imageProduit") as Image;
            if (image != null)
            {
                string imageUrl = image.ImageUrl;
                Bitmap bitmap = new Bitmap(Server.MapPath(imageUrl));

                double width = bitmap.Width;
                double height = bitmap.Height;

                double nouvelleUnite = 200 * width / height;
                if (nouvelleUnite > 200)
                    nouvelleUnite = 200;
                image.Width = new Unit(nouvelleUnite, UnitType.Pixel);
                image.Height = new Unit(200, UnitType.Pixel);
            }
        }
    }
}