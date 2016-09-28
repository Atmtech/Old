using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.DAO
{
    public class DAOJeu : BaseDao
    {
        public IList<Jeu> ObtenirListeJeu()
        {

            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Nom, UrlBoardGameGeek, Utilisateur FROM Jeu");
            return (from DataRow dataRow in dataSet.Tables[0].Rows
                    select
                        new Jeu
                        {
                            Id = Convert.ToInt32(dataRow["Id"].ToString()),
                            Nom = dataRow["Nom"].ToString(),
                            UrlBoardGameGeek = dataRow["UrlBoardGameGeek"].ToString(),
                            Utilisateur = new Utilisateur { Id = Convert.ToInt32(dataRow["Utilisateur"].ToString()) },
                        }).ToList();
        }


        public IList<Jeu> ObtenirListeJeuAvecPresence()
        {

            DataSet dataSet = ObtenirDonneesMssql(string.Format("SELECT Jeu.Id as Id, Nom, UrlBoardGameGeek, Jeu.Utilisateur as Utilisateur FROM Jeu inner join Presence on Presence.Utilisateur = Jeu.Utilisateur and Presence.Date = '{0}'", Utilitaires.Utilitaires.Aujourdhui()));
            return (from DataRow dataRow in dataSet.Tables[0].Rows
                    select
                        new Jeu
                        {
                            Id = Convert.ToInt32(dataRow["Id"].ToString()),
                            Nom = dataRow["Nom"].ToString(),
                            UrlBoardGameGeek = dataRow["UrlBoardGameGeek"].ToString(),
                            Utilisateur = new Utilisateur { Id = Convert.ToInt32(dataRow["Utilisateur"].ToString()) },
                        }).ToList();
        }


        public void Ajouter(string nom, string nombreJoueur, Utilisateur utilisateur)
        {
            ExecuterSql(string.Format("INSERT INTO Jeu (Nom, NombreJoueur,utilisateur) VALUES ('{0}','{1}',{2})", nom.Replace("'", "''"), nombreJoueur.Replace("'", "''"), utilisateur.Id));

        }

        public IList<Jeu> ObtenirListeJeuBoardGameGeek(Utilisateur utilisateur)
        {
            try
            {
                List<Jeu> listeJeux = ObtenirListeJeu().Where(x => x.Utilisateur.Id == utilisateur.Id).ToList();
                string result = new WebClient().DownloadString("https://boardgamegeek.com/xmlapi/collection/" + utilisateur.BoardGameGeekNickName + "?own=1");
                BoardGameGeekJeu listeBoardGameGeekJeu;

                XmlSerializer serializer = new XmlSerializer(typeof(BoardGameGeekJeu));

                using (var stream = new StringReader(result))
                using (var reader = XmlReader.Create(stream))
                {
                    listeBoardGameGeekJeu = (BoardGameGeekJeu)serializer.Deserialize(reader);
                }

                IList<Jeu> jeux = new List<Jeu>();
                foreach (Item item in listeBoardGameGeekJeu.Item)
                {
                    if (!item.Name.Text.ToLower().Contains("expansion"))
                    {
                        string nomJeu = item.Name.Text.Replace("â€“", "-").Replace("Ã¯", "ï").Replace("Ã±", "ñ").Replace("Ã©","é");
                        jeux.Add(new Jeu
                        {
                            Nom = nomJeu,
                            Utilisateur = listeJeux.Any(x => x.Nom == nomJeu) ? utilisateur : null
                        });
                    }
                }
                return jeux;

            }
            catch (Exception)
            {


            }
            return null;

        }

        public void Retirer(string nom, Utilisateur utilisateur)
        {
            ExecuterSql(string.Format("DELETE FROM Jeu WHERE Nom = '{0}' and Utilisateur = '{1}'", nom.Replace("'", "''"), utilisateur.Id));
        }
    }
}


