using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Trip : BaseEntity
    {
        public const string PLAYER = "Player";
        public const string DATE_START = "DateStart";

        public virtual Player Player { get; set; }
        public virtual string Name { get; set; }
        public virtual Site Site { get; set; }
        public virtual DateTime DateStart { get; set; }
        public virtual DateTime DateEnd { get; set; }
        public virtual IList<Waypoint> Waypoints { get; set; }
    }
}
