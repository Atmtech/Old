using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOVehicule : BaseDao<Vehicule, int>, IDAOVehicule
    {
        public IList<Vehicule> ObtenirVehicule()
        {
            return GetAllActive();
        }

        public Vehicule ObtenirVehicule(int id)
        {
            return GetById(id);
        }
    }
}
