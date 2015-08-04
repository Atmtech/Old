namespace ATMTECH.Entities
{
    public partial class User
    {
        public string FirstNameLastName { get { return  FirstName + " " + LastName; } }
        public string PasswordConfirmation { get; set; }
    }
}
