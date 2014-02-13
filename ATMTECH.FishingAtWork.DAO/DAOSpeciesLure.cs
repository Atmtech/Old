using System;
using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOSpeciesLure : BaseDao<SpeciesLure, int>, IDAOSpeciesLure
    {
        public IList<SpeciesLure> GetSpeciesLure(Species species)
        {
            return GetAllOneCriteria(SpeciesLure.SPECIES, species.Id.ToString());
        }
    }
}
