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

        //public Clavardage ObtenirClavardage(int chatCourant)
        //{
        //    int max = Convert.ToInt32(GetMax(Clavardage.NO_CLAVARDAGE));

        //    if (max != chatCourant)
        //    {
        //        Clavardage clavardage = GetAllOneCriteria(Clavardage.NO_CLAVARDAGE, max.ToString())[0];
        //        clavardage.Utilisateur = _daoUtilisateurs.ObtenirUtilisateur(clavardage.NoUtilisateur.ToString());
        //        return clavardage;
        //    }
        //    return null;
        //}

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

        public IList<Clavardage> ObtenirListeClavardage(int nombreAnterieur)
        {
            int max = Convert.ToInt32(GetMax(Clavardage.NO_CLAVARDAGE));
            int prendreLogApartirDeLa = max - 200;
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaLog = new Criteria { Column = Clavardage.NO_CLAVARDAGE, Operator = DatabaseOperator.OPERATOR_GREATER_THAN, Value = prendreLogApartirDeLa.ToString() };
            Criteria criteriaType = new Criteria { Column = Clavardage.TYPE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "CHAT" };
            criterias.Add(criteriaLog);
            criterias.Add(criteriaType);
            IList<Clavardage> clavardages = GetByCriteria(criterias);
            clavardages = clavardages.OrderByDescending(x => x.Id).Take(nombreAnterieur).ToList();
            foreach (Clavardage clavardage in clavardages)
            {
                clavardage.Utilisateur = _daoUtilisateurs.ObtenirUtilisateur(clavardage.NoUtilisateur.ToString());
            }
            return clavardages;
        }

        public void EnregistrerClavardage(Clavardage clavardage)
        {
            Save(clavardage);
        }
    }
}
