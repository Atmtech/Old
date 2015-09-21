using ATMTECH.XWingCampaign.Entities;
using ATMTECH.XWingCampaign.Services.Interface;
using ATMTECH.XWingCampaign.Views.Base;
using ATMTECH.XWingCampaign.Views.Interface;

namespace ATMTECH.XWingCampaign.Views
{
    public class AccueilPresenter : BaseXWingCampaignPresenter<IAccueilPresenter>
    {
        public IVaisseauService VaisseauService { get; set; }
        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            SelectionnerVaisseau(1);
        }

        public void SelectionnerVaisseau(int id)
        {
            View.VaisseauSelectionne = VaisseauService.ObtenirVaisseau(id);
        }

     

        public void ObtenirMouvement(string emplacement)
        {
            int jetDe = VaisseauService.JetDe();
            string[] split = emplacement.Split(';');
            string quadrant = split[0];
            string position = split[1] + ";" + split[2];
            IntelligenceArtificiel intelligenceArtificiel = VaisseauService.ObtenirIntelligenceArtificiel(View.VaisseauSelectionne, jetDe, quadrant, position);

            View.Resultat = string.Format("<img src='Images/WebSite/De{0}.png'> <div style='font-size:20px;'>{1} {2}</div> <div style='font-size:8px;'>({3} :: {4})</div>",
                jetDe, intelligenceArtificiel.NombreMouvement,
                intelligenceArtificiel.Stress ?
                string.Format("<img src='Images/WebSite/{0}_S.png' style='height:50px;width:50px;'>", intelligenceArtificiel.Mouvement)
                : string.Format("<img src='Images/WebSite/{0}.png' style='height:50px;width:50px;'>", intelligenceArtificiel.Mouvement), intelligenceArtificiel.PositionVaisseau, quadrant);
            View.AfficherResultat = true;
        }

    }
}