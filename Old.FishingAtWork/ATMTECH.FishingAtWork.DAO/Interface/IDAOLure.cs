using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOLure
    {
        IList<Lure> GetLureList();
        Lure GetLure(int id);
        IList<Lure> GetLureList(string parametreTrie, int nbEnreg, int indexDebutRangee);
    }
}
