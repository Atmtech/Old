using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOUser
    {
        User GetAuthenticateUser(string login, string password);
        User GetUser(int id);
        void UpdateUser(User user);
        int CreateUser(User user);
        User GetUser(string login);
        User GetUserByEmail(string email);
        IList<User> GetAllUser();
        IList<User> SearchUser(string search);
        IList<User> GetAllActive();
        
    }
}
