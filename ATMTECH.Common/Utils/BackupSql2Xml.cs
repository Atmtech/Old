using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Ionic.Zip;

namespace ATMTECH.Common.Utils
{
    public class BackupSql2Xml
    {
        public IList<string> Error { get; set; }
        public string Backup(string tableName, string connectionString, string emplacementSauvegarde)
        {
            using (DataSet dSetBackup = new DataSet())
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter dAd = new SqlDataAdapter("select * from " + tableName, conn))
                    {
                        dAd.Fill(dSetBackup, tableName);
                    }
                }
               
                CreateBackupSpaceIfNotExist(emplacementSauvegarde);
                dSetBackup.WriteXml(emplacementSauvegarde + "\\" + tableName + ".xml",XmlWriteMode.WriteSchema);
                return "Backup de la table " + tableName + " Réussi!";
            }
        }
        private static void CreateBackupSpaceIfNotExist(string emplacementSauvegarde)
        {
            if (!Directory.Exists(emplacementSauvegarde))
            {
                Directory.CreateDirectory(emplacementSauvegarde);
            }
        }
        public DataSet ListBackup(string connectionString)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            DataSet datasetReturn = new DataSet();
            SqlDataAdapter dataAdapterListBackup = new SqlDataAdapter("SELECT emplacement,date from BackupXML", myConnection);
            dataAdapterListBackup.Fill(datasetReturn, "BackupXML");
            return datasetReturn;
        }
        public DataTable RetrieveAllObjectTable(string connectionString)
        {
            const string sql = "SELECT *, name AS table_name FROM sys.tables WHERE Type = 'U' and name <> 'BACKUPXML' ORDER BY table_name";

            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            SqlCommand command = new SqlCommand(sql, myConnection);

            DataTable table = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(table);
            return table;
        }
        public void BackupAll(string connectionString, string backupPath, string date)
        {
            string repertoire = backupPath + "\\" + date;
            const string zipFile = "backup.zip";

            // Créer le répertoire de backup
            if (!Directory.Exists(repertoire))
            {
                Directory.CreateDirectory(repertoire);
            }
            else
            {
                // Supprimer tout les fichiers
                Directory.Delete(repertoire, true);
                Directory.CreateDirectory(repertoire);
            }


            try
            {
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                SqlCommand command = myConnection.CreateCommand();
                command.CommandText = "INSERT INTO BackupXML (emplacement, date, zipFile) values ('" + repertoire + "','" + date.Replace("_", ":") + "','" + zipFile + "')";
                command.ExecuteNonQuery();
                myConnection.Close();

            }
            catch (Exception)
            {
                
            }

            // Backup chaque ligne 
            DataTable dataTable = RetrieveAllObjectTable(connectionString);

            // creer le fichier Zip
            using (ZipFile zip = new ZipFile())
            {

                foreach (DataRow item in dataTable.Rows)
                {

                    Backup(item.ItemArray[0].ToString(), connectionString, repertoire);
                }

                zip.AddDirectory(repertoire);
                zip.Save(repertoire + "\\" + zipFile);
            }

            // supprimer toute les fichiers restant
            foreach (DataRow item in dataTable.Rows)
            {
                File.Delete(repertoire + "\\" + item.ItemArray[0] + ".xml");
            }
        }
        public void RestoreAll(string connectionString, string backupPath, string date)
        {

            string repertoire = backupPath + "\\" + date;

            // Extraire tout les fichiers du zip
            using (ZipFile zip = ZipFile.Read(repertoire + "\\backup.zip"))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(repertoire, ExtractExistingFileAction.OverwriteSilently);
                }

            }

            // Backup chaque ligne 
            DataTable dataTable = RetrieveAllObjectTable(connectionString);

            foreach (DataRow item in dataTable.Rows)
            {
                Restore(item.ItemArray[0].ToString(), connectionString, repertoire);
            }

            // supprimer les fichiers 
            foreach (DataRow item in dataTable.Rows)
            {
                File.Delete(repertoire + "\\" + item.ItemArray[0] + ".xml");
            }
        }
        public string Restore(string tableName, string connectionString, string emplacementSauvegarde)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            SqlTransaction sqlTransaction = myConnection.BeginTransaction();
            SqlCommand command = myConnection.CreateCommand();
            command.Transaction = sqlTransaction;

            try
            {
                command.CommandText = "DELETE FROM " + tableName;
                command.ExecuteNonQuery();


                // dÉtecter que la table a une colonne identity
                DataSet dSetIdentity = new DataSet();
                command.CommandText = "SELECT OBJECTPROPERTY(OBJECT_ID('" + tableName + "'),'TableHasIdentity')";
                SqlDataAdapter sqlDataAdapterIdentity = new SqlDataAdapter(command);
                sqlDataAdapterIdentity.Fill(dSetIdentity, tableName);
                string estIdentity = dSetIdentity.Tables[0].Rows[0].ItemArray[0].ToString();

                if (estIdentity == "1")
                {
                    command.CommandText = "SET IDENTITY_INSERT " + tableName + " ON";
                    command.ExecuteNonQuery();
                }


                DataSet dSetBackup = new DataSet();
                command.CommandText = "select * from " + tableName;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                sqlDataAdapter.Fill(dSetBackup, tableName);

                DataSet dSet = new DataSet();
                
                dSet.ReadXml(emplacementSauvegarde + "/" + tableName + ".xml",XmlReadMode.ReadSchema);
                foreach (DataRow row in dSet.Tables[0].Rows)
                {
                    dSetBackup.Tables[0].NewRow();
                    dSetBackup.Tables[0].Rows.Add(row.ItemArray);
                }

                
                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(myConnection, SqlBulkCopyOptions.KeepIdentity, sqlTransaction);
                sqlBulkCopy.DestinationTableName = dSetBackup.Tables[0].TableName;
                sqlBulkCopy.WriteToServer(dSetBackup.Tables[0]);

                if (estIdentity == "1")
                {
                    command.CommandText = "SET IDENTITY_INSERT " + tableName + " OFF";
                    command.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
                return "Restore de la table " + tableName + " réussi";
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                if (Error == null)
                {
                    Error = new List<string>();
                }
                Error.Add(ex.Message);
                return "erreur: " + ex.Message;

            }
        }
    }


}
