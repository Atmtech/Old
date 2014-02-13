using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class AccomplissementUtilisateur : BaseEntity
    {
        public const string UTILISATEUR = "Utilisateur";

        public IList<User> AppuyePar { get; set; }
        public File AppuyeParImage { get; set; }
        public string AppuyeParVideo { get; set; }
        public Accomplissement Accomplissement { get; set; }
        public User Utilisateur { get; set; }
        public bool EstPrive { get; set; }
        public bool EstPublic { get; set; }
        public bool EstPourAmi { get; set; }

    }
}
