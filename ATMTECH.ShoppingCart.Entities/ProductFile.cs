using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class ProductFile : BaseEntity
    {

        public const string PRODUCT = "Product";
        public const string FILE = "File";

        public Product Product { get; set; }
        public File File { get; set; }
        public bool IsPrincipal { get; set; }
        public Product ProductLinked { get; set; }

        public string ComboboxDescriptionUpdate { get { return File == null ? "" : File.FileName; } }
    }
}
