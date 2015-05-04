using ATMTECH.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Expeditn.Services
{
    public class CourrielService : BaseService, ICourrielService
    {
        public void EnvoyerConfirmationCreationUtilisateur(User utilisateur)
        {
            //Courriel courriel = DAOCourriel.ObtenirMail("CONFIRMATION_CREATION_CLIENT");
            //string sujet = RemplacerAvecNomChamp(ObtenirSujet(courriel), client);
            //string corps = RemplacerAvecNomChamp(ObtenirCorps(courriel), client);
            //EnvoyerCourriel(client.User.Login, courriel.From, sujet, corps);
        }
    }
}
