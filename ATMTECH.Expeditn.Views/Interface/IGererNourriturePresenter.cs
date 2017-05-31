using System;
using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IGererNourriturePresenter : IViewBase
    {
        Expedition Expedition { get; set; }
        string IdExpedition { get;}
        string IdParticipantCuisinier { get; set; }
        string IdNourriture { get; }
        string Nom { get; set; }
        string Menu { get; set; }
        DateTime Date { get; set; }
        IList<Participant> ListeParticipant { set; }
        IList<Nourriture> ListeNourriture { set; 
            }
        IList<DateTime> ListeDate { set; }
    }
}
