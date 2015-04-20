using System;
using System.Data;
using System.Data.SqlClient;
using ATMTECH.Common.Utils;
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

                    case EnumDatabaseVendor.Mssql:
                        using (SqlCommand commandCreate = new SqlCommand(sql, (SqlConnection)DatabaseSessionManager.Session))
                        {
                            try
                            {
                                object retour = commandCreate.ExecuteScalar();
                                if (retour != null)
                                {
                                    html = retour.ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                html = ex.Message;
                            }

                        }
                        break;
                }
            }
            return html;
        }

        public string CreationFichierSauvegarde(string repertoireSauvegarde, string nomBaseDonnee)
        {

            string nomServeur = GetServerName();
            string dateFichier = string.Format("{0}_{1}_{2}_{3}_{4}_{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            string nomFichier = string.Format("{0}_{1}.bak", nomBaseDonnee, dateFichier);
            string sqlBackup = string.Format("BACKUP DATABASE [{0}] TO DISK = N'{1}\\{2}'", nomBaseDonnee, repertoireSauvegarde, nomFichier);
            string serveur = "Server=" + nomServeur + ";Database=master;Integrated Security=True";
            string retour = string.Empty;


            SqlConnection connectionServeur = new SqlConnection(serveur);
            SqlCommand commandeRestaure = new SqlCommand(sqlBackup, connectionServeur);

            try
            {
                connectionServeur.Open();
                commandeRestaure.ExecuteNonQuery();
                retour = "Création de la copie de sauvegarde sur " + nomServeur + " de la base [" + nomBaseDonnee + "] en date du: " + DateTime.Now + " avec succès";
            }

            catch (Exception ex)
            {

                retour = "Erreur " + ex;
            }

            finally
            {
                if (connectionServeur.State == ConnectionState.Open)
                {
                    connectionServeur.Close();
                }
            }


            return retour;
        }
        public string RestaurerFichierSauvegarde(string fichier, string nomBaseDonnee)
        {
            string nomServeur = GetServerName();
            string sqlRestaure = string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE [{0}] FROM  DISK = N'{1}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5;ALTER DATABASE [{0}] SET MULTI_USER ", nomBaseDonnee, fichier);
            string serveur = string.Format("Server={0};Database=master;Integrated Security=True", nomServeur);
            string retour = string.Empty;

            SqlConnection connectionServeur = new SqlConnection(serveur);
            SqlCommand commandeRestaure = new SqlCommand(sqlRestaure, connectionServeur);

            try
            {
                connectionServeur.Open();
                commandeRestaure.ExecuteNonQuery();
                retour = "Restauration sur " + nomServeur + " de la base [" + nomBaseDonnee + "] en date du: " + DateTime.Now + " avec succès";
            }

            catch (Exception ex)
            {

                retour = "Erreur " + ex;
            }

            finally
            {
                if (connectionServeur.State == ConnectionState.Open)
                {
                    connectionServeur.Close();
                }
            }

            return retour;
        }

        public string RestoreMssqlBackup(string BackUpLocation, string BackUpFileName, string DatabaseName)
        {
            //string ServerName = GetServerName();
            //string rtn;

            //const string SQLRestore = @"ALTER DATABASE [" + DatabaseName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE [" + DatabaseName + "] FROM  DISK = N'C:\Website\admin.boutiquecorpo.com\Data\ShoppingCartRestore.bak' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5;ALTER DATABASE [" + DatabaseName + "] SET MULTI_USER";
            //string svr = "Server=" + ServerName + ";Database=master;Integrated Security=True";

            //SqlConnection cnBk = new SqlConnection(svr);
            //SqlCommand cmdBkUp = new SqlCommand(SQLRestore, cnBk);

            //try
            //{
            //    cnBk.Open();
            //    cmdBkUp.ExecuteNonQuery();
            //    rtn = "SQLRestore ######## Server name " + ServerName + " Database [" + DatabaseName + "] Restore\n Date : " + DateTime.Now.ToString();
            //}

            //catch (Exception ex)
            //{

            //    rtn = "Erreur " + ex.ToString();
            //}

            //finally
            //{
            //    if (cnBk.State == ConnectionState.Open)
            //    {

            //        cnBk.Close();
            //    }
            //}

            return string.Empty;
        }

        public string GetServerName()
        {
            System.Data.Common.DbConnectionStringBuilder builder = new System.Data.Common.DbConnectionStringBuilder
                {
                    ConnectionString = DatabaseSessionManager.ConnectionString
                };

            return builder["Server"] as string;
        }
        public string CreateMssqlBackup(string BackUpLocation, string BackUpFileName, string DatabaseName)
        {
            string ServerName = GetServerName();
            string rtn;
            DatabaseName = "[" + DatabaseName + "]";

            string fileUNQ = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

            BackUpFileName = BackUpFileName + fileUNQ + ".bak";
            string SQLBackUp = @"BACKUP DATABASE " + DatabaseName + " TO DISK = N'" + BackUpLocation + @"\" + BackUpFileName + @"'";

            string svr = "Server=" + ServerName + ";Database=master;Integrated Security=True";

            SqlConnection cnBk = new SqlConnection(svr);
            SqlCommand cmdBkUp = new SqlCommand(SQLBackUp, cnBk);

            try
            {
                cnBk.Open();
                cmdBkUp.ExecuteNonQuery();
                rtn = "SQLBackUp ######## Server name " + ServerName + " Database " + DatabaseName + " copie de sauvegarde sur " + BackUpLocation + @"\" + BackUpFileName + "\n Date : " + DateTime.Now.ToString();
            }

            catch (Exception ex)
            {

                rtn = "Erreur " + ex.ToString();
            }

            finally
            {
                if (cnBk.State == ConnectionState.Open)
                {

                    cnBk.Close();
                }
            }

            return rtn;
        }
        private DataSet ReturnDataSet(string sql, EnumDatabaseVendor enumDatabaseVendor)
        {
            DataSet dataSet = new DataSet();

            switch (enumDatabaseVendor)
            {
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
                            Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                                   diffResult.Milliseconds.ToString() + "ms) :: " + sql);
                        }
                    }

                    break;
            }

            return dataSet;
        }

    }
}
