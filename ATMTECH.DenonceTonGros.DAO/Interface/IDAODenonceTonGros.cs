using System.Collections.Generic;
using ATMTECH.DenonceTonGros.Entities;

namespace ATMTECH.DenonceTonGros.DAO.Interface
{
    public interface IDAODenonceTonGros
    {
        IList<DenonceTonGrosTas> ObtenirListeDenonceTonGros(string recherche, string parametreTrie, int nbEnreg,
                                                    int indexDebutRangee);

        int ObtenirCompte();
        void EnregistrerMerde(DenonceTonGrosTas DenonceTonGros);
        DenonceTonGrosTas ObtenirDenonceTonGros(int id);
        IList<DenonceTonGrosTas> ObtenirListeDenonceTonGrosTopListe();
        DenonceTonGrosTas ObtenirMerdeDuJour();
        int ObtenirNombreTotal();
    }
}
