using System.Collections.Generic;
using ATMTECH.Mediator.Entities;

namespace ATMTECH.Mediator.Services.Interface
{
    public interface IClavardageService
    {
        IList<Clavardage> ObtenirClavardage(int idLog);
        void EnvoyerClavardage(Clavardage clavardage);
        IList<Utilisateur> ObtenirUtilisateur();
        IList<Clavardage> ObtenirListeClavardage(int nombreAnterieur);
        Utilisateur ObtenirUtilisateurCourant();
    }
}
