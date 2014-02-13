using System.Text.RegularExpressions;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services
{
    public class ValidateCustomerService : BaseService, IValidateCustomerService
    {
        public IMessageService MessageService { get; set; }
        public IDAOUser DAOUser { get; set; }

        public void IsValidCustomerOnCreate(Customer customer)
        {
            ValidateEmail(customer.User.Email);
            ValidateIfUserAlreadyExist(customer);
        }

        public void IsValidCustomerOnUpdate(Customer customer)
        {
            ValidateEmail(customer.User.Email);
        }

        private void ValidateIfUserAlreadyExist(Customer customer)
        {
            User user = DAOUser.GetUser(customer.User.Login);
            if (user != null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_THIS_USER_ALREADY_EXIST);
            }
        }

        private void ValidateEmail(string email)
        {
            const string matchEmailPattern =
                @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";

            if (!Regex.IsMatch(email, matchEmailPattern))
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_INVALID_EMAIL);
            }
        }
    }
}
