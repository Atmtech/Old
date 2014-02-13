using ATMTECH.Achievement.Entities;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.Services.Interface
{
    public interface IUtilisateurService
    {
        bool Creer(User utilisateur);
        bool ConfirmerCreation(User utilisateur);
        void DemandeAmitie(User moiMeme, User ami);
        void ConfirmerAmitie(Amitie amitie);

    }
}
