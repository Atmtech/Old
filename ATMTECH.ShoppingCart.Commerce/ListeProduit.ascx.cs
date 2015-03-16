using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ListeProduit : UserControl
    {
        public string Langue { get; set; }
        public IList<Product> Produits { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            dataListListeProduitEnVente.DataSource = Produits;
            dataListListeProduitEnVente.DataBind();
        }
    }
}