using ATMTECH.PredictionNHL.DAO;

namespace ATMTECH.PredictionNHL.Services
{
    public class BaseService
    {
    //    public DAOLocalisation DAOLocalisation => new DAOLocalisation();
    //    public DAOExpedition DAOExpedition => new DAOExpedition();
        public DAOUtilisateur DAOUtilisateur => new DAOUtilisateur();
        //public DAOActivite DAOActivite => new DAOActivite();
        //public DAODepense DAODepense => new DAODepense();
    }
}