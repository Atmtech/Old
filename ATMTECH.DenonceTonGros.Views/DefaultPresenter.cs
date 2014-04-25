using System.Collections.Generic;
using ATMTECH.DenonceTonGros.DAO.Interface;
using ATMTECH.DenonceTonGros.Entities;
using ATMTECH.DenonceTonGros.Views.Base;
using ATMTECH.DenonceTonGros.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.DenonceTonGros.Views
{
    public class DefaultPresenter : BaseDenonceTonGrosPresenter<IDefaultPresenter>
    {
        public IDAODenonceTonGros DAODenonceTonGros { get; set; }
        

        public int NombreInsulte { get { return 20; } }

        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            
            View.Liste = ObtenirListe(0, NombreInsulte);
            View.CompteTotal = DAODenonceTonGros.ObtenirCompte();
            View.MerdeDuJour = DAODenonceTonGros.ObtenirMerdeDuJour();
            View.ListeTop = DAODenonceTonGros.ObtenirListeDenonceTonGrosTopListe();
            View.TotalMarde = DAODenonceTonGros.ObtenirNombreTotal().ToString();
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.ListeTop = DAODenonceTonGros.ObtenirListeDenonceTonGrosTopListe();

        }

        public IList<DenonceTonGrosTas> ObtenirListe(int indexDebut, int nombreSortie)
        {
            return DAODenonceTonGros.ObtenirListeDenonceTonGros(QueryString.GetQueryStringValue("r"), "", nombreSortie, indexDebut);
        }


        public void JaimeTaMerde(int id)
        {
            DenonceTonGrosTas DenonceTonGros = DAODenonceTonGros.ObtenirDenonceTonGros(id);
            DenonceTonGros.Jaime += 1;
            DAODenonceTonGros.EnregistrerMerde(DenonceTonGros);
            NavigationService.Refresh();
        }
    }
}
