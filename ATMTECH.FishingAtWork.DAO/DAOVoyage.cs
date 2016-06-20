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
        public Voyage ObtenirVoyage(int id)
        {
            return GetById(id);
        }
        public IList<Voyage> ObtenirVoyage(Utilisateur utilisateur)
        {
            IList<VoyageUtilisateur> obtenirVoyageUtilisateur = DAOVoyageUtilisateur.ObtenirVoyageUtilisateur(utilisateur);
            return obtenirVoyageUtilisateur.Select(voyageUtilisateur => voyageUtilisateur.Voyage).ToList();
        }
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
