using System.Collections.Generic;
using System.Linq;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services.Interface;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Services
{

    public class AcomplissementService : BaseService, IAccomplissementService
    {
        public IMailService MailService { get; set; }
        public IParameterService ParameterService { get; set; }
        public IMessageService MessageService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public IDAOAccomplissement DAOAccomplissement { get; set; }
        public IDAOCategorie DAOCategorie { get; set; }
        public IDAOFile DAOFile { get; set; }
        public IDAOAccomplissementUtilisateur DAOAccomplissementUtilisateur { get; set; }
        public IDAOAccomplissementTrait DAOAccomplissementTrait { get; set; }
        public IDAOTrait DAOTrait { get; set; }

        public void ValidationAccomplissement(Accomplissement accomplissement)
        {
            if (accomplissement.AccomplissementTraits.Count == 0)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.ACH_AUCUNE_QUALITE_ASSOCIE_ACCOMPLISSEMENT);
            }
            if (string.IsNullOrEmpty(accomplissement.Description))
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.ACH_DESCRIPTION_OBLIGATOIRE_CREATION_ACCOMPLISSEMENT);
            }
            if (string.IsNullOrEmpty(accomplissement.Titre))
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.ACH_TITRE_OBLIGATOIRE_CREATION_ACCOMPLISSEMENT);
            }
        }
        public void Creer(Accomplissement accomplissement)
        {
            ValidationAccomplissement(accomplissement);

            int idAccomplissement = DAOAccomplissement.Enregistrer(accomplissement);

            foreach (AccomplissementTrait accomplissementTrait in accomplissement.AccomplissementTraits)
            {
                accomplissementTrait.Accomplissement = DAOAccomplissement.ObtenirAccomplissement(idAccomplissement);
                DAOAccomplissementTrait.Enregistrer(accomplissementTrait);
            }
        }

        public void AjouterAccomplissementUtilisateur(Accomplissement accomplissement, bool estPublic, bool estPourAmi, bool estPrive)
        {
            AccomplissementUtilisateur accomplissementUtilisateur = new AccomplissementUtilisateur
                {
                    Utilisateur = AuthenticationService.AuthenticateUser,
                    Accomplissement = accomplissement,
                    EstPublic = estPublic,
                    EstPourAmi = estPourAmi,
                    EstPrive = estPrive
                };
            DAOAccomplissementUtilisateur.Enregistrer(accomplissementUtilisateur);
        }

        public void VoterAccomplissement(Accomplissement accomplissement)
        {
            accomplissement.NombreVote += 1;
            DAOAccomplissement.Enregistrer(accomplissement);
        }

        public IList<Trait> ObtenirTrait()
        {
            return DAOTrait.ObtenirTrait();
        }

        public Trait ObtenirTraitParCode(string code)
        {
            return DAOTrait.ObtenirTraitParCode(code);
        }
        public IList<Accomplissement> ObtenirAccomplissementActifParCategorie(int idCategorie)
        {
            return DAOAccomplissement.ObtenirAccomplissementActifParCategorie(idCategorie);
        }
        public IList<Categorie> ObtenirCategorieActive()
        {
            IList<Categorie> categories = DAOCategorie.ObtenirTousActive();
            IList<Accomplissement> accomplissements = DAOAccomplissement.ObtenirTousActive();

            foreach (Categorie categorie in categories)
            {
                categorie.NombreAccomplissement = accomplissements.Count(x => x.Categorie.Id == categorie.Id);
            }
            return categories;
        }
        public IList<File> ObtenirListeFichierBadge()
        {
            return DAOFile.GetAllFile().Where(x => x.Category == "badge").ToList();
        }
        public IList<AccomplissementUtilisateur> ObtenirListeAccomplissementUtilisateur(int idUtilisateur)
        {
            return DAOAccomplissementUtilisateur.ObtenirListeAccomplissementUtilisateur(idUtilisateur);
        }
        public IList<Accomplissement> ObtenirListeAccomplissementAccompli()
        {
            return ObtenirListeAccomplissementUtilisateur(AuthenticationService.AuthenticateUser.Id).Select(x => x.Accomplissement).ToList();
        }
        public Categorie ObtenirCategorieParCode(string code)
        {
            return DAOCategorie.ObtenirParCode(code);
        }
    }
}
