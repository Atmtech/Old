using System;
using ATMTECH.Common;
using ATMTECH.Common.Context;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public IDAOUser DaoUser { get; set; }
        public IMessageService MessageService { get; set; }
        private User _authenticateUser;
        public User AuthenticateUser
        {
            get
            {
                if (ContextSessionManager.Session != null)
                {
                    if (ContextSessionManager.Session["Internal_LoggedUser"] != null)
                    {
                        return (User)ContextSessionManager.Session["Internal_LoggedUser"];
                    }
                    return null;
                }
                return _authenticateUser;
            }
            set
            {
                if (ContextSessionManager.Session != null)
                {
                    ContextSessionManager.Session["Internal_LoggedUser"] = value;
                }
                else
                {
                    _authenticateUser = value;
                }

            }
        }

        public User SignIn(string login, string password)
        {
            User user = DaoUser.GetAuthenticateUser(login, password);
            if (user != null)
            {
                if (user.IsActive)
                {
                    user.LastLogin = DateTime.Now;
                    DaoUser.UpdateUser(user);
                    AuthenticateUser = user;
                }
                return user;
            }
            else
            {
                MessageService.ThrowMessage(Common.ErrorCode.ADM_BAD_LOGIN);
                return null;
            }


        }

        public void SignOut()
        {
            AuthenticateUser = null;
        }

        public User GetUser(int id)
        {
            return DaoUser.GetUser(id);
        }
    }
}
