using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOEmplacement : BaseDao<Emplacement, int>, IDAOEmplacement
    {
        public IList<Emplacement> ObtenirEmplacement()
        {
            return GetAllActive();
        }

        public int Enregistrer(Emplacement emplacement)
        {
            return Save(emplacement);
        }
    }
}
