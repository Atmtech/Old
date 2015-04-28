using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;

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
            View.Corps = mail.Body;
            View.Sujet = mail.Subject;
        }
        public void SauvegarderCourriel()
        {
            Mail mail = DAOCourriel.ObtenirMail(View.Code);
            mail.Body = View.Corps;
            mail.Subject = View.Sujet;
            DAOCourriel.Save(mail);
        }
        public void AppliquerPourcentage()
        {
            string sql = string.Format("UPDATE Product SET UnitPrice = (CostPrice * {0} /100) + CostPrice", View.Pourcentage);
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
    }
}
