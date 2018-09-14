using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOMateriel
    {
        IList<Materiel> ObtenirMateriel(Expedition expedition);
    }
}
