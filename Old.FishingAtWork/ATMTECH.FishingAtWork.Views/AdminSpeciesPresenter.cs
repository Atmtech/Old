using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class AdminSpeciesPresenter : BaseFishingAtWorkPresenter<IAdminSpeciesPresenter>
    {
        public ISpeciesService SpeciesService { get; set; }
        public AdminSpeciesPresenter(IAdminSpeciesPresenter view)
            : base(view)
        {
        }

        public IList<Species> GetSpecies(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return SpeciesService.GetSpecies();
        }

        public int GetSpeciesCount()
        {
            return SpeciesService.GetSpecies().Count;
        }
    }
}
