using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.FishingAtWork.Entities.DTO
{
    public class PlayerListDTO
    {
        public int Id { get; set; }
        public Site Site { get; set; }
        public Player Player { get; set; }
    }
}
