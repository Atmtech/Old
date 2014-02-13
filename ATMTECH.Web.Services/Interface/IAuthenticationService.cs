using ATMTECH.Entities;

namespace ATMTECH.Web.Services.Interface
{
    public interface IAuthenticationService
    {
        User SignIn(string login, string password);
        User AuthenticateUser { get; set; }
        User GetUser(int id);
        void SignOut();
    }
}
