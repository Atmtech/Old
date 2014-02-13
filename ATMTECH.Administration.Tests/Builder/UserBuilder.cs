using ATMTECH.Entities;

namespace ATMTECH.Administration.Tests.Builder
{
    public static class UserBuilder
    {
        public static User Create()
        {
            return new User() { Id = 1 };
        }

        public static User CreateValid()
        {
            return Create().WithFirstName("Vincent").WithLastName("Rioux").WithLogin("riov01").WithPassword("xxx").WithEmail("sag@hotmail.com");
        }

        public static User WithEmail(this User user, string email)
        {
            user.Email = email;
            return user;
        }

        public static User WithIsActive(this User user, bool isActive)
        {
            user.IsActive = isActive;
            return user;
        }
        public static User WithIsAdministrator(this User user, bool isAdministrator)
        {
            user.IsAdministrator = isAdministrator;
            return user;
        }
        public static User WithFirstName(this User user, string firstName)
        {
            user.FirstName = firstName;
            return user;
        }

        public static User WithLastName(this User user, string lastName)
        {
            user.LastName = lastName;
            return user;
        }

        public static User WithLogin(this User user, string login)
        {
            user.Login = login;
            return user;
        }

        public static User WithPassword(this User user, string password)
        {
            user.Password = password;
            return user;
        }
        public static User WithId(this User user, int id)
        {
            user.Id = id;
            return user;
        }
       
    }
}
