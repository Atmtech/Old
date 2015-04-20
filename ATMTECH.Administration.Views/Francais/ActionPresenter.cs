using System.IO;
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
    }
}
