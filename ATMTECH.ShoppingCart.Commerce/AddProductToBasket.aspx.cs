using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class AddProductToBasket : PageBaseShoppingCart<AddProductToBasketPresenter, IAddProductToBasketPresenter>, IAddProductToBasketPresenter
    {
        public string IdProduct { get; set; }
        public Product Product { get; set; }
        public bool IsOrderable { set; private get; }
        public int IsSuccesfullyAdded { set; private get; }
        public bool IsOrderableAgainstSecurity { get; set; }
        public bool IsOrderLocked { set; private get; }

        protected void imgProductPrincipalClick(object sender, ImageClickEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void AddToBasketClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void StockDataBound(object sender, DataListItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void StockAddCommand(object source, DataListCommandEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}