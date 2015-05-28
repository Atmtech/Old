using System.Collections.Generic;
using ATMTECH.Web.Services.Entities;

namespace ATMTECH.Web.Services.Interface
{
    public interface INavigationService
    {
        void AjouterPageFilArianne(string page, string langue);
        string ObtenirTitrePage(string page, string langue);
        IList<FilArianne> ListePageAcceder { get; set; }
        void Redirect(string page);
        IList<QueryString> GetQueryString();
        string GetQueryStringValue(string key);
        void Redirect(string page, IList<QueryString> queryString);
        void Refresh();
        void Refresh(IList<QueryString> queryStrings);
        CountryIp GetInformationIpInfoDb();
    }
}
