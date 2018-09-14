using ATMTECH.Expeditn.DAO;

namespace ATMTECH.Expeditn.Services
{
    public class BaseService
    {
        public DAOLocalisation DAOLocalisation => new DAOLocalisation();
        public DAOExpedition DAOExpedition => new DAOExpedition();
        public DAOUtilisateur DAOUtilisateur => new DAOUtilisateur();
        public DAOActivite DAOActivite => new DAOActivite();
        public DAODepense DAODepense => new DAODepense();
    }
}