using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public class DAOMidiVote : BaseDao
    {
        public IList<MidiVote> ObtenirMidiVote()
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT MidiVote.Id as Id,Midi,MidiVote.Utilisateur as IdUtilisateur FROM MidiVote INNER JOIN Midi on Midi.Id = MidiVote.Midi and Midi.Date = DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0)");
            return (from DataRow dataRow in dataSet.Tables[0].Rows
                                select
                                    new MidiVote
                                    {
                                        Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                        Midi = new Midi { Id = Convert.ToInt32(dataRow["Midi"].ToString()) },
                                        Utilisateur = new Utilisateur { Id = Convert.ToInt32(dataRow["IdUtilisateur"].ToString()) }
                                    }).ToList();
        }
        public int ObtenirNombreVote(string idMidi)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT count(Utilisateur) as compte FROM MidiVote WHERE Midi = " + idMidi);
            return (int)dataSet.Tables[0].Rows[0]["compte"];
        }

        public IList<Utilisateur> ObtenirVoteur()
        {
            IList<MidiVote> obtenirMidiVote = ObtenirMidiVote();
            IList<Utilisateur> utilisateurs = new List<Utilisateur>();
            foreach (MidiVote midiVote in obtenirMidiVote)
            {
                if (utilisateurs.Count(x => x.Id == midiVote.Utilisateur.Id) == 0)
                {
                    midiVote.Utilisateur = new DAOUtilisateur().ObtenirUtilisateur().FirstOrDefault(x => x.Id == midiVote.Utilisateur.Id);
                    utilisateurs.Add(midiVote.Utilisateur);
                }
            }
            return utilisateurs;
        }

        public void Ajouter(string idMidi, string idUtilisateur)
        {
            ExecuterSql(string.Format("IF NOT EXISTS(SELECT 1 FROM MidiVote WHERE Midi = {0} and Utilisateur = {1}) INSERT INTO MidiVote (Midi, Utilisateur) VALUES ({0},{1})", idMidi, idUtilisateur));
        }

        public void Retirer(string idMidi, string idUtilisateur)
        {
            ExecuterSql(string.Format("DELETE FROM MidiVote WHERE Midi = {0} and Utilisateur = {1}", idMidi, idUtilisateur));
        }
    }
}