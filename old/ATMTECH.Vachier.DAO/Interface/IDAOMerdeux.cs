using System.Collections.Generic;
using ATMTECH.Vachier.Entities;

namespace ATMTECH.Vachier.DAO.Interface
{
    public interface IDAOMerdeux
    {
        IList<Merdeux> ObtenirListeMerdeux();
        void AjouterMerdeCelebre(Merdeux merdeux);
        string ObtenirDescription(int id);
    }
}
