using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.Services.Interface
{
    public interface IUtilisateurService
    {
        void Creer(User user);
        void Confirmer(User user);
        void Enregistrer(User utilisateur);
    }
}
