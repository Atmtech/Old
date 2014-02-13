using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GeniteurInformationnel.Entities;

namespace GeniteurInformationnel.DAO
{
    public class DAOGeniteurInformationnel
    {
        public string NomServeurSelectionne { get; set; }
        public string NomBDSelectionne { get; set; }
        public string NomTableSelectionne { get; set; }

        public string ConnectionString { get { return "server=" + NomServeurSelectionne + ";Initial Catalog=" + NomBDSelectionne + ";Integrated security=SSPI;Trusted_Connection=True;"; } }

        public IList<Serveur> ObtenirListeServeur()
        {
            IList<Serveur> serveurs = new List<Serveur>();
            serveurs.Add(new Serveur { NomServeur = "SQLV1-DEV\\DEV1" });
            serveurs.Add(new Serveur { NomServeur = "SQLV1-DEV\\DEV2" });
            return serveurs;
        }

        public IList<BaseDonnee> ObtenirListeBD()
        {
            IList<string> listeBD = RetournerValeur("select name from [master].[sys].[databases]", "Name");
            IList<BaseDonnee> baseDonnees = new List<BaseDonnee>();
            foreach (string s in listeBD.OrderBy(x => x.ToLower()))
            {
                if (s.ToLower().IndexOf("pesa") >= 0)
                {
                    baseDonnees.Add(new BaseDonnee { NomBD = s });
                }
            }
            return baseDonnees;
        }


        private DataRowCollection RetournerDatarowCollection(string sql)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0].Rows;
        }

        private IList<string> RetournerValeur(string sql, string colonne)
        {
            DataRowCollection dataRows = RetournerDatarowCollection(sql);
            IList<string> listeValeur = new List<string>();

            foreach (DataRow dataRow in dataRows)
            {
                listeValeur.Add(dataRow[colonne].ToString());
            }
            return listeValeur;
        }



        public IList<Tables> ObtenirListeTable()
        {
            IList<string> listeBD = RetournerValeur("SELECT TABLE_NAME from [" + NomBDSelectionne + "].INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA ='dbo'", "TABLE_NAME");
            IList<Tables> nomTables = new List<Tables>();
            foreach (string s in listeBD.OrderBy(x => x.ToLower()))
            {
                nomTables.Add(new Tables { NomTable = s });
            }
            return nomTables;
        }

        public IList<Colonne> ObtenirListeColonne(string table)
        {
            IList<Colonne> nomColonnes = new List<Colonne>();
            
            IList<Jointure> listeTableJointe = ObtenirListeDesTableJoin(table);
            string listeTable = string.Empty;
            foreach (Jointure jointure in listeTableJointe)
            {
                listeTable += "'" + jointure.NomTable + "',";
            }
            listeTable += "'" + table + "'";

            string sql = string.Format("SELECT * from [{0}].INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME in {1}", NomBDSelectionne, listeTable);
            DataRowCollection dataColumnTableSource = RetournerDatarowCollection(sql);

            foreach (DataRow dataRow in dataColumnTableSource)
            {
                Colonne colonne = new Colonne() { NomColonne = dataRow["COLUMN_NAME"].ToString(), NomTable = dataRow["TABLE_NAME"].ToString(), Type = dataRow["DATA_TYPE"].ToString() };
                if (colonne.NomColonne.ToLower() != "_rowversion")
                {
                    nomColonnes.Add(colonne);
                }

            }

            return nomColonnes;
        }

        public IList<Colonne> ObtenirListeColonne()
        {
            return ObtenirListeColonne(NomTableSelectionne);
        }

        public string ObtenirTypeColonne(string colonne)
        {
            IList<string> listeColonne = RetournerValeur("SELECT DATA_TYPE from [" + NomBDSelectionne + "].INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + NomTableSelectionne + "' and COLUMN_NAME = '" + colonne + "'", "DATA_TYPE");
            return listeColonne.Count > 0 ? listeColonne[0] : "varchar";
        }


        public IList<Jointure> ObtenirListeDesTableJoin(string table)
        {
            IList<Jointure> listeTableJointe = new List<Jointure>();
            string connString = @"server=SQLV2-DEV\DEV2;Initial Catalog=EDIntegrationFonctionnel;Integrated security=SSPI;Trusted_Connection=True;";
            string sql = "spED_ObtenirHierarchie";
            SqlConnection sqlConnection = new SqlConnection(connString);
            string leftJoin = string.Empty;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, sqlConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@TableSource", SqlDbType.VarChar, 255).Value = table;

                DataSet ds = new DataSet();
                da.Fill(ds, "result_name");

                DataTable dt = ds.Tables["result_name"];

                foreach (DataRow row in dt.Rows)
                {
                    Jointure jointure = new Jointure { NomTable = row["NomTable"].ToString(), LibelleJointure = row["LeftJoin"].ToString(), Niveau = row["Niveau"].ToString() };
                    listeTableJointe.Add(jointure);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                sqlConnection.Close();
            }

            return listeTableJointe;
        }

        public string ObtenirLeftJoin(string table)
        {
            string connString = @"server=SQLV2-DEV\DEV2;Initial Catalog=EDIntegrationFonctionnel;Integrated security=SSPI;Trusted_Connection=True;";
            string sql = "spED_ObtenirHierarchie";
            SqlConnection sqlConnection = new SqlConnection(connString);
            string leftJoin = string.Empty;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, sqlConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@TableSource", SqlDbType.VarChar, 255).Value = table;

                DataSet ds = new DataSet();
                da.Fill(ds, "result_name");

                DataTable dt = ds.Tables["result_name"];

                foreach (DataRow row in dt.Rows)
                {
                    leftJoin += "\t" + row["LeftJoin"] + "\r";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                sqlConnection.Close();
            }

            return leftJoin;
        }
    }
}
