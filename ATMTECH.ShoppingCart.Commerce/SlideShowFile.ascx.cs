using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class SlideShowFile : UserControl
    {
        public string Langue { get; set; }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Fichiers == null) return;

            if (!Page.IsPostBack)
            {
                AfficherImagePrincipale("Images/Product/" + Fichiers.FirstOrDefault(x => x.IsPrincipal).File.FileName);

                AfficherListeFichier();
            }

        }

        protected void dataListeFichierItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AfficherImage")
            {
                AfficherImagePrincipale(e.CommandArgument.ToString());
                AfficherListeFichier();
            }
        }

        public void AfficherListeFichier()
        {
            dataListeFichier.DataSource = Fichiers;
            dataListeFichier.DataBind();
        }

        public void AfficherImagePrincipale(string image)
        {
            string mapPath = Server.MapPath(image);
            System.Drawing.Image img = System.Drawing.Image.FromFile(mapPath);
            imgPrincipale.CssClass = img.Width > 420 ? "imagePrincipaleMaximale" : "imagePrincipaleAvecPadding";
            imgPrincipale.ImageUrl = image;
        }
    }
}