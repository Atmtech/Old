using System.Configuration;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Expeditn.Services;

namespace ATMTECH.Expeditn.Sniper
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseSessionManager.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            new ExpediaService().ObtenirPrixRechercheForfaitExpedia();
        }
    }
}
