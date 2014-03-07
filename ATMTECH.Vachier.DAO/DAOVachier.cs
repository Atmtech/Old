using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Vachier.Entities;

namespace ATMTECH.Vachier.DAO
{
    public class DAOVachier : BaseDao<Entities.Vachier, int>, IDAOVachier
    {
        public IDAOInsulte DAOInsulte { get; set; }
        public Entities.Vachier ObtenirVachier(int id)
        {
            return GetById(id);
        }

        public Entities.Vachier ObtenirMerdeDuJour()
        {
            Random rand = new Random();
            int nombre = GetCount();
            int leVachierAuHasard = rand.Next(0, nombre) - 4;
            Entities.Vachier vachier = ObtenirVachier(leVachierAuHasard);
            vachier.Insulte = DAOInsulte.ObtenirInsulte(vachier.Insulte.Id);
            return vachier;
        }

        public int ObtenirNombreTotal()
        {
            return GetCount();
        }

        public IList<Entities.Vachier> ObtenirListeVachierTopListe()
        {
            IList<Insulte> insultes = DAOInsulte.ObtenirListeInsulte();
            Criteria criteria = new Criteria { Column = Entities.Vachier.JAIME_TA_MERDE, Operator = DatabaseOperator.OPERATOR_GREATER_THAN, Value = "0" };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria);
            IList<Entities.Vachier> vachiers = GetByCriteria(criterias);
            vachiers = vachiers.OrderByDescending(x => x.JaimeTaMerde).ToList();
            vachiers = vachiers.Take(20).ToList();
            foreach (Entities.Vachier vachier in vachiers)
            {
                vachier.Insulte = insultes.FirstOrDefault(x => x.Id == vachier.Insulte.Id);
            }
            return vachiers;

        }
        public IList<Entities.Vachier> ObtenirListeVachier(string recherche, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            IList<Insulte> insultes = DAOInsulte.ObtenirListeInsulte();

            if (!string.IsNullOrEmpty(recherche))
            {
                Criteria criteria = new Criteria { Column = BaseEntity.DESCRIPTION, Operator = DatabaseOperator.OPERATOR_LIKE, Value = recherche };
                OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
                PagingOperation pagingOperation = new PagingOperation { PageIndex = indexDebutRangee, PageSize = nbEnreg };
                IList<Entities.Vachier> vachiers = GetAllOneCriteria(criteria, pagingOperation, orderOperation);

                foreach (Entities.Vachier vachier in vachiers)
                {
                    vachier.Insulte = insultes.FirstOrDefault(x => x.Id == vachier.Insulte.Id);
                }

                return vachiers;
            }
            else
            {
                Criteria criteria = new Criteria { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
                OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
                PagingOperation pagingOperation = new PagingOperation { PageIndex = indexDebutRangee, PageSize = nbEnreg };

                IList<Entities.Vachier> vachiers = GetAllOneCriteria(criteria, pagingOperation, orderOperation);

                foreach (Entities.Vachier vachier in vachiers)
                {
                    vachier.Insulte = insultes.FirstOrDefault(x => x.Id == vachier.Insulte.Id);
                }

                return vachiers;
            }
        }
        public int ObtenirCompte()
        {
            return GetCount();
        }

        public void EnregistrerMerde(Entities.Vachier vachier)
        {
            Save(vachier);
        }


    }


}
