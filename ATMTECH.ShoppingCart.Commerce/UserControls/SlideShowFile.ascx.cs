using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Commerce.UserControls
{
    public partial class SlideShowFile : UserControl
    {
        public IList<ProductFile> Fichiers
        {
            get { return (IList<ProductFile>)Session["ListeFichier"]; }
            set
            {
                if (value != null)
                {
                    Session["ListeFichier"] = value;
                }
            }
        }
        public void AfficherListeFichier(IList<ProductFile> productFiles)
        {
            Fichiers = productFiles;
            dataListeFichier.DataSource = productFiles;
            dataListeFichier.DataBind();
        }
        public void AfficherImagePrincipale(string image)
        {
            const double hauteurMaximale = 650;
            const double largeurMaximale = 420;
            string mapPath = Server.MapPath(image);
            System.Drawing.Image img = System.Drawing.Image.FromFile(mapPath);
            imgPrincipale.ImageUrl = image;
            double width = img.Width;
            double height = img.Height;

            double nouvelleLargeur = hauteurMaximale * width / height;
            double nouvelleHauteur = largeurMaximale * height / width;
            if (nouvelleLargeur > largeurMaximale)
            {
                imgPrincipale.Width = new Unit(largeurMaximale, UnitType.Pixel);
                imgPrincipale.Height = new Unit(nouvelleHauteur, UnitType.Pixel);
            }
            else
            {
                imgPrincipale.Width = new Unit(nouvelleLargeur, UnitType.Pixel);
                imgPrincipale.Height = new Unit(hauteurMaximale, UnitType.Pixel);
            }



            //imgPrincipale.CssClass = img.Width > 420 ? "imagePrincipaleMaximale" : "imagePrincipaleAvecPadding";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Fichiers == null) return;

            if (!Page.IsPostBack)
            {
                if (Fichiers.Count > 0)
                {
                    AfficherImagePrincipale("~/Images/Product/" + Fichiers.FirstOrDefault(x => x.IsPrincipal).File.FileName);
                    AfficherListeFichier(Fichiers);
                }
            }
        }
        protected void dataListeFichierItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AfficherImage")
            {
                AfficherImagePrincipale(e.CommandArgument.ToString());
                AfficherListeFichier(Fichiers);
            }
        }
    }
}