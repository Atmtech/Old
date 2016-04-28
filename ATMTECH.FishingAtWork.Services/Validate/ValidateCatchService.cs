using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services.Validate
{
    public class ValidateCatchService : BaseService, IValidateCatchService
    {
        public IRandomService RandomService { get; set; }

        public bool Validate(SpeciesCatch speciesCatch)
        {
            if (ValidateLureCatch(speciesCatch))
            {
                return true;
            }

            return false;
        }

        private bool ValidateLureCatch(SpeciesCatch speciesCatch)
        {
            if (speciesCatch.Species.SpeciesLure != null)
            {
                foreach (SpeciesLure speciesLure in speciesCatch.Species.SpeciesLure)
                {
                    if (speciesLure.Lure.Id == speciesCatch.Lure.Id)
                    {
                        return RandomService.RandomLureAttracting(1, 100) < speciesLure.AttractingPercentage;
                    }
                }
            }
            return false;
        }

    }
}
