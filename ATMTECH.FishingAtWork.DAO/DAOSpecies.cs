using System;
using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOSpecies : BaseDao<Species, int>, IDAOSpecies
    {
        public IDAOSpeciesLure DAOSpecieSLure { get; set; }
        public IDAOLure DAOLure { get; set; }

        public Species GetSpecies(int id)
        {
            Species species = GetById(id);
            species.SpeciesLure = DAOSpecieSLure.GetSpeciesLure(species);
            foreach (SpeciesLure speciesLure in species.SpeciesLure)
            {
                speciesLure.Lure = DAOLure.GetLure(speciesLure.Id);
            }
            return species;
        }

        public IList<Species> GetSpecies()
        {
            IList<Species> specieses = GetAllActive();
            foreach (Species speciese in specieses)
            {
                speciese.SpeciesLure = DAOSpecieSLure.GetSpeciesLure(speciese);
                foreach (SpeciesLure speciesLure in speciese.SpeciesLure)
                {
                    speciesLure.Lure = DAOLure.GetLure(speciesLure.Id);
                }
            }
            return specieses;
        }
    }
}
