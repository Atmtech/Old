using System.Collections.Generic;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.Achievement.DAO
{
    public class DAOAccomplissementTrait : BaseDao<AccomplissementTrait, int>, IDAOAccomplissementTrait
    {
        public IDAOTrait DAOtrait { get; set; }
        public IList<AccomplissementTrait> ObtenirTousActive()
        {
            return GetAllActive();
        }

        public IList<AccomplissementTrait> ObtenirTousActivePourAccomplissement(int idAccomplissement)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaCategorie = new Criteria { Column = AccomplissementTrait.ACCOMPLISSEMENT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idAccomplissement.ToString() };
            criterias.Add(criteriaCategorie);
            criterias.Add(IsActive());
            IList<AccomplissementTrait> accomplissementTraits = GetByCriteria(criterias);
            foreach (AccomplissementTrait accomplissementTrait in accomplissementTraits)
            {
                accomplissementTrait.Trait = DAOtrait.ObtenirTrait(accomplissementTrait.Trait.Id);
            }

            return accomplissementTraits;
        }

        public int Enregistrer(AccomplissementTrait accomplissementTrait)
        {
            return Save(accomplissementTrait);
        }
    }
}
