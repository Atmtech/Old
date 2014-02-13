using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Vachier.Entities;

namespace ATMTECH.Vachier.DAO
{
    public class DAOMerdeux : BaseDao<Merdeux, int>, IDAOMerdeux
    {
        public IList<Merdeux> ObtenirListeMerdeux()
        {
            return GetAllOneCriteria(Merdeux.PUBLISH, "1");
        }

        public void AjouterMerdeCelebre(Merdeux merdeux)
        {
            throw new System.NotImplementedException();
        }

        public string ObtenirDescription(int id)
        {
            return GetById(id).Description;
        }
    }


}
