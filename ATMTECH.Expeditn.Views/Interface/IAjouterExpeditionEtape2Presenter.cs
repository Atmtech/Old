using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IAjouterExpeditionEtape2Presenter : IViewBase
    {
        string IdExpedition { get;}
        string Recherche { get; set; }
        IList<User> ListeUtilisateurPourAjouter {set; }
        IList<Participant> ListeParticipant { set; }
        
        //string Nom { get; set; }
        //DateTime Debut { get; set; }
        //DateTime Fin { get; set; }
        //decimal BudgetEstime { get; set; }
        //string Longitude { get; set; }
        //string Latitude { get; set; }
        //string Region { get; set; }
        //string Pays { get; set; }
        //string Ville { get; set; }
        //bool EstExpeditionPrive { get; set; }
        //IList<Pays> ListePays { set; }
    }
}
