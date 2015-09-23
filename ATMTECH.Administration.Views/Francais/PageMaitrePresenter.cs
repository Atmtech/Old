using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Common.Constant;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using File = ATMTECH.Entities.File;

namespace ATMTECH.Administration.Views.Francais
{
    public class PageMaitrePresenter : BaseAdministrationPresenter<IPageMaitrePresenter>
    {
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }

        public IClientService ClientService { get; set; }
        public IInventaireService InventaireService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IDAOListeDistribution DAOListeDistribution { get; set; }
        public IDatabaseService DatabaseService { get; set; }
        public IImportXmlService ImportXmlService { get; set; }
        public IFileService FileService { get; set; }
        public IProduitService ProduitService { get; set; }
        public IEntrepriseService EntrepriseService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Enterprises = EntrepriseService.ObtenirEntreprise();
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            //EstSiteHorsLigne();
            View.EstConnecte = AuthenticationService.AuthenticateUser != null && AuthenticationService.AuthenticateUser.IsAdministrator;

        }
        public void EstSiteHorsLigne()
        {
            string isOffline = ParameterService.GetValue(Constant.IS_OFFLINE);
            if (string.IsNullOrEmpty(isOffline)) return;
            if (isOffline == "1")
            {
                NavigationService.Redirect("Offline.htm");
            }
        }
        public void OuvrirSession()
        {
            AuthenticationService.SignIn(View.NomUtilisateur, View.MotDePasse);
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
        public void FermerSession()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
        public void MettreSiteEnFrancais()
        {
            LocalizationService.CurrentLanguage = LocalizationLanguage.FRENCH;
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
        public void MettreSiteEnAnglais()
        {
            LocalizationService.CurrentLanguage = LocalizationLanguage.ENGLISH;
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
        public string AjusterRecherche()
        {
            string retour = Enregistrer<User>();
            retour += Enregistrer<Parameter>();
            retour += Enregistrer<Customer>();
            retour += Enregistrer<ProprieteEdition>();
            retour += Enregistrer<Message>();
            retour += Enregistrer<TitrePage>();
            //retour += Enregistrer<Order>();
            //retour += Enregistrer<OrderLine>();
            //retour += Enregistrer<Stock>();
            return retour;
        }
        public void ImporterXml()
        {
            ImportXmlService.ImportProductAndStockXml(new Enterprise { Id = 1 }, Server.MapPath("Data") + @"\Catalogue.xml");
            EffacerJournalTransaction();
        }
        public void SynchronizerImage()
        {
            string directory = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.Commerce\Images";
            string[] files = Directory.GetFiles(directory + @"\product");
            IList<File> filesDatabase = FileService.GetAllFile();

            foreach (string file in files)
            {
                long fileSize;
                using (FileStream fichier = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fileSize = fichier.Length;
                }
                if (filesDatabase.FirstOrDefault(x => x.FileName == Path.GetFileName(file) && x.RootImagePath == directory) == null)
                {
                    File fileToSave = new File
                    {
                        Category = "Product",
                        Size = (int)fileSize,
                        RootImagePath = directory,
                        FileName = Path.GetFileName(file)
                    };
                    FileService.SaveFile(fileToSave);
                }

            }

            EffacerJournalTransaction();
        }
        public void CopierFichierImageProduitNonFormateVersProduct()
        {
            string directory = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.Commerce\Images";
            string[] files = Directory.GetFiles(directory + @"\product\Mixed", "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (file.ToLower().IndexOf("thumbs.db") == -1 && file.ToLower().IndexOf("web.config") == -1)
                {
                    string fileToCopy = file.Replace(directory + @"\product\Mixed", "").Replace(@"/", "_").Replace(" ", "_").Replace("\\", "_");
                    System.IO.File.Copy(file, directory + @"\product\" + fileToCopy);
                }
            }
        }
        public void SynchronizeProductFile()
        {
            IList<File> filesDatabase = FileService.GetAllFile();
            IList<ProductFile> productFiles = ProduitService.ObtenirFichierProduit();
            IList<Product> products = ProduitService.ObtenirProduit();
            foreach (File file in filesDatabase)
            {
                ProductFile productFile = productFiles.FirstOrDefault(x => x.Product.Ident == file.FileName.Replace(".jpg", ""));
                if (productFile == null)
                {
                    string identToFind = file.FileName.Replace(".jpg", "").ToLower();
                    string[] identSplit = identToFind.IndexOf("_item") > 0 ? identToFind.Split('_') : null;
                    if (identSplit != null)
                    {
                        identToFind = identSplit[3];
                    }
                    Product product = products.FirstOrDefault(x => x.Ident.ToLower() == identToFind);
                    if (product != null)
                    {
                        productFile = new ProductFile
                        {
                            Product = product,
                            File = file,
                            IsPrincipal = identSplit == null,
                            IsActive = true
                        };
                        ProduitService.EnregistrerFichierProduit(productFile);
                    }
                }
            }
            EffacerJournalTransaction();
        }
        public void OuvrirSysteme()
        {
            ParameterService.SetValue("IsOffline", "0");
        }
        public void FermerSysteme()
        {
            ParameterService.SetValue("IsOffline", "1");
        }
        public string CreationCopieSauvegarde(string path)
        {
            return DatabaseService.CreationFichierSauvegarde(path, "eCommerce");
        }
        public void InitialiserSysteme()
        {
            DatabaseService.ExecuteSql("DELETE FROM PRODUCT", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DELETE FROM PRODUCTCATEGORY", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DELETE FROM STOCK", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DELETE FROM [FILE]", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DELETE FROM [PRODUCTFILE]", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DELETE FROM LogException", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DELETE FROM LogMail", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DBCC CHECKIDENT (PRODUCT, RESEED, 0)", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DBCC CHECKIDENT (PRODUCTCATEGORY, RESEED, 0)", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DBCC CHECKIDENT (STOCK, RESEED, 0)", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DBCC CHECKIDENT ([FILE], RESEED, 0)", EnumDatabaseVendor.Mssql);
            DatabaseService.ExecuteSql("DBCC CHECKIDENT ([PRODUCTFILE], RESEED, 0)", EnumDatabaseVendor.Mssql);
            EffacerJournalTransaction();
        }

        public void EffacerJournalTransaction()
        {
            DatabaseService.ExecuteSql("DELETE FROM TRANSACTIONLOG", EnumDatabaseVendor.Mssql);
        }
        private string Enregistrer<TModel>()
        {
            switch (typeof(TModel).FullName)
            {
                //case "ATMTECH.ShoppingCart.Entities.Enterprise":
                //    foreach (Enterprise enterprise in EnterpriseService.GetAll())
                //    {
                //        EnterpriseService.Save(EnterpriseService.GetEnterprise(enterprise.Id));
                //    }
                //    break;
                //case "ATMTECH.ShoppingCart.Entities.Order":
                //    foreach (Order order in OrderService.GetAll())
                //    {
                //        OrderService.Save(OrderService.GetOrder(order.Id));
                //    }
                //    break;
                //case "ATMTECH.ShoppingCart.Entities.Stock":

                //    IList<Product> allActive = ProductService.GetAllActive();
                //    foreach (Stock stock in StockService.GetAllStock())
                //    {
                //        Product product = allActive.FirstOrDefault(x => x.Id == stock.Product.Id);
                //        if (product != null)
                //        {
                //            stock.Product = product;
                //            StockService.Save(stock);
                //        }
                //    }
                //    break;
                case "ATMTECH.ShoppingCart.Entities.Customer":
                    BaseDao<Customer, int> daoModelCustomer = new BaseDao<Customer, int>();

                    foreach (Customer customer in ClientService.ObtenirClient())
                    {
                        customer.User = AuthenticationService.GetUser(customer.User.Id);
                        daoModelCustomer.Save(customer);
                    }
                    break;
                default:
                    BaseDao<TModel, int> daoModel = new BaseDao<TModel, int>();
                    IList<TModel> model = daoModel.GetAll();
                    foreach (TModel model1 in model)
                    {
                        daoModel.Save(model1);
                    }
                    break;
            }



            return typeof(TModel).FullName + " Exécuté !!!<br>";
        }

        public void MettreSystemeEnProduction()
        {
            DatabaseService.ExecuteSql("UPDATE [Parameter] SET DESCRIPTION = 'PROD' WHERE CODE = 'Environment'", EnumDatabaseVendor.Mssql);
        }


        //public void VerifierBackOrder()
        //{
        //    IList<Stock> obtenirInventaire = InventaireService.ObtenirInventaire();
        //    IList<Product> produits = ProduitService.ObtenirProduit();

        //    foreach (Stock stock in obtenirInventaire)
        //    {
        //        stock.Product = produits.FirstOrDefault(x => x.Id == stock.Product.Id);
        //        int obtenirInventaireTechnosport = InventaireService.ObtenirInventaireTechnosport(stock.Product.Ident, stock.Size, stock.ColorEnglish);
        //        if (obtenirInventaireTechnosport == 0)
        //        {
        //            stock.IsBackOrder = true;
        //            InventaireService.Enregistrer(stock);
        //        }
        //    }

        //}
    }
}