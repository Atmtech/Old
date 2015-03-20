using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ListeProduit : UserControl
    {
        public string Langue { get; set; }
        public int ProduitParRangee { get { return dataListListeProduitEnVente.RepeatColumns; } set { dataListListeProduitEnVente.RepeatColumns = value; } }
        public IList<Product> Produits
        {
            get { return (IList<Product>)dataListListeProduitEnVente.DataSource; }
            set
            {
                dataListListeProduitEnVente.DataSource = value;
                dataListListeProduitEnVente.DataBind();
            }
        }


    }
}