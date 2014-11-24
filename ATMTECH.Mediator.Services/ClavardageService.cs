using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Mediator.DAO;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services.Interface;

namespace ATMTECH.Mediator.Services
{
    public class ClavardageService : IClavardageService
    {
        public DAOClavardage DAOClavardage { get { return new DAOClavardage(); } }
        public DAOUtilisateurs DAOUtilisateurs { get { return new DAOUtilisateurs(); } }

        public ClavardageService()
        {
            DatabaseSessionManager.ConnectionString = Utils.Configuration.GetConfigurationKey("ConnectionString");
        }
       
        public Utilisateur ObtenirUtilisateurCourant()
        {
            return ObtenirUtilisateur().FirstOrDefault(x => x.NomUtilisateur2 == Environment.UserName);
        }

        public DateTime ObtenirDateClavardage(int noClavardage)
        {
            return DAOClavardage.ObtenirDateClavardage(noClavardage);
        }
        
        public int ObtenirMaximumClavardage()
        {
            return DAOClavardage.ObtenirMaximumClavardage();
        }

        public IList<Clavardage> ObtenirClavardage(int currentLog)
        {
            return DAOClavardage.ObtenirClavardage(currentLog);
        }

        public void EnvoyerClavardage(Clavardage clavardage)
        {
            DAOClavardage.EnregistrerClavardage(clavardage);
        }

        public IList<Utilisateur> ObtenirUtilisateur()
        {
            return DAOUtilisateurs.ObtenirListeUtilisateur();
        }
    }
}
