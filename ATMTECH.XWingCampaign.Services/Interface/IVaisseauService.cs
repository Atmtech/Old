using System.Collections.Generic;
using ATMTECH.XWingCampaign.Entities;

namespace ATMTECH.XWingCampaign.Services.Interface
{
    public interface IVaisseauService
    {
        Vaisseau ObtenirVaisseau(int id);
        IList<Vaisseau> ObtenirVaisseau();
        IntelligenceArtificiel ObtenirIntelligenceArtificiel(Vaisseau vaisseau, int de, string quadran, string positionVaisseau);
        int JetDe();
    }
}
