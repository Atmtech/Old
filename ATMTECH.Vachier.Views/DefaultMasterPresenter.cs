using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Vachier.Entities;
using ATMTECH.Vachier.Views.Base;
using ATMTECH.Vachier.Views.Interface;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.Vachier.Views
{
    public class DefaultMasterPresenter : BaseVachierPresenter<IDefaultMasterPresenter>
    {

        public IDAOInsulte DAOInsulte { get; set; }
        public IDAOVachier DAOVachier { get; set; }
        public IDAOMerdeux DAOMerdeux { get; set; }
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
            Entities.Vachier vachier = new Entities.Vachier();
            Insulte insulte = new Insulte();
            insulte.Id = Convert.ToInt32(View.Insulte);

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
            NavigationService.Redirect("default.aspx?r=" + View.RechercheMerde);
        }
        public void AnnulerRecherche()
        {
            NavigationService.Redirect("default.aspx?r=");
        }
        public void AjouterMerdeCelebre()
        {
            Merdeux merdeux = new Merdeux();
            merdeux.Description = View.AjouterMerdeCelebre;
            merdeux.Publish = false;
            DAOMerdeux.AjouterMerdeCelebre(merdeux);
            View.AjouterMerdeCelebre = string.Empty;
            Message message = new Message();
            message.InnerId = "0001";
            message.MessageType = "Confirmation";
            message.Description = "Merde ajouté";
            View.ShowMessage(message);
        }
        public void ChierSurCelebre()
        {
            Entities.Vachier vachier = new Entities.Vachier();
            Insulte insulte = new Insulte();
            insulte.Id = 2;
            vachier.Insulte = insulte;
            vachier.Description = DAOMerdeux.ObtenirDescription(Convert.ToInt32(View.ChierSurCelebre));
            DAOVachier.EnregistrerMerde(vachier);
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
