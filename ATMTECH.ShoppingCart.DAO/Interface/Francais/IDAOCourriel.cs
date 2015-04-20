using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOCourriel
    {
        Mail ObtenirMail(string code);
        IList<Mail> GetAllActive();
        int Save(Mail mail);
    }
}
