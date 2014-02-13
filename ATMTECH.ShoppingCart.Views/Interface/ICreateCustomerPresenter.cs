using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface ICreateCustomerPresenter : IViewBase
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string PasswordConfirmation { get; set; }

        string Email { get; set; }
      
        bool CreateSuccess {  set; }
     
    }
}
