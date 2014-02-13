using System;
using System.Collections.Generic;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services;

namespace ATMTECH.Mediator.Client
{
    public class MediatorPresenter
    {
        public ClavardageService ClavardageService { get { return new ClavardageService(); } }

        public void EnvoyerClavardage(int utilisateur, string texte, string forums)
        {
            Clavardage clavardage = new Clavardage
                {
                    NoUtilisateur = utilisateur,
                    Date = DateTime.Now,
                    Texte = texte,
                    Forums = forums,
                    Type = texte.IndexOf("/me") == 0 ? "COMMAND" : "CHAT"
                };
            ClavardageService.EnvoyerClavardage(clavardage);
        }
        public IList<Clavardage> ObtenirClavardage(int clavardage)
        {
            return ClavardageService.ObtenirClavardage(clavardage);
        }
        public void EnvoyerCommande(int utilisateur, string command, string forums)
        {
            Clavardage clavardage = new Clavardage
                {
                    NoUtilisateur = utilisateur,
                    Date = DateTime.Now,
                    Texte = command,
                    Forums = forums,
                    Type = "COMMAND"
                };
            ClavardageService.EnvoyerClavardage(clavardage);
        }

        public IList<Clavardage> ObtenirListeClavardage(int nombreAnterieur)
        {
            return ClavardageService.ObtenirListeClavardage(nombreAnterieur);
        }

    }
}
