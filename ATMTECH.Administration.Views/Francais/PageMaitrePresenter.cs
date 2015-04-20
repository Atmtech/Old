using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Common.Constant;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Interface;
using File = ATMTECH.Entities.File;

namespace ATMTECH.Administration.Views.Francais
{
    public class PageMaitrePresenter : BaseAdministrationPresenter<IPageMaitrePresenter>
    {
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }
        public IClientService ClientService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IDAOListeDistribution DAOListeDistribution { get; set; }

        public IOrderService OrderService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IProductService ProductService { get; set; }
        public IDAOStockTransaction DAOStockTransaction { get; set; }
        public IStockService StockService { get; set; }
        public IDatabaseService DatabaseService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IDAOUser DAOUser { get; set; }
        public IParameterService ParameterService { get; set; }
        public IImportXmlService ImportXmlService { get; set; }
        public IFileService FileService { get; set; }


        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            EstSiteHorsLigne();
            if (AuthenticationService.AuthenticateUser != null)
            {
                View.EstConnecte = AuthenticationService.AuthenticateUser.IsAdministrator;
            }
            else
            {
                View.EstConnecte = false;
            }

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
            retour += Enregistrer<Stock>();
            return retour;
        }
        private string Enregistrer<TModel>()
        {


            switch (typeof(TModel).FullName)
            {
                case "ATMTECH.ShoppingCart.Entities.Enterprise":
                    foreach (Enterprise enterprise in EnterpriseService.GetAll())
                    {
                        EnterpriseService.Save(EnterpriseService.GetEnterprise(enterprise.Id));
                    }
                    break;
                case "ATMTECH.ShoppingCart.Entities.Order":
                    foreach (Order order in OrderService.GetAll())
                    {
                        OrderService.Save(OrderService.GetOrder(order.Id));
                    }
                    break;
                case "ATMTECH.ShoppingCart.Entities.Stock":

                    IList<Product> allActive = ProductService.GetAllActive();
                    foreach (Stock stock in StockService.GetAllStock())
                    {
                        Product product = allActive.FirstOrDefault(x => x.Id == stock.Product.Id);
                        if (product != null)
                        {
                            stock.Product = product;
                            StockService.Save(stock);
                        }
                    }
                    break;
                case "ATMTECH.ShoppingCart.Entities.Customer":
                    BaseDao<Customer, int> daoModelCustomer = new BaseDao<Customer, int>();

                    foreach (Customer customer in CustomerService.GetAll())
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

        public void ImporterXml()
        {
            ImportXmlService.ImportProductAndStockXml(new Enterprise { Id = 1 }, @"C:\Dev\Atmtech\ATMTECH.Administration\Data\Catalogue.xml");
        }

        public void SynchronizeImage(string directory)
        {
            string[] files = Directory.GetFiles(directory + @"\product");
            IList<File> filesDatabase = FileService.GetAllFile();

            foreach (string file in files)
            {
                long fileSize;
                using (var fichier = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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


        }
        public void CopierFichierImageProduitNonFormateVersProduct(string directory)
        {
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
            IList<ProductFile> productFiles = ProductService.GetProductFile();
            IList<Product> products = ProductService.GetAllActive();
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
                        ProductService.SaveProductFile(productFile);
                    }



                }
            }


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
    }
}