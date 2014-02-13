using System.Collections.Generic;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Mediator.DAO;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services.Interface;

namespace ATMTECH.Mediator.Services
{
    public class ClavardageService : IMediatorService
    {
        public DAOClavardage DAOClavardage { get { return new DAOClavardage(); } }
        public DAOUtilisateurs DAOUtilisateurs { get { return new DAOUtilisateurs(); } }

        public ClavardageService()
        {
            DatabaseSessionManager.ConnectionString = Utils.Configuration.GetConfigurationKey("ConnectionString");
        }
      
        public IList<Clavardage> ObtenirListeClavardage(int nombreAnterieur)
        {
            return DAOClavardage.ObtenirListeClavardage(nombreAnterieur);
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
