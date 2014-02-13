namespace ATMTECH.Entities
{
    public partial class User
    {
        public string FirstNameLastName { get { return  FirstName + " " + LastName; } }
    }
}
