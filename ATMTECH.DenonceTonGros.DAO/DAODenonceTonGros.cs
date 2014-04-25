using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.DenonceTonGros.DAO.Interface;
using ATMTECH.DenonceTonGros.Entities;

namespace ATMTECH.DenonceTonGros.DAO
{
    public class DAODenonceTonGros : BaseDao<DenonceTonGrosTas, int>, IDAODenonceTonGros
    {
        public IDAOInsulte DAOInsulte { get; set; }
        public DenonceTonGrosTas ObtenirDenonceTonGros(int id)
        {
            return GetById(id);
        }

        public DenonceTonGrosTas ObtenirMerdeDuJour()
        {
            Random rand = new Random();
            int nombre = GetCount();
            int leDenonceTonGrosAuHasard = rand.Next(0, nombre) - 4;
            DenonceTonGrosTas DenonceTonGros = ObtenirDenonceTonGros(leDenonceTonGrosAuHasard);
            if (DenonceTonGros != null)
            {
                DenonceTonGros.Insulte = DAOInsulte.ObtenirInsulte(DenonceTonGros.Insulte.Id);
                return DenonceTonGros;
            }
            else
            {
                return null;
            }

        }

        public int ObtenirNombreTotal()
        {
            return GetCount();
        }

        public IList<DenonceTonGrosTas> ObtenirListeDenonceTonGrosTopListe()
        {
            IList<Insulte> insultes = DAOInsulte.ObtenirListeInsulte();
            Criteria criteria = new Criteria { Column = DenonceTonGrosTas.JAIME_TA_MERDE, Operator = DatabaseOperator.OPERATOR_GREATER_THAN, Value = "0" };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria);
            IList<DenonceTonGrosTas> DenonceTonGross = GetByCriteria(criterias);
            DenonceTonGross = DenonceTonGross.OrderByDescending(x => x.Jaime).ToList();
            DenonceTonGross = DenonceTonGross.Take(20).ToList();
            foreach (DenonceTonGrosTas DenonceTonGros in DenonceTonGross)
            {
                DenonceTonGros.Insulte = insultes.FirstOrDefault(x => x.Id == DenonceTonGros.Insulte.Id);
            }
            return DenonceTonGross;

        }
        public IList<DenonceTonGrosTas> ObtenirListeDenonceTonGros(string recherche, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            IList<Insulte> insultes = DAOInsulte.ObtenirListeInsulte();

            if (!string.IsNullOrEmpty(recherche))
            {
                Criteria criteria = new Criteria { Column = BaseEntity.DESCRIPTION, Operator = DatabaseOperator.OPERATOR_LIKE, Value = recherche };
                OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
                PagingOperation pagingOperation = new PagingOperation { PageIndex = indexDebutRangee, PageSize = nbEnreg };
                IList<DenonceTonGrosTas> DenonceTonGross = GetAllOneCriteria(criteria, pagingOperation, orderOperation);

                foreach (DenonceTonGrosTas DenonceTonGros in DenonceTonGross)
                {
                    DenonceTonGros.Insulte = insultes.FirstOrDefault(x => x.Id == DenonceTonGros.Insulte.Id);
                }

                return DenonceTonGross;
            }
            else
            {
                Criteria criteria = new Criteria { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
                OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
                PagingOperation pagingOperation = new PagingOperation { PageIndex = indexDebutRangee, PageSize = nbEnreg };

                IList<DenonceTonGrosTas> DenonceTonGross = GetAllOneCriteria(criteria, pagingOperation, orderOperation);

                foreach (DenonceTonGrosTas DenonceTonGros in DenonceTonGross)
                {
                    DenonceTonGros.Insulte = insultes.FirstOrDefault(x => x.Id == DenonceTonGros.Insulte.Id);
                }

                return DenonceTonGross;
            }
        }
        public int ObtenirCompte()
        {
            return GetCount();
        }

        public void EnregistrerMerde(DenonceTonGrosTas DenonceTonGros)
        {
            Save(DenonceTonGros);
        }


    }


}
