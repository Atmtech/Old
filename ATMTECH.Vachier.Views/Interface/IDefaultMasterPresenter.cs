using System.Collections.Generic;
using ATMTECH.Vachier.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.Vachier.Views.Interface
{
    public interface IDefaultMasterPresenter : IViewBase
    {
        string AjouterMerde { get; set; }
        string RechercheMerde { get; set; }
        string ChierSurCelebre { get; set; }
        string AjouterMerdeCelebre { get; set; }
        string Insulte { get; set; }
        IList<Insulte> ListeInsulte { set; }
        IList<Merdeux> ListeMerdeux { set; }
        IList<CountryIp> ListePays { set; }
        IList<CountryIp> ListeVille { set; }
    }
}
