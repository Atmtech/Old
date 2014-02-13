using System;
using System.ComponentModel;
using ATMTECH.Entities;

namespace ATMTECH.Mediator.Entities
{
    public class Parametre: BaseEntity
    {
        public const string NO_PARAMETRE = "NoParametre";
        public const string NOM_PARAMETRE = "NomParametre";
        public const string PARAMETRE_VERSION = "VERSIONMEDIATORNET";

        [Category("UniqueKey")]
        public int NoParametre { get; set; }
        public string NomParametre { get; set; }
        public string ValeurParametre { get; set; }
    }
}
