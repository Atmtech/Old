using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IRandomService
    {
        Coordinate RandomCoordinate(double minimumX, double maximumX, double minimumY, double maximumY);
        int RandomLureAttracting(int min, int max);
        double RandomSpeciesWeight(int min, int max);
        int RandomSpeciesExperience(int maximum, double weight);
    }
}
