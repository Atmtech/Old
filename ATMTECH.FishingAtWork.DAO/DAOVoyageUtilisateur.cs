using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOVoyageUtilisateur : BaseDao<VoyageUtilisateur, int>, IDAOVoyageUtilisateur
    {
        public IList<VoyageUtilisateur> ObtenirVoyageUtilisateur(Utilisateur utilisateur)
        {
            return GetAllActive().Where(x => x.Utilisateur.Id == utilisateur.Id).ToList();
        }

        public int Enregistrer(VoyageUtilisateur voyageUtilisateur)
        {
            return Save(voyageUtilisateur);
        }
    }
}
