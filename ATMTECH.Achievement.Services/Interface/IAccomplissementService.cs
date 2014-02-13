using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.Services.Interface
{
    public interface IAccomplissementService
    {
        void ValidationAccomplissement(Accomplissement accomplissement);
        void Creer(Accomplissement accomplissement);

        void AjouterAccomplissementUtilisateur(Accomplissement accomplissement, bool estPublic, bool estPourAmi,
                                               bool estPrive);
        void VoterAccomplissement(Accomplissement accomplissement);
        IList<Accomplissement> ObtenirAccomplissementActifParCategorie(int idCategorie);
        IList<Categorie> ObtenirCategorieActive();
        IList<File> ObtenirListeFichierBadge();
        IList<AccomplissementUtilisateur> ObtenirListeAccomplissementUtilisateur(int idUtilisateur);
        IList<Trait> ObtenirTrait();
        Categorie ObtenirCategorieParCode(string code);
        Trait ObtenirTraitParCode(string code);
        IList<Accomplissement> ObtenirListeAccomplissementAccompli();
    }
}
