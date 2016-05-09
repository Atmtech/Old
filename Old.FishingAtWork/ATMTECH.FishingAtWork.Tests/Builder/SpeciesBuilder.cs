using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class SpeciesBuilder
    {
        public static Species Create()
        {
            return new Species();
        }
        public static Species WithName(this Species species, string name)
        {
            species.Name = name;
            return species;
        }
        public static Species AddSpeciesLure(this Species species, SpeciesLure speciesLure)
        {
            if (species.SpeciesLure == null)
            {
                species.SpeciesLure = new List<SpeciesLure>();
            }
            species.SpeciesLure.Add(speciesLure);
            return species;
        }

        public static Species WithMoneyRatio(this Species species, double ratio)
        {
            species.MoneyValueInTournament = ratio;
            return species;
        }
        public static Species WithMaximumExperience(this Species species, int maximumExperience)
        {
            species.MaximumExperience = maximumExperience;
            return species;
        }

        public static Species WithMaximumWeight(this Species species, int maximumWeight)
        {
            species.MaximumWeight = maximumWeight;
            return species;
        }

        public static Species WithColorName(this Species species, string colorName)
        {
            species.ColorName = colorName;
            return species;
        }
        
        public static Species CreateValid()
        {
            Species species = new Species();
            species.WithName("Doré").WithMoneyRatio(10).WithMaximumExperience(10).WithMaximumWeight(15);
            return species;
        }
    }
}
