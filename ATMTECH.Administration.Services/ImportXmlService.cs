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

        public void ImportProductAndStockXml(Enterprise enterprise, string fileXml)
        {
            IList<ImportProduit> importProduits = new List<ImportProduit>();
            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(@"C:\Dev\Atmtech\ATMTECH.Administration\Data\Products.xml");
            xmlDoc.Load(fileXml);

            if (xmlDoc.DocumentElement != null)
            {
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

                // Générer les produits
                IList<Product> products = ProductService.GetAllActive().Where(x => x.Enterprise.Id == enterprise.Id).ToList();
                IList<Product> productsTraite = new List<Product>();
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
                            Weight = 1
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
                        IList<ImportProduit> listeProduit =
                            importProduits.Where(x => x.ItemID == product.Ident).ToList();
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
        }
    }
}
