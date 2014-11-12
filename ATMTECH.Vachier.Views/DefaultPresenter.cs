using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Vachier.Entities;
using ATMTECH.Vachier.Views.Base;
using ATMTECH.Vachier.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.Vachier.Views
{
    public class DefaultPresenter : BaseVachierPresenter<IDefaultPresenter>
    {
        public IDAOVachier DAOVachier { get; set; }
        public IDAOInsulte DAOInsulte { get; set; }
        public IDAOMerdeux DAOMerdeux { get; set; }
        public IDAOCountryIp DAOCountryIp { get; set; }


        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            int total = DAOVachier.ObtenirCompte();
            List<Entities.Vachier> vachiers = ObtenirListe(total / View.NombreParPage, View.NombreParPage).ToList();

            View.Liste = vachiers.OrderByDescending(x => x.DateCreated).ToList();
            View.CompteTotal = total;

            View.MerdeDuMoment = DAOVachier.ObtenirMerdeDuJour();
            View.ListeTop = DAOVachier.ObtenirListeVachierTopListe();
            View.TotalMarde = DAOVachier.ObtenirNombreTotal().ToString();
            View.ListeInsulte = ObtenirListeInsulte();
            View.ListeMerdeux = ObtenirListeMerdeux();
            View.ListePays = DAOCountryIp.ObtenirListePays();
            View.ListeVille = DAOCountryIp.ObtenirListeVille();
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.ListeTop = DAOVachier.ObtenirListeVachierTopListe();
        }

        public IList<Entities.Vachier> ObtenirListe(int indexDebut, int nombreSortie)
        {
            if (!string.IsNullOrEmpty(QueryString.GetQueryStringValue("r")))
            {
                View.RechercheQueryString = QueryString.GetQueryStringValue("r");
            }

            return DAOVachier.ObtenirListeVachier(QueryString.GetQueryStringValue("r"), nombreSortie, indexDebut).OrderByDescending(x => x.DateCreated).ToList();
        }


        public void JaimeTaMerde(int id)
        {
            Entities.Vachier vachier = DAOVachier.ObtenirVachier(id);
            vachier.JaimeTaMerde += 1;
            DAOVachier.EnregistrerMerde(vachier);
            NavigationService.Refresh();
        }

        public void AjouterMerde()
        {
            Entities.Vachier vachier = new Entities.Vachier();
            Insulte insulte = new Insulte { Id = Convert.ToInt32(View.Insulte) };

            CountryIp countryIp = NavigationService.GetInformationIpInfoDb();

            if (countryIp != null)
            {
                vachier.CountryName = countryIp.CountryName;
                vachier.Ip = countryIp.Ip;
                vachier.City = countryIp.City;
                vachier.Region = countryIp.Region;
                vachier.PostalCode = countryIp.PostalCode;
            }


            vachier.JaimeTaMerde = 0;
            vachier.Insulte = insulte;
            vachier.Description = View.AjouterMerde;
            DAOVachier.EnregistrerMerde(vachier);

            // Vider le champs.
            View.AjouterMerde = string.Empty;

            NavigationService.Refresh();
        }
        public void RechercherMerde()
        {
            //string page = Utils.Web.Pages.GetCurrentPage();
            NavigationService.Redirect("default.aspx?r=" + View.RechercheMerde);
        }
        public void AnnulerRecherche()
        {
            //string page = Utils.Web.Pages.GetCurrentPage();
            NavigationService.Redirect("default.aspx?r=");
        }
        public void AjouterMerdeCelebre()
        {
            //Merdeux merdeux = new Merdeux();
            //merdeux.Description = View.AjouterMerdeCelebre;
            //merdeux.Publish = false;
            //DAOMerdeux.AjouterMerdeCelebre(merdeux);
            //View.AjouterMerdeCelebre = string.Empty;
            //Message message = new Message();
            //message.InnerId = "0001";
            //message.MessageType = "Confirmation";
            //message.Description = "Merde ajouté";
            //View.ShowMessage(message);
        }
        public void ChierSurCelebre()
        {
            //Entities.Vachier vachier = new Entities.Vachier();
            //Insulte insulte = new Insulte();
            //insulte.Id = 2;
            //vachier.Insulte = insulte;
            //vachier.Description = DAOMerdeux.ObtenirDescription(Convert.ToInt32(View.ChierSurCelebre));
            //DAOVachier.EnregistrerMerde(vachier);
        }

        private IList<Merdeux> ObtenirListeMerdeux()
        {
            return DAOMerdeux.ObtenirListeMerdeux();
        }
        private IList<Insulte> ObtenirListeInsulte()
        {
            return DAOInsulte.ObtenirListeInsulte();
        }
    }
}
