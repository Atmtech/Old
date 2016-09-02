using System;

namespace ATMTECH.MidiBoardGame.Entites
{
    public class MidiVote
    {
        public int Id { get; set; }
        public Midi Midi { get; set; }
        public Utilisateur Utilisateur { get; set; }

    }
}
