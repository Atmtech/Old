using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class SiteSpeciesCoordinateBuilder
    {
        public static SiteSpeciesCoordinate Create()
        {
            return new SiteSpeciesCoordinate();
        }

        public static SiteSpeciesCoordinate WithSpecies(this SiteSpeciesCoordinate siteSpeciesCoordinate, Species species)
        {
            siteSpeciesCoordinate.Species = species;
            return siteSpeciesCoordinate;  
        }

        public static SiteSpeciesCoordinate WithSite(this SiteSpeciesCoordinate siteSpeciesCoordinate, Site site)
        {
            siteSpeciesCoordinate.Site = site;
            return siteSpeciesCoordinate;
        }


        public static SiteSpeciesCoordinate WithCoordinate(this SiteSpeciesCoordinate siteSpeciesCoordinate, Coordinate coordinate)
        {
            siteSpeciesCoordinate.X = coordinate.X;
            siteSpeciesCoordinate.Y = coordinate.Y;
            return siteSpeciesCoordinate;
        }

    }
}
