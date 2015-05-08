using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOVehicule : BaseDao<Vehicule, int>, IDAOVehicule
    {
        public IList<Vehicule> ObtenirVehicule(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Vehicule.EXPEDITION, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            return GetByCriteria(criterias);
        }

        public IList<Vehicule> ObtenirVehicule(User utilisateur)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Vehicule.UTILISATEUR, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = utilisateur.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            return GetByCriteria(criterias);
        }
    }
}
