using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Administration.Services
{
    public class ImportXmlService : BaseService, IImportXmlService
    {
        public IProductService ProductService { get; set; }
        public IStockService StockService { get; set; }

        private string TrouverCategorieAnglaise(ImportProduit importProduit)
        {
            string categorieAnglaise = string.Empty;
            if (importProduit.Category1.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category1)) categorieAnglaise = importProduit.Category1;
            if (importProduit.Category2.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category2)) categorieAnglaise += "/" + importProduit.Category2;
            if (importProduit.Category3.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category3)) categorieAnglaise += "/" + importProduit.Category3;
            if (importProduit.Category4.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category4)) categorieAnglaise += "/" + importProduit.Category4;
            if (importProduit.Category5.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category5)) categorieAnglaise += "/" + importProduit.Category5;
            return categorieAnglaise;
        }


        private string TrouverCategorieFrancaise(ImportProduit importProduit)
        {
            string categorieFrancais = string.Empty;
            if (importProduit.Category1.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category1)) categorieFrancais = TraductionCategorie(importProduit.Category1);
            if (importProduit.Category2.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category2)) categorieFrancais += "/" + TraductionCategorie(importProduit.Category2);
            if (importProduit.Category3.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category3)) categorieFrancais += "/" + TraductionCategorie(importProduit.Category3);
            if (importProduit.Category4.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category4)) categorieFrancais += "/" + TraductionCategorie(importProduit.Category4);
            if (importProduit.Category5.ToLower() != "zcatalog" && !string.IsNullOrEmpty(importProduit.Category5)) categorieFrancais += "/" + TraductionCategorie(importProduit.Category5);
            return categorieFrancais;
        }

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = new Random().NextDouble();
            return minValue + (next * (maxValue - minValue));
        }

        public IList<string> DisplayColor(Enterprise enterprise, string fileXml)
        {
            IList<ImportProduit> importProduits = new List<ImportProduit>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileXml);

            if (xmlDoc.DocumentElement == null) return null;
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/root/item");

            if (nodeList != null)
                foreach (ImportProduit importProduit in from XmlNode node in nodeList
                                                        select new ImportProduit
                                                        {
                                                            // ReSharper disable PossibleNullReferenceException
                                                            ItemID = node.SelectSingleNode("ItemID").InnerText,
                                                            Brand = node.SelectSingleNode("Brand").InnerText,
                                                            Size = node.SelectSingleNode("Size").InnerText,
                                                            ColorId = node.SelectSingleNode("ColorId").InnerText,
                                                            Color_EN = node.SelectSingleNode("Color_EN").InnerText,
                                                            Color_FR = node.SelectSingleNode("Color_FR").InnerText,
                                                            Title_EN = node.SelectSingleNode("Title_EN").InnerText,
                                                            Title_FR = node.SelectSingleNode("Title_FR").InnerText,
                                                            Desc_EN = node.SelectSingleNode("Desc_EN").InnerText,
                                                            Desc_FR = node.SelectSingleNode("Desc_FR").InnerText,
                                                            Sex = node.SelectSingleNode("Sex").InnerText,
                                                            Category1 = node.SelectSingleNode("Category1").InnerText,
                                                            Category2 = node.SelectSingleNode("Category2").InnerText,
                                                            Category3 = node.SelectSingleNode("Category3").InnerText,
                                                            Category4 = node.SelectSingleNode("Category4").InnerText,
                                                            Category5 = node.SelectSingleNode("Category5").InnerText
                                                            // ReSharper restore PossibleNullReferenceException
                                                        })
                {
                    importProduits.Add(importProduit);
                }

            IList<string> couleur = new List<string>();
            foreach (ImportProduit importProduit in importProduits)
            {
                if (!couleur.Contains(importProduit.Color_EN.ToLower()))
                {
                    couleur.Add(importProduit.Color_EN.ToLower());
                }
            }
            return couleur;
        }
        public void ImportProductAndStockXml(Enterprise enterprise, string fileXml)
        {
            IList<ImportProduit> importProduits = new List<ImportProduit>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileXml);

            if (xmlDoc.DocumentElement == null) return;
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/root/item");

            if (nodeList != null)
                foreach (ImportProduit importProduit in from XmlNode node in nodeList
                                                        select new ImportProduit
                                                            {
                                                                // ReSharper disable PossibleNullReferenceException
                                                                ItemID = node.SelectSingleNode("ItemID").InnerText,
                                                                Brand = node.SelectSingleNode("Brand").InnerText,
                                                                Size = node.SelectSingleNode("Size").InnerText,
                                                                ColorId = node.SelectSingleNode("ColorId").InnerText,
                                                                Color_EN = node.SelectSingleNode("Color_EN").InnerText,
                                                                Color_FR = node.SelectSingleNode("Color_FR").InnerText,
                                                                Title_EN = node.SelectSingleNode("Title_EN").InnerText,
                                                                Title_FR = node.SelectSingleNode("Title_FR").InnerText,
                                                                Desc_EN = node.SelectSingleNode("Desc_EN").InnerText,
                                                                Desc_FR = node.SelectSingleNode("Desc_FR").InnerText,
                                                                Sex = node.SelectSingleNode("Sex").InnerText,
                                                                Category1 = node.SelectSingleNode("Category1").InnerText,
                                                                Category2 = node.SelectSingleNode("Category2").InnerText,
                                                                Category3 = node.SelectSingleNode("Category3").InnerText,
                                                                Category4 = node.SelectSingleNode("Category4").InnerText,
                                                                Category5 = node.SelectSingleNode("Category5").InnerText
                                                                // ReSharper restore PossibleNullReferenceException
                                                            })
                {
                    importProduits.Add(importProduit);
                }

            // Générer les catégories
            IList<ProductCategory> categoriesTraite = new List<ProductCategory>();
            IList<ProductCategory> categorieExistante = ProductService.GetProductCategoryWithoutLanguage(enterprise.Id);

            foreach (ImportProduit importProduit in importProduits)
            {
                string categorieAnglaise = TrouverCategorieAnglaise(importProduit);
                string categorieFrancais = TrouverCategorieFrancaise(importProduit);

                ProductCategory productCategory;
                if (!string.IsNullOrEmpty(categorieAnglaise))
                {
                    productCategory = new ProductCategory
                    {
                        Description = categorieAnglaise,
                        Enterprise = enterprise,
                        Language = "en",
                        IsActive = true
                    };
                    if (categoriesTraite.Count(x => x.Description == categorieAnglaise) == 0 && categorieExistante.Count(x => x.Description == categorieAnglaise) == 0)
                    {
                        ProductService.SaveProductCategory(productCategory);
                    }
                    categoriesTraite.Add(productCategory);
                }

                if (!string.IsNullOrEmpty(categorieFrancais))
                {
                    productCategory = new ProductCategory
                    {
                        Description = categorieFrancais,
                        Enterprise = enterprise,
                        Language = "fr",
                        IsActive = true
                    };
                    if (categoriesTraite.Count(x => x.Description == categorieFrancais) == 0 && categorieExistante.Count(x => x.Description == categorieFrancais) == 0)
                    {
                        ProductService.SaveProductCategory(productCategory);
                    }
                    categoriesTraite.Add(productCategory);
                }
            }

            // Générer les produits
            IList<Product> products = ProductService.GetAllActive().Where(x => x.Enterprise.Id == enterprise.Id).ToList();
            IList<Product> productsTraite = new List<Product>();
            IList<ProductCategory> productCategories = ProductService.GetProductCategoryWithoutLanguage(enterprise.Id);
            foreach (ImportProduit importProduit in importProduits)
            {
                Product product = products.FirstOrDefault(x => x.Ident == importProduit.ItemID);

                if (product == null && productsTraite.Count(x => x.Ident == importProduit.ItemID) == 0)
                {
                    product = new Product
                        {
                            Ident = importProduit.ItemID,
                            DescriptionEnglish = importProduit.Desc_EN,
                            DescriptionFrench = importProduit.Desc_FR,
                            NameEnglish = importProduit.Title_EN,
                            NameFrench = importProduit.Title_FR,
                            Enterprise = enterprise,
                            ProductCategoryEnglish = productCategories.FirstOrDefault(x => x.Description == TrouverCategorieAnglaise(importProduit)),
                            ProductCategoryFrench = productCategories.FirstOrDefault(x => x.Description == TrouverCategorieFrancaise(importProduit)),
                            Weight = 1,
                            UnitPrice = (decimal)RandomNumberBetween(1, 100)
                        };
                    productsTraite.Add(product);
                    ProductService.Save(product);
                }
                else
                {
                    if (product != null)
                    {
                        product.DescriptionEnglish = importProduit.Desc_EN;
                        product.DescriptionFrench = importProduit.Desc_FR;
                        product.NameEnglish = importProduit.Title_EN;
                        product.NameFrench = importProduit.Title_FR;
                        product.ProductCategoryEnglish = productCategories.FirstOrDefault(x => x.Description == TrouverCategorieAnglaise(importProduit));
                        product.ProductCategoryFrench = productCategories.FirstOrDefault(x => x.Description == TrouverCategorieFrancaise(importProduit));
                        productsTraite.Add(product);
                        ProductService.Save(product);
                    }
                }
            }

            // Générer les stock // caracteristique
            products = ProductService.GetAllActive().Where(x => x.Enterprise.Id == enterprise.Id).ToList();
            IList<Stock> stocks = StockService.GetAllStockByEnterprise(enterprise.Id);
            foreach (Product product in products)
            {
                if (importProduits.Count(x => x.ItemID == product.Ident) > 0)
                {
                    IList<Stock> stocksTraite = new List<Stock>();
                    IList<ImportProduit> listeProduit = importProduits.Where(x => x.ItemID == product.Ident).ToList();
                    foreach (ImportProduit importProduit in listeProduit)
                    {
                        string featureEnglish = importProduit.Size + " - " + importProduit.Color_EN;
                        string featureFrench = importProduit.Size + " - " + importProduit.Color_FR;
                        Stock stock = stocks.FirstOrDefault(x => x.Id == product.Id && x.FeatureEnglish == featureEnglish);
                        if (stock == null && stocksTraite.Count(x => x.Product.Id == product.Id && x.FeatureEnglish == featureEnglish) == 0)
                        {
                            stock = new Stock
                                {
                                    FeatureEnglish = featureEnglish,
                                    FeatureFrench = featureFrench,
                                    ColorEnglish = importProduit.Color_EN,
                                    ColorFrench = importProduit.Color_FR,
                                    Product = product,
                                    IsWithoutStock = true,
                                    InitialState = 0,
                                    IsWarningOnLow = false
                                };
                            stocksTraite.Add(stock);
                            StockService.Save(stock);
                        }
                        else
                        {
                            if (stock != null)
                            {
                                stock.FeatureEnglish = featureEnglish;
                                stock.FeatureFrench = featureFrench;
                                stock.Product = product;
                                stock.IsWithoutStock = true;
                                stock.InitialState = 0;
                                stock.IsWarningOnLow = false;
                                stocksTraite.Add(stock);
                                StockService.Save(stock);
                            }
                        }
                    }
                }
            }
        }
        private string TraductionCategorie(string categorieAnglais)
        {

            if (categorieAnglais == "Fleece") return "Tissus";
            if (categorieAnglais == "Pants") return "Pantalon";
            if (categorieAnglais == "accessories") return "Accessoires";
            if (categorieAnglais == "BathRobes") return "Robe de chambre";
            if (categorieAnglais == "Shirts") return "Gilet";
            if (categorieAnglais == "Unisex") return "Unisexe";
            if (categorieAnglais == "Tshirts") return "Tshirts.";
            if (categorieAnglais == "LongSlv") return "Gilet long";
            if (categorieAnglais == "Polos") return "Polos.";
            if (categorieAnglais == "Shorts") return "Culotte courte";
            if (categorieAnglais == "Jackets") return "Manteau";
            if (categorieAnglais == "Caps") return "Casquette";
            if (categorieAnglais == "Bellacanvas") return "Bellacanvas.";
            if (categorieAnglais == "TankTop") return "TankTop.";
            if (categorieAnglais == "Headwears") return "Chapeau";
            if (categorieAnglais == "Hyp") return "Hyp.";
            if (categorieAnglais == "Knit") return "Tricot";
            if (categorieAnglais == "BathRobes-Unisex") return "F";
            if (categorieAnglais == "Dyenomite") return "Dyenomite.";
            if (categorieAnglais == "Outdoor") return "Extérieur";
            if (categorieAnglais == "Bags") return "Sac";
            if (categorieAnglais == "Oakley") return "Oakley.";
            if (categorieAnglais == "Horst") return "Horst.";
            if (categorieAnglais == "Valubag") return "Sac valeur";
            return "";
        }

    }
}
