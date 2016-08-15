using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Participant : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public const string EST_ADMINISTRATEUR = "EstAdministrateurExpedition";
        public const string UTILISATEUR = "Utilisateur";

        public Expedition Expedition { get; set; }
        public User Utilisateur { get; set; }
        public bool EstAdministrateur { get; set; }

        public string Image
        {
            get {
                if (Utilisateur.Image != null)
                {
                    if (!string.IsNullOrEmpty(Utilisateur.Image.FileName))
                        return "/Images/medias/" + Utilisateur.Image.FileName;
                    return "/Images/medias/AucuneImageParticipant.gif";
                }
                return "/Images/medias/AucuneImageParticipant.gif";
            }
        }

        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} ({1})", Expedition.Nom,Utilisateur.FirstNameLastName); }
        }
    }
}