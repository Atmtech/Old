using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOUtilisateur : BaseDao<Utilisateur, int>, IDAOUtilisateur
    {
        public IDAOVoyageUtilisateur DAOVoyageUtilisateur { get; set; }
        public bool EstUtilisateurValide(string courriel, string motPasse)
        {
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(new Criteria { Column = Utilisateur.COURRIEL, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = courriel });
            criterias.Add(new Criteria { Column = Utilisateur.MOT_PASSE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = motPasse });
            criterias.Add(IsActive());
            Utilisateur utilisateur = GetByCriteria(criterias).FirstOrDefault();
            return utilisateur != null;
        }
        public IList<Utilisateur> ObtenirUtilisateur()
        {
            return GetAllActive();
        }

        public IList<Utilisateur> ObtenirUtilisateur(Voyage voyage)
        {
            DAOVoyageUtilisateur.ObtenirVoyageUtilisateur(voyage);
            return GetAllActive();  
        }

        public Utilisateur ObtenirUtilisateur(string courriel)
        {
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(new Criteria { Column = Utilisateur.COURRIEL, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = courriel });
            Utilisateur utilisateur = GetByCriteria(criterias).FirstOrDefault();
            IList<Voyage> voyages = DAOVoyageUtilisateur.ObtenirVoyageUtilisateur(utilisateur).Select(voyageUtilisateur => voyageUtilisateur.Voyage).ToList();
            utilisateur.Voyages = voyages;
            return utilisateur;
        }
        public int Enregistrer(Utilisateur utilisateur)
        {
            if (utilisateur.Id == 0)
            {
                Save(utilisateur);
                Utilisateur obtenirUtilisateur = ObtenirUtilisateur(utilisateur.Courriel);
                obtenirUtilisateur.IsActive = false;
                return Save(obtenirUtilisateur);
            }
            else
            {
                return Save(utilisateur);
            }
        }
        public Utilisateur ApprouverUtilisateur(string courriel)
        {
            Utilisateur utilisateur = ObtenirUtilisateur(courriel);
            utilisateur.IsActive = true;
            Save(utilisateur);
            return utilisateur;
        }
    }
}
