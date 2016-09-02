using System.Data;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public class DAOMidiVote : BaseDao
    {

        public int ObtenirNombreVote(string idMidi)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT count(Utilisateur) as compte FROM MidiVote WHERE Midi = " + idMidi);
            return (int)dataSet.Tables[0].Rows[0]["compte"];
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