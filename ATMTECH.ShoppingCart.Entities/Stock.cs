using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public partial class Stock : BaseEntity
    {
        public const string PRODUCT = "Product";
        public const string FEATURE = "Feature";
        public const string FEATURE_FRENCH = "ComboboxDescriptionWithoutProductNameFrench";
        public const string FEATURE_ENGLISH = "ComboboxDescriptionWithoutProductNameEnglish";
        public const string COLOR_ENGLISH = "ColorEnglish";
        public const string COLOR_FRENCH = "ColorFrench";
        public const string SIZE = "Size";


        public Product Product { get; set; }
        public int InitialState { get; set; }
        public int MinimumAccept { get; set; }
        public bool IsWarningOnLow { get; set; }
        public string FeatureFrench { get; set; }
        public string FeatureEnglish { get; set; }
        public decimal AdjustPrice { get; set; }
        public IList<StockTransaction> Transactions { get; set; }
        public bool IsWithoutStock { get; set; }
        public bool IsBackOrder { get; set; }
        public string ColorEnglish { get; set; }
        public string ColorFrench { get; set; }
        public string Size { get; set; }

        public string ComboboxDescriptionUpdate { get { return Product == null ? "" : Product.NameFrench + " " + FeatureFrench + " " + Product.Ident; } }

        public string ComboboxDescriptionWithoutProductNameFrench
        {
            get { return FeatureFrench; }
        }

        public string ComboboxDescriptionWithoutProductNameEnglish
        {
            get { return FeatureEnglish; }
        }
    }
}
