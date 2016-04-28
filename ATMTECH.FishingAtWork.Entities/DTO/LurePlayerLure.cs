using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.FishingAtWork.Entities.DTO
{
    public class LurePlayerLure
    {
        public int Id { get; set; }
        public Lure Lure { get; set; }
        public PlayerLure PlayerLure { get; set; }
    }
}
