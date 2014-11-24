using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Mediator.DAO.Interface;
using ATMTECH.Mediator.Entities;

namespace ATMTECH.Mediator.DAO
{
    public class DAOClavardage : BaseDao<Clavardage, int>, IDAOMediator
    {
        private readonly DAOUtilisateurs _daoUtilisateurs = new DAOUtilisateurs();

        public IList<Clavardage> ObtenirClavardage(int chatCourant)
        {
            IList<Criteria> criterias = new List<Criteria>();

            if (chatCourant == 0)
            {
                int max = Convert.ToInt32(GetMax(Clavardage.NO_CLAVARDAGE));
                Criteria criteriaLog = new Criteria { Column = Clavardage.NO_CLAVARDAGE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = max.ToString() };
                criterias.Add(criteriaLog);
            }
            else
            {
                Criteria criteriaLog = new Criteria { Column = Clavardage.NO_CLAVARDAGE, Operator = DatabaseOperator.OPERATOR_GREATER_THAN, Value = chatCourant.ToString() };
                criterias.Add(criteriaLog);
            }

            IList<Clavardage> clavardages = GetByCriteria(criterias);

            if (clavardages.Count > 0)
            {
                foreach (Clavardage clavardage in clavardages)
                {
                    clavardage.Utilisateur = _daoUtilisateurs.ObtenirUtilisateur(clavardage.NoUtilisateur.ToString());
                }
                return clavardages.OrderBy(x=>x.NoClavardage).ToList();
            }

            return null;

        }

      

        public void EnregistrerClavardage(Clavardage clavardage)
        {
            Save(clavardage);
        }
    }
}
