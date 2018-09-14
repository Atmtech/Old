using System.Collections.Generic;
using ATMTECH.Expeditn.DAO;
using ATMTECH.Expeditn.Entites;

namespace ATMTECH.Expeditn.Site.Vues
{
    public class ExpeditionVue : BaseVue
    {
        
        public IList<Expedition> ObtenirMesExpedition(Utilisateur utilisateur)
        {

            return ExpeditionService.ObtenirMesExpedition(utilisateur);
        }

        public Expedition Obtenir(string id)
        {
            return ExpeditionService.Obtenir(id);
        }

        public Utilisateur ObtenirUtilisateur(string id)
        {
            return UtilisateurService.Obtenir(id);
        }

        public void SupprimerActivite(string id)
        {
            new DAOActivite().Supprimer(id);
        }

        public void SupprimerDepense(string id)
        {
            new DAODepense().Supprimer(id);
        }

        public IList<Utilisateur> ObtenirUtilisateur()
        {
            return UtilisateurService.Obtenir();
        }

        public void Enregistrer(Expedition expedition)
        {
            ExpeditionService.Enregistrer(expedition);
        }

        public void Enregistrer(Activite activite)
        {
            ExpeditionService.Enregistrer(activite);
        }

        public void Enregistrer(Depense depense)
        {
            ExpeditionService.Enregistrer(depense);
        }

        public string GenererAffichageDepense(Expedition expedition)
        {
            return ExpeditionService.GenererAffichageDepense(expedition);
        }


    }
}