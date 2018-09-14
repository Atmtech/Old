using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOVehicule
    {
        IList<Vehicule> ObtenirVehicule();
        Vehicule ObtenirVehicule(int id);
    }
}
