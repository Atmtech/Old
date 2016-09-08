using System;

namespace ATMTECH.MidiBoardGame.Entites
{
    public class PropositionVote
    {
        public int Id { get; set; }
        public Proposition Proposition { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
