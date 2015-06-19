using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOCoupon
    {
        Coupon ObtenirCoupon(string coupon);
        Coupon GetById(int id);
        IList<Coupon> GetAllActive();
    }
}
