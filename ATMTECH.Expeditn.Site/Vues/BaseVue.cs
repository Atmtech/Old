using ATMTECH.Expeditn.Services;

namespace ATMTECH.Expeditn.Site.Vues
{
    public class BaseVue
    {
      

        public LocalisationService LocalisationService => new LocalisationService();
        public ExpeditionService ExpeditionService => new ExpeditionService();
        public UtilisateurService UtilisateurService => new UtilisateurService();
        public ScanService ScanService => new ScanService();
    }
}