using System.Collections.Generic;
using ATMTECH.Web.Services.GoogleMap;

namespace ATMTECH.Web.Services.Interface
{
    public interface IGoogleMapService
    {
        IList<GoogleAdresse> Rechercher(string adresse);
        //void AfficherImage(string adresse, TypeCarteAffiche typeCarteAffiche);
    }
}
