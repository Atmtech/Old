using System;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using ATMTECH.DAO.Interface;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Services.Interface;

namespace ATMTECH.Services
{
    public class DatabaseService : IDatabaseService
    {
        public IDAOMessage DAOMessage { get; set; }


        public string ExecuteSql(string sql, EnumDatabaseVendor enumDatabaseVendor)
        {
            string html = string.Empty;

            if (sql.ToLower().IndexOf("select") >= 0)
            {
                DataSet dataSet = ReturnDataSet(sql, enumDatabaseVendor);

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    html = "<table border=0 style='font-size: 11px;' cellspacing='0' cellPadding='0'>";
                    html += "<tr>";
                    foreach (DataColumn dataColumn in dataSet.Tables[0].Columns)
                    {
                        html += "<td style='font-weight:bold;border-bottom:solid 2px black;'>" + dataColumn.ColumnName + "&nbsp;&nbsp;</td>";
                    }
                    html += "</tr>";
                    int rowCount = 0;
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        rowCount += 1;
                        html += rowCount % 2 > 0 ? "<tr>" : "<tr style='background-color:lightgray;'>";
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            if (row.ItemArray[i].ToString().Length > 150)
                            {
                                html += "<td>" + row.ItemArray[i].ToString().Substring(1, 149) + "</td>";
                            }
                            else
                            {
                                html += "<td>" + row.ItemArray[i] + "</td>";
                            }

                        }
                        html += "</tr>";
                    }

                    html += "</table>";
                }
            }
            else
            {
                switch (enumDatabaseVendor)
                {
                    case EnumDatabaseVendor.Sqlite:
                        using (SQLiteCommand commandCreate = new SQLiteCommand(sql, (SQLiteConnection)DatabaseSessionManager.Session))
                        {
                            object retour = commandCreate.ExecuteScalar();
                            if (retour != null)
                            {
                                html = retour.ToString();
                            }
                        }
                        break;
                    case EnumDatabaseVendor.Mssql:
                        using (SqlCommand commandCreate = new SqlCommand(sql, (SqlConnection)DatabaseSessionManager.Session))
                        {
                            object retour = commandCreate.ExecuteScalar();
                            if (retour != null)
                            {
                                html = retour.ToString();
                            }
                        }
                        break;
                }
            }
            return html;
        }

        private DataSet ReturnDataSet(string sql, EnumDatabaseVendor enumDatabaseVendor)
        {
            DataSet dataSet = new DataSet();

            switch (enumDatabaseVendor)
            {
                case EnumDatabaseVendor.Sqlite:
                    using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter())
                    {
                        using (SQLiteCommand sqlCommand = new SQLiteCommand(sql, (SQLiteConnection)DatabaseSessionManager.Session))
                        {
                            DateTime startDate = DateTime.Now;
                            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

                            sqlCommand.CommandType = CommandType.Text;
                            sqlDataAdapter.SelectCommand = sqlCommand;

                            sqlDataAdapter.Fill(dataSet);

                            DateTime endDate = DateTime.Now;
                            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
                            TimeSpan diffResult = endDate - startDate;

                            // Show sql debug
                            Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                                   diffResult.Milliseconds.ToString() + "ms) :: " + sql);
                        }
                    }
                    break;
                case EnumDatabaseVendor.Mssql:
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(sql, (SqlConnection)DatabaseSessionManager.Session))
                        {
                            DateTime startDate = DateTime.Now;
                            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

                            sqlCommand.CommandType = CommandType.Text;
                            sqlDataAdapter.SelectCommand = sqlCommand;

                            sqlDataAdapter.Fill(dataSet);

                            DateTime endDate = DateTime.Now;
                            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
                            TimeSpan diffResult = endDate - startDate;

                            // Show sql debug
                            Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                                   diffResult.Milliseconds.ToString() + "ms) :: " + sql);
                        }
                    }
                   
                    break;
            }

            return dataSet;
        }

    }
}
