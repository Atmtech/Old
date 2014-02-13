using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.FishingAtWork.Entities.DTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public Player Player { get; set; }
    }
}
