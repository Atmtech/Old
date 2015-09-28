using System.Data.SqlClient;
using ATMTECH.DAO.SessionManager;

namespace ATMTECH.Mediator.DAO
{
    public class DAOServeur
    {
        public bool EstServeurExistant()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseSessionManager.ConnectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}
