using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOCourriel
    {
        Courriel ObtenirMail(string code);
        IList<Courriel> GetAllActive();
        int Save(Courriel mail);
    }
}
