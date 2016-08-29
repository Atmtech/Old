using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOHistoriqueForfaitExpedia : BaseDao<HistoriqueForfaitExpedia, int>, IDAOHistoriqueForfaitExpedia
    {
        public int Enregistrer(HistoriqueForfaitExpedia historiqueForfaitExpedia)
        {
            return Save(historiqueForfaitExpedia);
        }

        public IList<HistoriqueForfaitExpedia> ObtenirHistoriqueForfaitExpedia()
        {
            return GetAllActive();
        }

        public IList<HistoriqueForfaitExpedia> ObtenirHistoriqueForfaitExpedia(RechercheForfaitExpedia rechercheForfaitExpedia)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = HistoriqueForfaitExpedia.RECHERCHE_FORFAIT_EXPEDIA, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = rechercheForfaitExpedia.Id.ToString() };
            criterias.Add(IsActive());
            criterias.Add(criteriaMenu);
            return GetByCriteria(criterias);
        }

    }
}
