using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.Views
{
    public class VoirHistoriqueForfaitExpediaPresenter : BaseExpeditnPresenter<IVoirHistoriqueForfaitExpediaPresenter>
    {
        public IExpediaService ExpediaService { get; set; }


        public VoirHistoriqueForfaitExpediaPresenter(IVoirHistoriqueForfaitExpediaPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            List<HistoriqueForfaitExpedia> historiqueForfaitExpedias = AfficherHistorique();
            View.HistoriqueForfaitExpedia = string.IsNullOrEmpty(View.FiltreHotel) ?
               historiqueForfaitExpedias :
               historiqueForfaitExpedias.Where(x => x.NomHotel == View.FiltreHotel).ToList();
        }

        private List<HistoriqueForfaitExpedia> AfficherHistorique()
        {
            return  ExpediaService.ObtenirHistoriqueForfaitExpedia(
           ExpediaService.ObtenirRechercheForfaitExpedia(View.IdRechercheForfaitExpedia))
           .OrderBy(x => x.Prix)
           .ThenBy(x => x.NomHotel)
           .ThenBy(x => x.DateCreated)
           .ToList();
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            List<string> list = AfficherHistorique().OrderBy(x => x.NomHotel).Select(x => x.NomHotel).Distinct().ToList();
            View.ListeHotel = list;
            View.RechercheForfaitExpedia = ExpediaService.ObtenirRechercheForfaitExpedia(View.IdRechercheForfaitExpedia);
            View.AffichageGraphique = ObtenirAffichageHistoriqueForfaitExpedia();
        }

        public void Filtrer(string filtre)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = View.IdRechercheForfaitExpedia.ToString() });
            queryStrings.Add(new QueryString { Name = "Filtre", Value = filtre });
            NavigationService.Redirect(Pages.VOIR_HISTORIQUE_FORFAIT_EXPEDIA, queryStrings);
        }


        public IList<AffichageHistoriqueForfaitExpedia> ObtenirAffichageHistoriqueForfaitExpedia()
        {
            return ExpediaService.ObtenirAffichageHistoriqueForfaitExpedia(View.IdRechercheForfaitExpedia);
        }
    }
}