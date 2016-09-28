using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.DAO
{
    public class DAOUtilisateur : BaseDao
    {
        public const string SQL_UTILISATEUR =
            "SELECT Id, Nom, Courriel, MotDePasse,BoardGameGeekNickName, Gravatar FROM Utilisateur";
        public void Ajouter(string nom, string surnom, string courriel, string motdepasse)
        {
            ExecuterSql(string.Format("IF NOT EXISTS (SELECT 1 FROM Utilisateur WHERE Courriel = '{1}') INSERT INTO Utilisateur (Nom,Courriel, motdepasse,BoardGameGeekNickName, Gravatar) VALUES ('{0}','{1}','{2}','{3}','{1}')", nom.Replace("'", "''"), courriel.Replace("'", "''"), motdepasse.Replace("'", "''"), surnom.Replace("'", "''")));
        }

        public bool EstIdentifie(string courriel, string motdepasse)
        {
            DataSet dataSet = ObtenirDonneesMssql(SQL_UTILISATEUR);
            List<Utilisateur> utilisateurs = (from DataRow dataRow in dataSet.Tables[0].Rows
                                              select
                                                  new Utilisateur
                                                  {
                                                      Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                                      Nom = dataRow["Nom"].ToString(),
                                                      Courriel = dataRow["Courriel"].ToString(),
                                                      MotDePasse = dataRow["MotDePasse"].ToString(),
                                                      BoardGameGeekNickName = dataRow["BoardGameGeekNickName"].ToString(),
                                                      Gravatar = dataRow["Gravatar"].ToString(),
                                                  }).ToList();

            return (utilisateurs.Count(x => x.Courriel == courriel && x.MotDePasse == motdepasse)) > 0;
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            DataSet dataSet = ObtenirDonneesMssql(SQL_UTILISATEUR);
            List<Utilisateur> utilisateurs = (from DataRow dataRow in dataSet.Tables[0].Rows
                                              select
                                                  new Utilisateur
                                                  {
                                                      Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                                      Nom = dataRow["Nom"].ToString(),
                                                      Courriel = dataRow["Courriel"].ToString(),
                                                      MotDePasse = dataRow["MotDePasse"].ToString(),
                                                      BoardGameGeekNickName = dataRow["BoardGameGeekNickName"].ToString(),
                                                      Gravatar = dataRow["Gravatar"].ToString(),
                                                  }).ToList();

            return (utilisateurs.FirstOrDefault(x => x.Id == id));
        }
        public IList<Utilisateur> ObtenirUtilisateur()
        {
            DataSet dataSet = ObtenirDonneesMssql(SQL_UTILISATEUR);
            return (from DataRow dataRow in dataSet.Tables[0].Rows
                    select
                        new Utilisateur
                        {
                            Id = Convert.ToInt32(dataRow["Id"].ToString()),
                            Nom = dataRow["Nom"].ToString(),
                            Courriel = dataRow["Courriel"].ToString(),
                            MotDePasse = dataRow["MotDePasse"].ToString(),
                            BoardGameGeekNickName = dataRow["BoardGameGeekNickName"].ToString(),
                            Gravatar = dataRow["Gravatar"].ToString(),
                        }).ToList();
        }
        public Utilisateur ObtenirUtilisateur(string courriel, string motdepasse)
        {
            DataSet dataSet = ObtenirDonneesMssql(SQL_UTILISATEUR);
            List<Utilisateur> utilisateurs = (from DataRow dataRow in dataSet.Tables[0].Rows
                                              select
                                                  new Utilisateur
                                                  {
                                                      Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                                      Nom = dataRow["Nom"].ToString(),
                                                      Courriel = dataRow["Courriel"].ToString(),
                                                      MotDePasse = dataRow["MotDePasse"].ToString(),
                                                      BoardGameGeekNickName = dataRow["BoardGameGeekNickName"].ToString(),
                                                      Gravatar = dataRow["Gravatar"].ToString(),
                                                  }).ToList();

            return (utilisateurs.FirstOrDefault(x => x.Courriel == courriel && x.MotDePasse == motdepasse));
        }


        public void Enregistrer(Utilisateur utilisateur)
        {
            ExecuterSql(string.Format("UPDATE Utilisateur SET Nom ='{0}', BoardGameGeekNickName ='{1}', Gravatar='{3}' WHERE Id = {2}", utilisateur.Nom, utilisateur.BoardGameGeekNickName, utilisateur.Id, utilisateur.Gravatar));
        }
    }
}