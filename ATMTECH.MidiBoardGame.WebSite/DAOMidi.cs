using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public class DAOMidi : BaseDao
    {

        public IList<Midi> ObtenirListeMidi()
        {

            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Jeu, Date, Utilisateur FROM Midi WHERE Date = DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0)");
            List<Midi> midis = (from DataRow dataRow in dataSet.Tables[0].Rows
                                select
                                    new Midi
                                    {
                                        Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                        Jeu = new Jeu { Id = (int)dataRow["Jeu"] },
                                        Date = Convert.ToDateTime(dataRow["Date"].ToString()),
                                        Utilisateur = new Utilisateur { Id = Convert.ToInt32(dataRow["Id"].ToString()) }
                                    }).ToList();


            foreach (Midi midi in midis)
            {
                midi.Jeu = new DAOJeu().ObtenirListeJeu().FirstOrDefault(x => x.Id == midi.Jeu.Id);
                midi.Utilisateur = new DAOUtilisateur().ObtenirUtilisateur().FirstOrDefault(x => x.Id == midi.Utilisateur.Id);
            }

            return midis;
        }

        public void Supprimer(string idMidi, string idUtilisateur)
        {
            Midi midi = ObtenirListeMidi().FirstOrDefault(x => x.Id == Convert.ToInt32(idMidi));
            if (midi.Utilisateur.Id == Convert.ToInt32(idUtilisateur))
            {
                ExecuterSql(string.Format("DELETE FROM Midi WHERE Id = {0}", idMidi));
                ExecuterSql(string.Format("DELETE FROM MidiVote WHERE Midi = {0}", idMidi));
            }

        }

        public void Ajouter(string idJeu, string idUtilisateur)
        {
            ExecuterSql(string.Format("INSERT INTO Midi (Jeu, Date, Utilisateur) VALUES ({0}, DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0), {1})", idJeu, idUtilisateur));
        }

    }
}