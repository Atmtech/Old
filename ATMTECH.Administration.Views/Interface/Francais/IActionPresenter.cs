using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface.Francais
{
    public interface IActionPresenter : IViewBase
    {
        string NomAction { get; }
        IList<string> ListeCopieSauvegarde { set; }
        string FichierSauvegarde { get; }

        IList<Mail> ListeCourriel { set; }
        string Code { get; set; }
        string SujetFr { get; set; }
        string CorpsFr { get; set; }
        string SujetEn { get; set; }
        string CorpsEn { get; set; }
        string Pourcentage { get; set; }
        DateTime DateDepart { get; }
        DateTime DateFin { get; }
        string Courriel { get; }

        string CourrielCommande { get; }
        string NumeroCommandePourCourriel { get; }
    }
}
