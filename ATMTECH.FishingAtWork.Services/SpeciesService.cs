using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class SpeciesService : BaseService, ISpeciesService
    {
        public IDAOSpecies DAOSpecies { get; set; }
        public IList<Species> GetSpecies()
        {
            return DAOSpecies.GetSpecies();
        }
    }
}
