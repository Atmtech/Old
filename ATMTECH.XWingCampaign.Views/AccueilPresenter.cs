using System.Collections.Generic;
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
         //   AfficherVaisseau();
        }

        //public void AfficherVaisseau()
        //{
        //    View.Vaisseaux = VaisseauService.ObtenirVaisseau();
        //}

        public void ObtenirMouvement(string emplacement, int idVaisseau)
        {
            Vaisseau vaisseau = VaisseauService.ObtenirVaisseau(idVaisseau);
            int jetDe = VaisseauService.JetDe();
            string[] split = emplacement.Split(';');
            string quadrant = split[0];
            string position = split[1] + ";" + split[2];
            IntelligenceArtificiel intelligenceArtificiel = VaisseauService.ObtenirIntelligenceArtificiel(vaisseau, jetDe, quadrant, position);

            View.Resultat = string.Format("Jet de dé: {0} <br><br> Mouvement: {1} {2} ({3} :: {4})",
                jetDe, intelligenceArtificiel.NombreMouvement,
                intelligenceArtificiel.Stress ?
                string.Format("<img src='Images/WebSite/{0}_S.png'>", intelligenceArtificiel.Mouvement)
                : string.Format("<img src='Images/WebSite/{0}.png'>", intelligenceArtificiel.Mouvement), intelligenceArtificiel.PositionVaisseau, quadrant);
        }


        //public void ObtenirMouvement()
        //{
        //    //Vaisseau vaisseau = VaisseauService.ObtenirVaisseau(View.VaisseauSelectionne);
        //    //int jetDe = VaisseauService.JetDe();
        //    //IntelligenceArtificiel intelligenceArtificiel = VaisseauService.ObtenirIntelligenceArtificiel(vaisseau, jetDe, View.Quadran, View.Position);

        //    //View.Resultat = string.Format("Jet de dé: {0} <br><br> Mouvement: {1} {2} ({3})",
        //    //    jetDe, intelligenceArtificiel.NombreMouvement,
        //    //    intelligenceArtificiel.Stress ?
        //    //    string.Format("<img src='Images/WebSite/{0}_S.png'>", intelligenceArtificiel.Mouvement)
        //    //    : string.Format("<img src='Images/WebSite/{0}.png'>", intelligenceArtificiel.Mouvement), intelligenceArtificiel.PositionVaisseau);
        //}
    }
}