using System.Collections.Generic;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Vachier.Views.Base;
using ATMTECH.Vachier.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Vachier.Views
{
    public class DefaultPresenter : BaseVachierPresenter<IDefaultPresenter>
    {
        public IDAOVachier DAOVachier { get; set; }
        

        public int NombreInsulte { get { return 20; } }

        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            
            View.Liste = ObtenirListe(0, NombreInsulte);
            View.CompteTotal = DAOVachier.ObtenirCompte();
            View.MerdeDuJour = DAOVachier.ObtenirMerdeDuJour();
            View.ListeTop = DAOVachier.ObtenirListeVachierTopListe();
            View.TotalMarde = DAOVachier.ObtenirNombreTotal().ToString();
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.ListeTop = DAOVachier.ObtenirListeVachierTopListe();

        }

        public IList<Entities.Vachier> ObtenirListe(int indexDebut, int nombreSortie)
        {
            return DAOVachier.ObtenirListeVachier(QueryString.GetQueryStringValue("r"), "", nombreSortie, indexDebut);
        }


        public void JaimeTaMerde(int id)
        {
            Entities.Vachier vachier = DAOVachier.ObtenirVachier(id);
            vachier.JaimeTaMerde += 1;
            DAOVachier.EnregistrerMerde(vachier);
            NavigationService.Refresh();
        }
    }
}
