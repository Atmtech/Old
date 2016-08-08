using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class AjouterExpeditionEtape2Presenter : BaseExpeditnPresenter<IAjouterExpeditionEtape2Presenter>
    {
        public IExpeditionService ExpeditionService { get; set; }

        public IDAOParticipant DAOParticipant { get; set; }
        public IDAOUser DAOUser { get; set; }

        public IAuthenticationService AuthenticationService { get; set; }

        public AjouterExpeditionEtape2Presenter(IAjouterExpeditionEtape2Presenter view)
            : base(view)
        {
        }


        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            AfficherListeParticipant(expedition);

        }

        private void AfficherListeParticipant(Expedition expedition)
        {
            View.ListeParticipant = DAOParticipant.ObtenirParticipant(expedition);
        }

        public int RechercherUtilisateur()
        {
            IList<User> users = DAOUser.SearchUser(View.Recherche);
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));

            IList<User> rtn = new List<User>();
            foreach (User user in users)
            {
                if (expedition.Participant.Count(x => x.Utilisateur.Id == user.Id) == 0)
                {
                    rtn.Add(user);
                }
            }
            View.ListeUtilisateurPourAjouter = rtn;
            return rtn.Count();
        }

        public void AjouterParticipant(string idUser)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            if (expedition.Participant.Count(x => x.Utilisateur.Id.ToString() == idUser.ToString() && x.IsActive) == 0)
            {

                Participant participant = new Participant
                {
                    Utilisateur = DAOUser.GetUser(Convert.ToInt32(idUser)),
                    Expedition = expedition,
                };
                DAOParticipant.Enregistrer(participant);
                AfficherListeParticipant(expedition);
            }
        }

        public void RetirerParticipant(string idUser)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Participant participant = DAOParticipant.ObtenirParticipant(expedition)
                .FirstOrDefault(x => x.Utilisateur.Id.ToString() == idUser.ToString());
            if (participant != null)
            {
                participant.IsActive = false;
                DAOParticipant.Enregistrer(participant);
                AfficherListeParticipant(expedition);
            }
        }

        public void RedirigerEtape3()
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = View.IdExpedition });
            NavigationService.Redirect("AjouterExpeditionEtape3.aspx", queryStrings);
        }
    }
}