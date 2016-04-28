using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class CoordinateBuilder
    {
        public static Coordinate Create()
        {
            return new Coordinate();
        }
        public static Coordinate WithX(this Coordinate coordinate, double x)
        {
            coordinate.X = x;
            return coordinate;
        }

        public static Coordinate WithY(this Coordinate coordinate, double y)
        {
            coordinate.Y = y;
            return coordinate;
        }
        
    }
}
