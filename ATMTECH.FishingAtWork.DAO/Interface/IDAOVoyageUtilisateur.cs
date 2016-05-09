using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOVoyageUtilisateur
    {
        IList<VoyageUtilisateur> ObtenirVoyageUtilisateur(Utilisateur utilisateur);
        int Enregistrer(VoyageUtilisateur voyageUtilisateur);
    }
}
