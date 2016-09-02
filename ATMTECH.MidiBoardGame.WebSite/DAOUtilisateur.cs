using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public class DAOUtilisateur : BaseDao
    {
        public void Ajouter(string nom, string courriel, string motdepasse)
        {
            ExecuterSql(string.Format("IF NOT EXISTS (SELECT 1 FROM Utilisateur WHERE Courriel = '{1}') INSERT INTO Utilisateur (Nom, Courriel, motdepasse) VALUES ('{0}','{1}','{2}')", nom.Replace("'", "''"), courriel.Replace("'", "''"), motdepasse.Replace("'", "''")));
        }

        public bool EstIdentifie(string courriel, string motdepasse)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Nom, Courriel, MotDePasse FROM Utilisateur");
            List<Utilisateur> utilisateurs = (from DataRow dataRow in dataSet.Tables[0].Rows
                                              select
                                                  new Utilisateur
                                                  {
                                                      Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                                      Nom = dataRow["Nom"].ToString(),
                                                      Courriel = dataRow["Courriel"].ToString(),
                                                      MotDePasse = dataRow["MotDePasse"].ToString(),
                                                  }).ToList();

            return (utilisateurs.Count(x => x.Courriel == courriel && x.MotDePasse == motdepasse)) > 0;
        }

        public IList<Utilisateur> ObtenirUtilisateur()
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Nom, Courriel, MotDePasse FROM Utilisateur");
           return (from DataRow dataRow in dataSet.Tables[0].Rows
                                              select
                                                  new Utilisateur
                                                  {
                                                      Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                                      Nom = dataRow["Nom"].ToString(),
                                                      Courriel = dataRow["Courriel"].ToString(),
                                                      MotDePasse = dataRow["MotDePasse"].ToString(),
                                                  }).ToList(); 
        }
        public Utilisateur ObtenirUtilisateur(string courriel, string motdepasse)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Nom, Courriel, MotDePasse FROM Utilisateur");
            List<Utilisateur> utilisateurs = (from DataRow dataRow in dataSet.Tables[0].Rows
                                              select
                                                  new Utilisateur
                                                  {
                                                      Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                                      Nom = dataRow["Nom"].ToString(),
                                                      Courriel = dataRow["Courriel"].ToString(),
                                                      MotDePasse = dataRow["MotDePasse"].ToString(),
                                                  }).ToList();

            return (utilisateurs.FirstOrDefault(x => x.Courriel == courriel && x.MotDePasse == motdepasse));
        }


    }
}