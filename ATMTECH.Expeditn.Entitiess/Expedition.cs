using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Expedition : BaseEntity
    {
        public const string CHEF_DE_GROUPE = "ChefDeGroupe";

        public string Nom { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public decimal BudgetEstime { get; set; }
        public decimal BudgetReel { get { return 0; } }
        public GeoLocalisation GeoLocalisation { get; set; }
        public Participant Administrateur { get { return Participant != null ? Participant.FirstOrDefault(x => x.EstAdministrateur) : null; } }
        public File Image { get; set; }

        public string FichierImage
        {
            get
            {
                if (Image != null)
                {
                    if (!string.IsNullOrEmpty(Image.FileName))
                    { return "/Images/medias/" + Image.FileName; }
                    return "/Images/medias/AucuneImage.gif";
                }
                return "/Images/medias/AucuneImage.gif";
            }
        }

        public IList<Participant> Participant { get; set; }
        public IList<Media> Media { get; set; }
        public IList<Etape> Etape { get; set; }
        public IList<Nourriture> Nourriture { get; set; }
        public IList<Materiel> Materiel { get; set; }


        public Categorie Categorie { get; set; }
        public bool EstPrive { get; set; }

        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0}", Nom); }
        }
    }
}