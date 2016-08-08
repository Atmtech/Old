﻿using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAONourriture : BaseDao<Nourriture, int>, IDAONourriture
    {
        public Nourriture ObtenirNourriture(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = BaseEntity.ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Nourriture> rtn = GetByCriteria(criterias);
            return rtn.Count > 0 ? rtn[0] : null;
        }

        public IList<Nourriture> ObtenirNourriture()
        {
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(IsActive());
            IList<Nourriture> rtn = GetByCriteria(criterias);
            return rtn.Count > 0 ? rtn : null;
        }

     
    }
}
