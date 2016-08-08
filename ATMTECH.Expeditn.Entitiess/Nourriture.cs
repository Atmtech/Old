using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Nourriture : BaseEntity
    {
       public const string CHEF_CUISINIER = "ChefCuisinier";
        
        public User ChefCuisinier { get; set; }
        public string Nom { get; set; }
        public string Menu { get; set; }
    }
}
