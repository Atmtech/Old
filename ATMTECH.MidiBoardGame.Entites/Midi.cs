﻿using System;

namespace ATMTECH.MidiBoardGame.Entites
{
    public class Midi
    {
        public int Id { get; set; }
        public Jeu Jeu { get; set; }
        public DateTime Date { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
