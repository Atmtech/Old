using System.Collections.Generic;

namespace ATMTECH.Vachier.DAO.Interface
{
    public interface IDAOVachier
    {
        IList<Entities.Vachier> ObtenirListeVachier(string recherche, string parametreTrie, int nbEnreg,
                                                    int indexDebutRangee);

        int ObtenirCompte();
        void EnregistrerMerde(Entities.Vachier vachier);
        Entities.Vachier ObtenirVachier(int id);
        IList<Entities.Vachier> ObtenirListeVachierTopListe();
        Entities.Vachier ObtenirMerdeDuJour();
        int ObtenirNombreTotal();
    }
}
