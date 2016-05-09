using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOUtilisateur
    {
        bool EstUtilisateurValide(string courriel, string motPasse);
        IList<Utilisateur> ObtenirUtilisateur();
        Utilisateur ObtenirUtilisateur(string courriel);
        int Enregistrer(Utilisateur utilisateur);
        Utilisateur ApprouverUtilisateur(string courriel);
    }
}
