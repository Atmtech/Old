using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ATMTECH.MidiBoardGame.DAO
{
    public class BaseDao
    {

        public DataSet ReturnDataSet(string sql)
        {
            DataSet dataSet = new DataSet();

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                          string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                        {
                            using (
                                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                            {
                                DateTime startDate = DateTime.Now;
                                string start = DateTime.Now + " " + DateTime.Now.Millisecond;

                                sqlCommand.CommandType = CommandType.Text;
                                sqlDataAdapter.SelectCommand = sqlCommand;

                                sqlDataAdapter.Fill(dataSet);

                                DateTime endDate = DateTime.Now;
                                string end = DateTime.Now + " " + DateTime.Now.Millisecond;
                                TimeSpan diffResult = endDate - startDate;


                            }
                        }


                    }

            return dataSet;
        }


        public string ExecuterSql(string sql)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
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
                return ex.Message;

            }
            return string.Empty;
        }

        public DataSet ObtenirDonneesMssql(string sql)
        {
            try
            {
                DataSet dataSet = new DataSet();
                string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                        {
                            DateTime startDate = DateTime.Now;
                            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

                            sqlCommand.CommandType = CommandType.Text;
                            sqlDataAdapter.SelectCommand = sqlCommand;

                            sqlDataAdapter.Fill(dataSet);

                            DateTime endDate = DateTime.Now;
                            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
                            TimeSpan diffResult = endDate - startDate;
                        }
                    }
                }
                return dataSet;
            }
            catch (Exception)
            {
            }
            return null;
        }


    

       
    }
}