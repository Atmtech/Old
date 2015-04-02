using System;
using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOCoupon : BaseDao<Coupon, int>, IDAOCoupon
    {
        public Coupon ObtenirCoupon(string coupon)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaCoupon = new Criteria { Column = Coupon.IDENT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = coupon };
            Criteria criteriaDateExpired = new Criteria { Column = Coupon.DATE_EXPIRED, Operator = DatabaseOperator.OPERATOR_GREATER_EQUAL_THAN, Value = DateTime.Now.ToString() };
            criterias.Add(criteriaCoupon);
            criterias.Add(criteriaDateExpired);
            criterias.Add(IsActive());
            IList<Coupon> coupons = GetByCriteria(criterias);
            return coupons.Count > 0 ? coupons[0] : null;
        }
    }
}
