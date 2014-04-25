using System.Collections.Generic;
using ATMTECH.DenonceTonGros.Entities;

namespace ATMTECH.DenonceTonGros.DAO.Interface
{
    public interface IDAOGros
    {
        IList<Gros> ObtenirListeMerdeux();
        void AjouterMerdeCelebre(Gros merdeux);
        string ObtenirDescription(int id);
    }
}
