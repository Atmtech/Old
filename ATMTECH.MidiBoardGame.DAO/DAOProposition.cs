using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.DAO
{
    public class DAOProposition : BaseDao
    {

        public IList<Proposition> ObtenirListeProposition()
        {

            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Jeu, Date, Utilisateur FROM Proposition WHERE Date = DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0)");
            List<Proposition> midis = (from DataRow dataRow in dataSet.Tables[0].Rows
                                select
                                    new Proposition
                                    {
                                        Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                        Jeu = new Jeu { Id = (int)dataRow["Jeu"] },
                                        Date = Convert.ToDateTime(dataRow["Date"].ToString()),
                                        Utilisateur = new Utilisateur { Id = Convert.ToInt32(dataRow["Id"].ToString()) }
                                    }).ToList();


            foreach (Proposition midi in midis)
            {
                midi.Jeu = new DAOJeu().ObtenirListeJeu().FirstOrDefault(x => x.Id == midi.Jeu.Id);
                midi.Utilisateur = new DAOUtilisateur().ObtenirUtilisateur().FirstOrDefault(x => x.Id == midi.Utilisateur.Id);
            }

            return midis;
        }

        public void Supprimer(string idMidi, string idUtilisateur)
        {
            Proposition proposition = ObtenirListeProposition().FirstOrDefault(x => x.Id == Convert.ToInt32(idMidi));
            if (proposition.Utilisateur.Id == Convert.ToInt32(idUtilisateur))
            {
                ExecuterSql(string.Format("DELETE FROM Proposition WHERE Id = {0}", idMidi));
                ExecuterSql(string.Format("DELETE FROM PropositionVote WHERE Proposition = {0}", idMidi));
            }

        }

        public void Ajouter(string idJeu, string idUtilisateur)
        {
            ExecuterSql(string.Format("INSERT INTO Proposition (Jeu, Date, Utilisateur) VALUES ({0}, DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0), {1})", idJeu, idUtilisateur));
        }

    }
}