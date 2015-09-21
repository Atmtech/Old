using System;
using System.Collections.Generic;
using ATMTECH.Web.Services.Base;
using ATMTECH.XWingCampaign.DAO.Interface;
using ATMTECH.XWingCampaign.Entities;
using ATMTECH.XWingCampaign.Services.Interface;

namespace ATMTECH.XWingCampaign.Services
{
    public class VaisseauService : BaseService, IVaisseauService
    {
        public IDAOVaisseau DAOVaisseau { get; set; }
        public IDAOIntelligenceArtificiel DAOIntelligenceArtificiel { get; set; }
        
        public Vaisseau ObtenirVaisseau(int id)
        {
            Vaisseau vaisseau = DAOVaisseau.ObtenirVaisseau(id);
            vaisseau.ListeMouvement = DAOIntelligenceArtificiel.ObtenirIntelligenceArtificiel(vaisseau);
            return vaisseau;
        }

        public IList<Vaisseau> ObtenirVaisseau()
        {
            return DAOVaisseau.ObtenirVaisseau();
        }

        public IntelligenceArtificiel ObtenirIntelligenceArtificiel(Vaisseau vaisseau, int de, string quadran, string positionVaisseau)
        {
            return DAOIntelligenceArtificiel.ObtenirIntelligenceArtificiel(vaisseau, de, quadran, positionVaisseau);
        }

        public int JetDe()
        {
            Random rnd = new Random();
            return rnd.Next(1, 7);
        }
    }
}
