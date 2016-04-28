using System;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    [Serializable]
    public class Basket : BaseEntity
    {
        public Lure Lure { get; set; }
        public Equipement Equipement { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Player Player { get; set; }
    }
}
