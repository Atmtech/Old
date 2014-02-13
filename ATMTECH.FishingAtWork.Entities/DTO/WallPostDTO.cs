using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.FishingAtWork.Entities.DTO
{
    public class WallPostDTO
    {
        public int Id { get; set; }
        public WallPost WallPost { get; set; }
        public Player Player { get; set; }
    }
}
