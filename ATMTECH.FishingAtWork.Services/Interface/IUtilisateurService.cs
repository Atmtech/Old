using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IUtilisateurService
    {
        Utilisateur ObtenirUtilisateur(string courriel);
    }
}
