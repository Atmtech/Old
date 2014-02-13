using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;

namespace ATMTECH.Achievement.DAO
{
    public class DAOAmitie : BaseDao<Amitie, int>, IDAOAmitie
    {
        public int Update(Amitie amitie)
        {
            return Save(amitie);
        }
    }
}
