using System.Collections.Generic;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Mediator.DAO;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services.Interface;

namespace ATMTECH.Mediator.Services
{
    public class ParametreService : IParametreService
    {
        public DAOParametre DAOParametre { get { return new DAOParametre(); } }

        public ParametreService()
        {
            DatabaseSessionManager.ConnectionString = Utils.Configuration.GetConfigurationKey("ConnectionString");
        }

        public string ObtenirVersion()
        {
            return DAOParametre.ObtenirParametre(Parametre.PARAMETRE_VERSION).ValeurParametre;
        }
    }

}
