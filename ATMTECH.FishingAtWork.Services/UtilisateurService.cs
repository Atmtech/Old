using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
   public  class UtilisateurService : BaseService, IUtilisateurService
    {
       public IDAOUtilisateur DAOUtilisateur { get; set; }
       public Utilisateur ObtenirUtilisateur(string courriel)
       {
           return DAOUtilisateur.ObtenirUtilisateur(courriel);
       }

       public Utilisateur ApprouverUtilisateur(string courriel)
       {
           return DAOUtilisateur.ApprouverUtilisateur(courriel);
       }
    }
}
