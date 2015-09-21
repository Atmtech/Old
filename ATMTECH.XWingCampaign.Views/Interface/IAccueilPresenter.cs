using System.Collections.Generic;
using ATMTECH.Views.Interface;
using ATMTECH.XWingCampaign.Entities;

namespace ATMTECH.XWingCampaign.Views.Interface
{
    public interface IAccueilPresenter : IViewBase
    {
        string Resultat { get; set; }
        Vaisseau VaisseauSelectionne { get; set; }
        bool AfficherResultat { get; set; }
        //string Quadran { get; set; }
        //string Position { get; set; }
        //IList<Vaisseau> Vaisseaux { get; set; }
        //int VaisseauSelectionne { get; set; }
    }
}
