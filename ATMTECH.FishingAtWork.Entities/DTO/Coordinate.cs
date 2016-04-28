using System;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities.DTO
{
    public class Coordinate: BaseEntity
    {
        public Double X { get; set; }
        public Double Y { get; set; }
        public Coordinate()
        {

        }
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
