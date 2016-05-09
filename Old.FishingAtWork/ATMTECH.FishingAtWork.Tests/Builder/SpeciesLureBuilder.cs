using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class SpeciesLureBuilder
    {
        public static SpeciesLure Create()
        {
            return new SpeciesLure();
        }
        public static SpeciesLure WithAttractingPercentage(this SpeciesLure speciesLure, int attractingPercentage)
        {
            speciesLure.AttractingPercentage = attractingPercentage;
            return speciesLure;
        }

        public static SpeciesLure WithLure(this SpeciesLure speciesLure, Lure lure)
        {
            speciesLure.Lure = lure;
            return speciesLure;
        }

        public static SpeciesLure WithSpecies(this SpeciesLure speciesLure, Species species)
        {
            speciesLure.Species = species;
            return speciesLure;
        }


        public static SpeciesLure CreateValid()
        {
            return new SpeciesLure().WithAttractingPercentage(100).WithLure(LureBuilder.CreateValid()).WithSpecies(SpeciesBuilder.CreateValid());
        }
    }
}
