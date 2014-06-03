
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Vachier.Entities;

namespace ATMTECH.Vachier.DAO
{
    public class DAOInsulte : BaseDao<Insulte, int>, IDAOInsulte
    {

        public IList<Insulte> Insultes
        {
            get
            {

                if (System.Web.HttpContext.Current.Session["Insultes"] == null)
                {
                    OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Ascending };
                    System.Web.HttpContext.Current.Session["Insultes"] = GetAllActive(orderOperation);
                }
                return (IList<Insulte>)System.Web.HttpContext.Current.Session["Insultes"];
            }
            set
            {
                if (System.Web.HttpContext.Current.Session["Insultes"] == null || value == null)
                    System.Web.HttpContext.Current.Session["Insultes"] = value;
            }
        }


        public Insulte ObtenirInsulte(int id)
        {
            return Insultes.FirstOrDefault(x => x.Id == id );
        }
        public IList<Insulte> ObtenirListeInsulte()
        {
            return Insultes;
        }
    }


}
