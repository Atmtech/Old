using System.Collections.Generic;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOUser : BaseDao<User, int>, IDAOUser
    {
        public IDAOGroupUser DAOGroupUser { get; set; }

        public User GetAuthenticateUser(string login, string password)
        {

            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = User.LOGIN, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = login };
            Criteria criteriaActive = new Criteria() { Column = User.PASSWORD, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = password };
            criterias.Add(criteriaMenu);
            criterias.Add(criteriaActive);

            IList<User> contents = GetByCriteria(criterias);
            if (contents.Count > 0)
            {
                if (DAOGroupUser != null)
                {
                    foreach (User content in contents)
                    {
                        content.Groups = DAOGroupUser.GetGroupByUser(content.Id);
                    }
                }
                return contents[0];
            }
            else
            {
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = User.EMAIL, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = email };
            criterias.Add(criteriaMenu);

            IList<User> contents = GetByCriteria(criterias);
            if (contents.Count > 0)
            {
                return contents[0];
            }
            else
            {
                return null;
            }
        }
        public User GetUser(string login)
        {

            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = User.LOGIN, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = login };
            criterias.Add(criteriaMenu);

            IList<User> contents = GetByCriteria(criterias);
            if (contents.Count > 0)
            {
                return contents[0];
            }
            else
            {
                return null;
            }
        }

        public User GetUser(int id)
        {
            return GetById(id);
        }

        public void UpdateUser(User user)
        {
            Save(user);
        }

        public int CreateUser(User user)
        {
            return Save(user);
        }

        public IList<User> GetAllUser()
        {
            return GetAll();
        }
    }
}
