using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOVoyageUtilisateur
    {
        IList<VoyageUtilisateur> ObtenirVoyageUtilisateur(Utilisateur utilisateur);
        IList<VoyageUtilisateur> ObtenirVoyageUtilisateur(Voyage voyage);
        int Enregistrer(VoyageUtilisateur voyageUtilisateur);
    }
}
