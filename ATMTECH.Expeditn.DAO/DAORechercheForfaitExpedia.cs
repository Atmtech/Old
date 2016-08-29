using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAORechercheForfaitExpedia : BaseDao<RechercheForfaitExpedia, int>, IDAORechercheForfaitExpedia 
    {
    

        public IList<RechercheForfaitExpedia> ObtenirRechercheForfaitExpedia()
        {
            return GetAllActive();
        }

        public RechercheForfaitExpedia ObtenirRechercheForfaitExpedia(int id)
        {

            return GetById(id);
        }
    }
}
