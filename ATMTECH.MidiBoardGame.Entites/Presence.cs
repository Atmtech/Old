using System;

namespace ATMTECH.MidiBoardGame.Entites
{
    public class Presence
    {
        public int Id { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public DateTime Date { get; set; }
    }
}
