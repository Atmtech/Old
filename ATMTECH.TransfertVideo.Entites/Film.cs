using ATMTECH.Entities;

namespace ATMTECH.TransfertVideo.Entites
{
    public class Film : BaseEntity
    {
        public string Guid { get; set; }
        public string Groupe { get; set; }
        public string Etudiant1 { get; set; }
        public string Etudiant2 { get; set; }
        public string Etudiant3 { get; set; }
        public string Etudiant4 { get; set; }
        public string Etudiant5 { get; set; }
        public string Etudiant6 { get; set; }
        public string Fichier { get; set; }
        public string FichierMp4 { get; set; }
        public string Style { get; set; }
        public bool Visionnee { get; set; }
        public string FichierSansGuid
        {
            get
            {
                return !string.IsNullOrEmpty(Fichier) ? Fichier.Replace(Guid, "") : string.Empty;
            }
        }
    }
}