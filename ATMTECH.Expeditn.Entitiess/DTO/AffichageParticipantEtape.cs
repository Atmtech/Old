using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class AffichageParticipantEtape
    {
        public int IdEtapeParticipant { get; set; }
        public int IdParticipant { get; set; }
        public Etape Etape { get; set; }
        public Expedition Expedition { get; set; }
        public User Utilisateur { get; set; }
        public bool EstParticipantEtape { get; set; }
    }
}
