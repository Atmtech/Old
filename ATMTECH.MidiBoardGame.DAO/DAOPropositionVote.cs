using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.DAO
{
    public class DAOPropositionVote : BaseDao
    {
        public IList<PropositionVote> ObtenirPropositionVote()
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT PropositionVote.Id as Id,Proposition,PropositionVote.Utilisateur as IdUtilisateur FROM PropositionVote INNER JOIN Proposition on Proposition.Id = PropositionVote.Proposition and Proposition.Date = DATEADD(dd, DATEDIFF(dd, 0, getdate()), 0)");
            return (from DataRow dataRow in dataSet.Tables[0].Rows
                                select
                                    new PropositionVote
                                    {
                                        Id = Convert.ToInt32(dataRow["Id"].ToString()),
                                        Proposition = new Proposition { Id = Convert.ToInt32(dataRow["Proposition"].ToString()) },
                                        Utilisateur = new Utilisateur { Id = Convert.ToInt32(dataRow["IdUtilisateur"].ToString()) }
                                    }).ToList();
        }
        public int ObtenirNombreVote(string idMidi)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT count(Utilisateur) as compte FROM PropositionVote WHERE Proposition = " + idMidi);
            return (int)dataSet.Tables[0].Rows[0]["compte"];
        }

        public IList<Utilisateur> ObtenirVoteur()
        {
            IList<PropositionVote> obtenirMidiVote = ObtenirPropositionVote();
            IList<Utilisateur> utilisateurs = new List<Utilisateur>();
            foreach (PropositionVote midiVote in obtenirMidiVote)
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
            ExecuterSql(string.Format("IF NOT EXISTS(SELECT 1 FROM PropositionVote WHERE Proposition = {0} and Utilisateur = {1}) INSERT INTO PropositionVote (Proposition, Utilisateur) VALUES ({0},{1})", idMidi, idUtilisateur));
        }

        public void Retirer(string idMidi, string idUtilisateur)
        {
            ExecuterSql(string.Format("DELETE FROM PropositionVote WHERE Proposition = {0} and Utilisateur = {1}", idMidi, idUtilisateur));
        }

        public void Supprimer(string id, string idUtilisateur)
        {
            ExecuterSql(string.Format("DELETE FROM Proposition WHERE Id = {0} and Utilisateur = {1}", id, idUtilisateur));
        }
    }
}