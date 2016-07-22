﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
    public class ParticipantAutomobileExpedition : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
       public Participant Participant { get; set; }
       public Expedition Expedition { get; set; }
       public DateTime Date { get; set; }
       public bool EstAutomobile { get; set; }
    }
}
