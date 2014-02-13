using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class SiteSpeciesBuilder
    {
        public static SiteSpecies Create()
        {
            return new SiteSpecies();
        }
        public static SiteSpecies WithArea(this SiteSpecies siteSpecies, IList<SiteSpeciesCoordinate> area)
        {
            siteSpecies.Area = area;
            return siteSpecies;
        }
        public static SiteSpecies WithSpecies(this SiteSpecies siteSpecies, Species species)
        {
            siteSpecies.Species = species;
            return siteSpecies;
        }

        public static SiteSpecies WithSite(this SiteSpecies siteSpecies, Site site)
        {
            siteSpecies.Site = site;
            return siteSpecies;
        }

        public static SiteSpecies WithWeightModifier(this SiteSpecies siteSpecies, int weightModifier)
        {
            siteSpecies.WeightModifier = weightModifier;
            return siteSpecies;
        }


        public static SiteSpecies CreateValid()
        {
            IList<SiteSpeciesCoordinate> siteSpeciesCoordinates = new List<SiteSpeciesCoordinate>();
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(1).WithY(1)));
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(1).WithY(4)));
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(5).WithY(1)));
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(5).WithY(4)));
            return new SiteSpecies().WithSpecies(SpeciesBuilder.CreateValid()).WithArea(siteSpeciesCoordinates).WithSite(SiteBuilder.CreateValid()).WithWeightModifier(0);
        }
    }
}
