using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.DenonceTonGros.DAO.Interface;
using ATMTECH.DenonceTonGros.Entities;
using ATMTECH.DenonceTonGros.Views.Base;
using ATMTECH.DenonceTonGros.Views.Interface;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.DenonceTonGros.Views
{
    public class DefaultMasterPresenter : BaseDenonceTonGrosPresenter<IDefaultMasterPresenter>
    {

        public IDAOInsulte DAOInsulte { get; set; }
        public IDAODenonceTonGros DAODenonceTonGros { get; set; }
        public IDAOGros DAOGros { get; set; }
        public IDAOCountryIp DAOCountryIp { get; set; }

        public DefaultMasterPresenter(IDefaultMasterPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            View.ListeInsulte = ObtenirListeInsulte();
            View.ListeMerdeux = ObtenirListeMerdeux();
            View.ListePays = DAOCountryIp.ObtenirListePays();
            View.ListeVille = DAOCountryIp.ObtenirListeVille();
        }
        public void AjouterMerde()
        {
            DenonceTonGrosTas DenonceTonGros = new Entities.DenonceTonGrosTas();
            Insulte insulte = new Insulte {Id = Convert.ToInt32(View.Insulte)};

            CountryIp countryIp = NavigationService.GetInformationIpInfoDb();

            DenonceTonGros.CountryName = countryIp.CountryName;
            DenonceTonGros.Ip = countryIp.Ip;
            DenonceTonGros.City = countryIp.City;
            DenonceTonGros.Region = countryIp.Region;
            DenonceTonGros.PostalCode = countryIp.PostalCode;

            DenonceTonGros.Jaime = 0;
            DenonceTonGros.Insulte = insulte;
            DenonceTonGros.Description = View.AjouterMerde;
            DAODenonceTonGros.EnregistrerMerde(DenonceTonGros);

            // Vider le champs.
            View.AjouterMerde = string.Empty;

            NavigationService.Refresh();
        }
        public void RechercherMerde()
        {
            NavigationService.Redirect("default.aspx?r=" + View.RechercheMerde);
        }
        public void AnnulerRecherche()
        {
            NavigationService.Redirect("default.aspx?r=");
        }
        public void AjouterMerdeCelebre()
        {
            Gros gros = new Gros {Description = View.AjouterMerdeCelebre, Publish = false};
            DAOGros.AjouterMerdeCelebre(gros);
            View.AjouterMerdeCelebre = string.Empty;
            Message message = new Message();
            message.InnerId = "0001";
            message.MessageType = "Confirmation";
            message.Description = "Merde ajouté";
            View.ShowMessage(message);
        }
        public void ChierSurCelebre()
        {
            Entities.DenonceTonGrosTas DenonceTonGros = new Entities.DenonceTonGrosTas();
            Insulte insulte = new Insulte {Id = 2};
            DenonceTonGros.Insulte = insulte;
            DenonceTonGros.Description = DAOGros.ObtenirDescription(Convert.ToInt32(View.ChierSurCelebre));
            DAODenonceTonGros.EnregistrerMerde(DenonceTonGros);
        }

        private IList<Gros> ObtenirListeMerdeux()
        {
            return DAOGros.ObtenirListeMerdeux();
        }
        private IList<Insulte> ObtenirListeInsulte()
        {
            return DAOInsulte.ObtenirListeInsulte();
        }

    }
}
