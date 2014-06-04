using System.Collections.Generic;
using ATMTECH.Vachier.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.Vachier.Views.Interface
{
    public interface IDefaultPresenter : IViewBase
    {
        IList<Entities.Vachier> Liste { set; }
        IList<Entities.Vachier> ListeTop { set; }
        Entities.Vachier MerdeDuMoment { set; }
        int CompteTotal { set; }
        string TotalMarde { set; }
        IList<Insulte> ListeInsulte { set; }
        IList<Merdeux> ListeMerdeux { set; }
        IList<CountryIp> ListePays { set; }
        IList<CountryIp> ListeVille { set; }
        int NombreParPage { get; }
        int PageCourante { get; }

        string AjouterMerde { get; set; }
        string Insulte { get; set; }
        string RechercheMerde { get; set; }
        string RechercheQueryString { set; }
        
       
    }
}
