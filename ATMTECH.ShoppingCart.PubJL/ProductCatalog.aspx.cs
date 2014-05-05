using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.PubJL
{
    public partial class ProductCatalog : PageBaseShoppingCart<ProductCatalogPresenter, IProductCatalogPresenter>, IProductCatalogPresenter
    {

        public IList<ProductCategory> ProductCategories
        {
            set
            {
                if (value.Count == 0)
                {
                    pnlNoCategory.Visible = true;
                }

                foreach (ProductCategory productCategory in value)
                {
                    Literal htmlCategoryName = new Literal();
                    htmlCategoryName.Text = "<div class='titleProduct'><strong>" + productCategory.Description + "</strong></div>";
                    placeHolderProduct.Controls.Add(htmlCategoryName);

                    IList<Product> products = Presenter.GetProductCategory(productCategory.Id).OrderBy(x => x.OrderId).ToList();

                    if (products.Count == 0)
                    {
                        Label label = new Label
                                          {
                                              ID = "lblNoProductForThisCategory",
                                              Text = Session["currentLanguage"].ToString().Equals("fr")
                                                                               ? "Aucun produit pour cette catégorie<br>"
                                                                               : "No product for this category<br>"
                                          };
                        placeHolderProduct.Controls.Add(label);
                    }
                    else
                    {
                        foreach (Product product in products)
                        {
                            string header = "<a href='AddProductToBasket.aspx?" + PagesId.PRODUCT_ID + "=" + product.Id + "'><div class='tile double-vertical double image outline-color-white'>";
                            string image = "<div class='tile-content'><img src='" + product.PrincipalFileUrl + "'></div>";
                            string name = Session["currentLanguage"].ToString().Equals("fr")
                                     ? product.NameFrench
                                     : product.NameEnglish;
                            string productDisplay = product.Ident + " " + name + " " + product.UnitPrice.ToString("C");
                            string brand = "<div class='brand bg-color-button-product' style='height:45px;width:500px;'><div style='font-size:12px;padding: 3px 3px 3px 3px;font-weight:bold;'>" + Utils.Web.Pages.RemoveHtmlTag(productDisplay) + "</div></div>";
                            string footer = "</div></a>";
                            Literal literal = new Literal { Text = header + image + brand + footer };
                            placeHolderProduct.Controls.Add(literal);
                        }

                        Literal htmlClearFix = new Literal { Text = "<div class='clearfix'></div>" };
                        placeHolderProduct.Controls.Add(htmlClearFix);
                    }
                }
            }
        }


    }
}