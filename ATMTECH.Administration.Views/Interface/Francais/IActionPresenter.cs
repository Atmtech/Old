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
        string Sujet { get; set; }
        string Corps { get; set; }
    }
}
