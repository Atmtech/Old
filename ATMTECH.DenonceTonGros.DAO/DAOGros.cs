using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DenonceTonGros.DAO.Interface;
using ATMTECH.DenonceTonGros.Entities;

namespace ATMTECH.DenonceTonGros.DAO
{
    public class DAOGros : BaseDao<Gros, int>, IDAOGros
    {
        public IList<Gros> ObtenirListeMerdeux()
        {
            return GetAllOneCriteria(Gros.PUBLISH, "1");
        }

        public void AjouterMerdeCelebre(Gros merdeux)
        {
            throw new System.NotImplementedException();
        }

        public string ObtenirDescription(int id)
        {
            return GetById(id).Description;
        }
    }


}
