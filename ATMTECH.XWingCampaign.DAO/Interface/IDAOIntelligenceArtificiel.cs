using ATMTECH.XWingCampaign.Entities;

namespace ATMTECH.XWingCampaign.DAO.Interface
{
    public interface IDAOIntelligenceArtificiel
    {
        IntelligenceArtificiel ObtenirIntelligenceArtificiel(Vaisseau vaisseau, int de, string quadran, string positionVaisseau);
    }
}
