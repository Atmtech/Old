using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.Administration
{
    public partial class eCommerce : PageBaseAdministration, IToolsPresenter
    {
        public ToolsPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        protected void btnChargerXmlProduitClick(object sender, EventArgs e)
        {
            Presenter.ImportProductFromXml();
        }
        protected void btnSynchroniserFichierImageClick(object sender, EventArgs e)
        {
            Presenter.SynchronizeImage(@"C:\dev\Atmtech\ATMTECH.ShoppingCart.Commerce\Images");
        }
        protected void btnSynchroniserProduitFichierClick(object sender, EventArgs e)
        {
            Presenter.SynchronizeProductFile();
        }
        protected void btnAfficherCouleurXmlClick(object sender, EventArgs e)
        {
            IList<string> couleurs = Presenter.DisplayColorFromXml();
            foreach (string couleur in couleurs)
            {
                lblCouleur.Text += "if (stock.ColorEnglish.ToLower().IndexOf(\"" + couleur + "\") > 0) return \"" +
                                   couleur + "\";" + Environment.NewLine;
            }
        }
        protected void btnCopierImageAvecMixedVersRepertoireClick(object sender, EventArgs e)
        {
            Presenter.CopierFichierImageProduitNonFormateVersProduct(@"C:\dev\Atmtech\ATMTECH.ShoppingCart.Commerce\Images");
        }

        public IList<Product> ProductWithoutStock { set; private get; }
        public IList<StockTemplate> StockTemplate { set; private get; }
        public IList<Enterprise> Enterprise { set; private get; }
        public int EnterpriseSelect { get; private set; }
        public IList<User> Users { set; private get; }
    }
}