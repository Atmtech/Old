using System;
using System.Collections.Generic;

namespace ATMTECH.Entities
{
    [Serializable]
    public partial class User : BaseEntity
    {
        public const string LOGIN = "Login";
        public const string PASSWORD = "Password";
        public const string EMAIL = "Email";

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsSuperUser { get; set; }
        public DateTime LastLogin { get; set; }
        public File Image { get; set; }

        public IList<Group> Groups { get; set; }

        public string SearchUpdate { get { return FirstNameLastName + " " + Login + " " + Email; } }
        public string ComboboxDescriptionUpdate { get { return FirstNameLastName; } }

    }
}
