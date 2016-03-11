using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;
using File = System.IO.File;

namespace ATMTECH.Administration.Views.Francais
{
    public class ActionPresenter : BaseAdministrationPresenter<IActionPresenter>
    {
        public IDatabaseService DatabaseService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IDAOCourriel DAOCourriel { get; set; }
        public IInventaireService InventaireService { get; set; }
        public IClientService ClientService { get; set; }
        public ICourrielService CourrielService { get; set; }
        public IProduitService ProduitService { get; set; }
        public IPaypalService PaypalService { get; set; }

        public ActionPresenter(IActionPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeCopieSauvegarde();
            AfficherListeCourriel();
        }
        public void AfficherListeCourriel()
        {
            View.ListeCourriel = DAOCourriel.GetAllActive();
        }
        public void AfficherListeCopieSauvegarde()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("Data"), "*.bak");
            View.ListeCopieSauvegarde = filePaths;
        }
        public string RestaurerCopieSauvegarde()
        {
            return DatabaseService.RestaurerFichierSauvegarde(View.FichierSauvegarde, "eCommerce");
        }
        public string ConfirmerCommande(int noCommande)
        {
            if (CommandeService.ConfirmerCommande(noCommande))
            {
                return noCommande + " commande confirmé";
            }
            else
            {
                return noCommande + " erreur commande non confirmé ou n'existe pas";
            }

        }
        public void AfficherCourriel()
        {
            Mail mail = DAOCourriel.ObtenirMail(View.Code);
            View.CorpsFr = mail.BodyFr;
            View.SujetFr = mail.SubjectFr;
            View.CorpsEn = mail.BodyEn;
            View.SujetEn = mail.SubjectEn;
        }
        public void SauvegarderCourriel()
        {
            Mail mail = DAOCourriel.ObtenirMail(View.Code);
            mail.BodyFr = View.CorpsFr;
            mail.SubjectFr = View.SujetFr;
            mail.BodyEn = View.CorpsEn;
            mail.SubjectEn = View.SujetEn;
            DAOCourriel.Save(mail);
        }
        public void AppliquerPourcentage()
        {
            string sql = string.Format("UPDATE Product SET UnitPrice = (CostPrice * 0.{0}) + CostPrice", View.Pourcentage);
            DatabaseService.ExecuteSql(sql, EnumDatabaseVendor.Mssql);

            sql = string.Format("UPDATE Stock SET AdjustPrice =   (AdjustPrice * 0.{0}) + AdjustPrice", View.Pourcentage);
            DatabaseService.ExecuteSql(sql, EnumDatabaseVendor.Mssql);

        }
        public string VerifierInventaire(string idProduit, string grandeur, string couleur)
        {
            return InventaireService.ObtenirInventaireTechnosport(idProduit, grandeur, couleur).ToString();
        }
        public string ValiderPaypal()
        {
            IList<Order> orders = CommandeService.ObtenirCommande()
                                        .Where(x => x.FinalizedDate != null).ToList()
                                        .Where(x => x.FinalizedDate >= View.DateDepart && x.FinalizedDate <= View.DateFin).ToList();
            string html = "<table><tr><td>Date</td><td>Client</td><td>No. commande</td><td>Grand total</td></tr>";
            foreach (Order order in orders)
            {
                order.Customer = ClientService.ObtenirClient(order.Customer.Id);
                html += "<tr>";
                html += "<td>";
                html += order.FinalizedDate;
                html += "</td>";
                html += "<td>";
                html += order.CustomerFullName;
                html += "</td>";
                html += "<td>";
                html += order.Id;
                html += "</td>";
                html += "<td>";
                html += order.GrandTotal;
                html += "</td>";
                html += "</tr>";
            }

            html += "</table>";
            return html;
        }
        public bool EnvoyerCourriel()
        {
            Mail courriel = DAOCourriel.ObtenirMail("CONFIRMATION_CREATION_CLIENT");
            return CourrielService.EnvoyerCourriel(View.Courriel, courriel.From, "Test d'envoi de courriel ...",
                 "<b>Test d'envoi de courriel</b><br>Réussi ...");
        }

        public void EnvoyerCourrielCommande()
        {
            Order obtenirCommande = CommandeService.ObtenirCommande(Convert.ToInt32(View.NumeroCommandePourCourriel));
            Stream obtenirFacturePourPdf = CommandeService.ObtenirFacturePourPdf(obtenirCommande);
            CourrielService.EnvoyerCommandeACourriel(obtenirCommande, obtenirFacturePourPdf, View.CourrielCommande);
            MessageService.ThrowMessage("ADM005");
        }

        public void ImporterExcel(HttpPostedFile httpPostedFile)
        {
            string filename = Path.GetFileName(httpPostedFile.FileName);
            string serverPath = Server.MapPath(string.Format(@"{0}\{1}", "Files", filename));
            if (!Directory.Exists(Server.MapPath(string.Format(@"{0}", "Files"))))
            {
                Directory.CreateDirectory(Server.MapPath(string.Format(@"{0}", "Files")));
            }
            httpPostedFile.SaveAs(serverPath);
            using (OleDbConnection oleDbConnection = new OleDbConnection(("provider=Microsoft.Jet.OLEDB.4.0; " + ("data source=" + serverPath + "; " + "Extended Properties=Excel 8.0;"))))
            {
                oleDbConnection.Open();
                OleDbDataAdapter ada = new OleDbDataAdapter("select * from [Import$]", oleDbConnection);
                DataSet ds = new DataSet();

                try
                {
                    ada.Fill(ds, "result_name");
                    DataTable dt = ds.Tables["result_name"];
                    foreach (DataRow row in dt.Rows)
                    {
                        if (serverPath.IndexOf("Product") > 0)
                            ImporterProduct(row);
                        if (serverPath.IndexOf("Stock") > 0)
                            ImporterStock(row);
                    }
                    ShowMessage(new Message { Description = "Importation effectuée avec succès", MessageType = Message.MESSAGE_TYPE_SUCCESS });

                }
                catch (Exception ex)
                {
                    MessageService.ThrowMessage(ex);
                }

            }

            File.Delete(serverPath);
        }

        public void ImporterProduct(DataRow row)
        {
            if (string.IsNullOrEmpty(row["Ident"].ToString()))
            {
                return;
            }

            Product product = new Product
            {
                DescriptionEnglish = row["DescriptionEnglish"].ToString(),
                DescriptionFrench = row["DescriptionFrench"].ToString(),
                IsActive = true,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Ident = row["Ident"].ToString(),
                NameFrench = row["NameFrench"].ToString(),
                NameEnglish = row["NameEnglish"].ToString(),
                UnitPrice = row["UnitPrice"] == null ? 0 : Convert.ToDecimal(row["UnitPrice"].ToString()),
                CostPrice = row["CostPrice"] == null ? 0 : Convert.ToDecimal(row["CostPrice"].ToString()),
                Enterprise = new Enterprise { Id = Convert.ToInt32(Convert.ToInt32(row["Enterprise"])) },
                Weight = row["Weight"] == null ? 0 : Convert.ToDecimal(row["Weight"].ToString()),
                ProductCategoryFrench = new ProductCategory { Id = Convert.ToInt32(row["ProductCategoryFrench"]) },
                ProductCategoryEnglish = new ProductCategory { Id = Convert.ToInt32(row["ProductCategoryEnglish"]) }
            };

            product.UnitPrice = row["UnitPrice"] == null ? 0 : Convert.ToDecimal(row["UnitPrice"].ToString());
            ProduitService.Enregistrer(product);
        }
        public void ImporterStock(DataRow row)
        {
            if (string.IsNullOrEmpty(row["Product"].ToString()))
            {
                return;
            }

            Stock stock = new Stock
            {
                IsActive = true,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Product = new Product { Id = Convert.ToInt32(row["Product"]) },
                InitialState = Convert.ToInt32(row["InitialState"]),
                MinimumAccept = Convert.ToInt32(row["MinimumAccept"]),
                IsWarningOnLow = Convert.ToInt32(row["IsWarningOnLow"]) == 1,
                FeatureFrench = row["FeatureFrench"].ToString(),
                FeatureEnglish = row["FeatureEnglish"].ToString(),
                AdjustPrice = row["AdjustPrice"] == null ? 0 : Convert.ToDecimal(row["AdjustPrice"].ToString()),
                IsWithoutStock = Convert.ToInt32(row["IsWithoutStock"]) == 1
            };

            InventaireService.Enregistrer(stock);

        }

        public void PayerPaypal()
        {

            PaypalDto paypalDto = new PaypalDto
            {
                OrderDescription = "Test de commande",
                Price = 0.01,
                Quantity = 1,
                OrderId = "TEST",
                ProductName = "TEST"
            };

            PaypalService.SendPaypalRequest(paypalDto);


            Order order = CommandeService.ObtenirCommande(23);
            CommandeService.FinaliserCommandeAvecPaypal(order);
        }
    }
}
