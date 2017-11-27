using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ATMTECH.Tournoi.DAO
{
    public class BaseDAO
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; ;
            }
        }

        public void ExecuterSql(string sql)
        {
            try
            {
               
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    sqlConnection.Open();
                    sqlConnection.FireInfoMessageEventOnUserErrors = true;

                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.CommandTimeout = 0;
                        Debug.WriteLine(sql);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }

        }

        public DataSet ObtenirDonneesMssql(string sql)
        {
            try
            {
                DataSet dataSet = new DataSet();
             
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                        {
                            if (connection.State == ConnectionState.Open)
                            {
                                sqlCommand.CommandType = CommandType.Text;
                                sqlDataAdapter.SelectCommand = sqlCommand;
                                sqlDataAdapter.Fill(dataSet);
                            }
                        }
                    }
                }
                return dataSet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
