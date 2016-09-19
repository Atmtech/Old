using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.Pass.Entites;

namespace ATMTECH.Pass.DAO
{
    public class DAOUtilisateur : BaseDao
    {
        public void Ajouter(string nom, string surnom, string courriel, string motdepasse)
        {
            ExecuterSql(string.Format("IF NOT EXISTS (SELECT 1 FROM Utilisateur WHERE Courriel = '{1}') INSERT INTO Utilisateur (Nom,Courriel, motdepasse) VALUES ('{0}','{1}','{2}')", nom.Replace("'", "''"), courriel.Replace("'", "''"), motdepasse.Replace("'", "''")));
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

        public Utilisateur ObtenirUtilisateur(int id)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Nom, Courriel, MotDePasse FROM Utilisateur");
            List<Utilisateur> utilisateurs = (from DataRow dataRow in dataSet.Tables[0].Rows
                                              select
                                                  new Utilisateur
                                                  {
                                                      Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                                      Nom = dataRow["Nom"].ToString(),
                                                      Courriel = dataRow["Courriel"].ToString(),
                                                      MotDePasse = dataRow["MotDePasse"].ToString()
                                                      
                                                  }).ToList();

            return (utilisateurs.FirstOrDefault(x => x.Id == id));
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
                                                      MotDePasse = dataRow["MotDePasse"].ToString()
                                                  }).ToList();

            return (utilisateurs.FirstOrDefault(x => x.Courriel == courriel && x.MotDePasse == motdepasse));
        }


        public void Enregistrer(Utilisateur utilisateur)
        {
            ExecuterSql(string.Format("UPDATE Utilisateur SET Nom ='{0}'  WHERE Id = {1}", utilisateur.Nom, utilisateur.Id));
        }
    }
}