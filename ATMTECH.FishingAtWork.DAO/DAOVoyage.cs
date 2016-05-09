using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOVoyage : BaseDao<Voyage, int>, IDAOVoyage
    {
        public IDAOVoyageUtilisateur DAOVoyageUtilisateur { get; set; }


        public IList<Voyage> ObtenirVoyage()
        {
            return GetAllActive();
        }

        public int Enregistrer(Voyage voyage)
        {
            return Save(voyage);
        }
    }
}
