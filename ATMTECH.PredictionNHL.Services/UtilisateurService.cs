using ATMTECH.PredictionNHL.Entites;
using System.Collections.Generic;
using System.Linq;


namespace ATMTECH.PredictionNHL.Services
{
    public class UtilisateurService : BaseService
    {
        public IList<Utilisateur> Obtenir()
        {
            return DAOUtilisateur.Obtenir();
        }
        public void Enregistrer(Utilisateur utilisateur)
        {

            DAOUtilisateur.Enregistrer(utilisateur);
        }

        public Utilisateur Obtenir(string id)
        {
            return DAOUtilisateur.Obtenir(id).FirstOrDefault();
        }

        


        public Utilisateur ObtenirUtilisateur(string courriel, string motPasse)
        {
            IList<Utilisateur> utilisateurs = DAOUtilisateur.Obtenir();
            return utilisateurs.FirstOrDefault(x => x.Courriel == courriel && x.MotPasse == motPasse);
        }
    }
}