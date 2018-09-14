using ATMTECH.Expeditn.Entites;

namespace ATMTECH.Expeditn.Site.Vues
{
    public class UtilisateurVue : BaseVue
    {
        public bool Authentification(string courriel, string motPasse)
        {
            return UtilisateurService.ObtenirUtilisateur(courriel, motPasse) != null;
        }

        public Utilisateur ObtenirUtilisateur(string courriel, string motPasse)
        {
            return UtilisateurService.ObtenirUtilisateur(courriel, motPasse);
        }

        public void Enregistrer(Utilisateur utilisateur)
        {
            UtilisateurService.Enregistrer(utilisateur);
        }
    }
}