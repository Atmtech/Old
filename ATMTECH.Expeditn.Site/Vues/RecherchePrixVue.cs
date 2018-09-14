using System.Collections.Generic;
using ATMTECH.Expeditn.Entites;

namespace ATMTECH.Expeditn.Site.Vues
{
    public class RecherchePrixVue : BaseVue
    {
        public IList<PlanificationScan> Obtenir(Utilisateur utilisateur)
        {
            return ScanService.ObtenirPlanificationScan(utilisateur);
        }
    }
}