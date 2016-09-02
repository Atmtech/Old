using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public class DAOJeu : BaseDao   
    {
        public IList<Jeu> ObtenirListeJeu()
        {

            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Nom, UrlBoardGameGeek FROM Jeu");
            return (from DataRow dataRow in dataSet.Tables[0].Rows
                    select
                        new Jeu
                        {
                            Id = Convert.ToInt32(dataRow["Id"].ToString()),
                            Nom = dataRow["Nom"].ToString(),
                            UrlBoardGameGeek = dataRow["UrlBoardGameGeek"].ToString()
                        }).ToList();
        }

        public void Ajouter(string nom)
        {
            ExecuterSql(string.Format("INSERT INTO Jeu (Nom) VALUES ('{0}')", nom.Replace("'", "''")));
        }

    }
}