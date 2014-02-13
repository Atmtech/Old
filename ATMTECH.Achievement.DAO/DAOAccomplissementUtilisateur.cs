using System.Collections.Generic;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.Achievement.DAO
{
    public class DAOAccomplissementUtilisateur : BaseDao<AccomplissementUtilisateur, int>, IDAOAccomplissementUtilisateur
    {
        public IDAOAccomplissement DAOAccomplissement { get; set; }

        public IList<AccomplissementUtilisateur> ObtenirListeAccomplissementUtilisateur(int idUtilisateur)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaCategorie = new Criteria { Column = AccomplissementUtilisateur.UTILISATEUR, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idUtilisateur.ToString() };
            criterias.Add(criteriaCategorie);
            criterias.Add(IsActive());
            IList<AccomplissementUtilisateur> accomplissementUtilisateurs = GetByCriteria(criterias);
            foreach (AccomplissementUtilisateur accomplissementUtilisateur in accomplissementUtilisateurs)
            {
                accomplissementUtilisateur.Accomplissement = DAOAccomplissement.ObtenirAccomplissement(accomplissementUtilisateur.Accomplissement.Id);
            }

            return accomplissementUtilisateurs;
        }

        public int Enregistrer(AccomplissementUtilisateur accomplissementUtilisateur)
        {
            return Save(accomplissementUtilisateur);
        }
    }
}
