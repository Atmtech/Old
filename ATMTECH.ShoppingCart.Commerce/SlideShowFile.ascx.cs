using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class SlideShowFile : System.Web.UI.UserControl
    {
        public string Langue { get; set; }
        public IList<ProductFile> Fichiers { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string html = string.Empty;
            if (Fichiers == null) return;
            IList<ProductFile> orderedEnumerable = Fichiers.OrderByDescending(x => x.IsPrincipal).ToList();
            foreach (ProductFile productFile in orderedEnumerable)
            {
                html += "<div style='background-color: white;'>";
                html += "   <div style='text-align: center;'>";
                html += "       <img u='image' src='Images/Product/" + productFile.File.FileName + "' />";
                html += "   </div>";
                html += "   <img u='thumb' src='Images/Product/" + productFile.File.FileName + "' />";
                html += "</div>";
            }

            Literal literal = new Literal { Text = html };
            placeHolder.Controls.Add(literal);
        }
    }
}