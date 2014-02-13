using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOGroupUser : BaseDao<GroupUser, int>, IDAOGroupUser
    {
        public IList<Group> GetGroupByUser(int idUser)
        {
            IList<GroupUser> groupUsers = GetAllOneCriteria(GroupUser.USER, idUser.ToString());
            return groupUsers.Select(groupUser => groupUser.Group).ToList();
        }
    }
}
