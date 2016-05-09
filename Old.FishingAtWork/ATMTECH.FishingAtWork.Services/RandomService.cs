using System;
using System.Threading;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class RandomService : BaseService, IRandomService
    {
        private Random _random;
        public Random Randomize
        {
            get
            {
                long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks);
                int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));
                Random random = new Random(seed);
                return _random ?? (_random = random);
            }
        }
        public Coordinate RandomCoordinate(double minimumX, double maximumX, double minimumY, double maximumY)
        {
            double x = Randomize.NextDouble() * (maximumX - minimumX) + minimumX;
            double y = Randomize.NextDouble() * (maximumY - minimumY) + minimumY;

            x = Math.Round(x);
            y = Math.Round(y);
            return new Coordinate(x, y);
        }

        public int RandomLureAttracting(int min, int max)
        {
            return Randomize.Next(min, max);
        }

        public double RandomSpeciesWeight(int minimum, int maximum)
        {
            // trouver une facon pour rendre la prise des gros poissons plus difficile que les plus petit.
            return Math.Round(Randomize.NextDouble() * (maximum - minimum) + minimum, 2);
        }

        public int RandomSpeciesExperience(int maximum, double weight)
        {
            // trouver un moyen pour prendre juste une portion du poids pour en faire un experience modifié. Le meme principe devrait s'appliquer dans le poids
            return Randomize.Next(1, maximum);
        }

    }
}
