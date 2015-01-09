using System.Collections.Generic;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services
{
    public class CustomerService : BaseService, ICustomerService
    {

        public IMessageService MessageService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public IDAOCustomer DAOCustomer { get; set; }
        public IDAOUser DAOUser { get; set; }
        public IMailService MailService { get; set; }
        public IParameterService ParameterService { get; set; }
        public IValidateCustomerService ValidateCustomerService { get; set; }
        public ITaxesService TaxesService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IAddressService AddressService { get; set; }

        public Customer AuthenticateCustomer
        {
            get
            {
                if (AuthenticationService.AuthenticateUser != null)
                {
                    return GetCustomer(AuthenticationService.AuthenticateUser.Id);
                }
                return null;
            }
        }
        public IList<Customer> GetCustomerByEnterprise(int idEnterprise)
        {
            return DAOCustomer.GetCustomerByEnterprise(idEnterprise);
        }

        public IList<Customer> GetAll()
        {
            return DAOCustomer.GetAll();

        }

        public Customer GetCustomer(int idUser)
        {
            Customer customer = DAOCustomer.GetCustomerFromUser(idUser);
            if (customer != null)
            {
                if (customer.BillingAddress.Id != 0)
                {
                    customer.BillingAddress = AddressService.GetAddress(customer.BillingAddress.Id);
                }
                if (customer.ShippingAddress.Id != 0)
                {
                    customer.ShippingAddress = AddressService.GetAddress(customer.ShippingAddress.Id);
                }

                if (customer.Enterprise != null)
                {
                    customer.Enterprise = EnterpriseService.GetEnterprise(customer.Enterprise.Id);    
                }
            }

            return customer;
        }
        public bool CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                MessageService.ThrowMessage(ErrorCode.SC_SEND_MAIL_FAILED);
            }

            ValidateCustomerService.IsValidCustomerOnCreate(customer);

            if (customer != null)
            {
                int rtn = DAOUser.CreateUser(customer.User);
                customer.User.Id = rtn;
                customer.User.IsActive = false;
                int idCustomer = DAOCustomer.CreateCustomer(customer);

                Customer customerCreate = DAOCustomer.GetCustomer(idCustomer);

                SetUserInactive(rtn);

                if (idCustomer > 0)
                {

                    bool ret = MailService.SendEmail(customerCreate.User.Email,
                                                  ParameterService.GetValue(Constant.ADMIN_MAIL),
                                                   string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE), customerCreate.Enterprise.Name),
                                                  string.Format(ParameterService.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE), customerCreate.Enterprise.Name, customerCreate.Enterprise.SubDomainName, customer.User.Id));
                    if (ret == false)
                    {
                        MessageService.ThrowMessage(ErrorCode.SC_SEND_MAIL_FAILED);
                    }
                }
                return true;
            }
            return false;
        }
        public void SaveCustomer(Customer customer)
        {
            ValidateCustomerService.IsValidCustomerOnUpdate(customer);
            DAOCustomer.SaveCustomer(customer);
        }
        public bool SendForgetPassword(string email)
        {
            User user = DAOUser.GetUserByEmail(email);
            if (user != null)
            {
                string password = user.Password;
                string login = user.Login;

                Customer customer = GetCustomer(user.Id);

                if (customer != null)
                {
                    return MailService.SendEmail(email, ParameterService.GetValue(Constant.ADMIN_MAIL),
                                                 ParameterService.GetValue(Constant.MAIL_SUBJECT_FORGET_PASSWORD),
                                                 string.Format(
                                                     ParameterService.GetValue(Constant.MAIL_BODY_FORGET_PASSWORD),
                                                     customer.Enterprise.Name, login, password));
                }
                return false;
            }
            return false;
        }
        public bool ConfirmCreate(int idUser)
        {
            User user = DAOUser.GetUser(idUser);
            if (user != null)
            {
                if (user.IsActive == false)
                {
                    user.IsActive = true;
                    DAOUser.UpdateUser(user);
                    AuthenticationService.SignIn(user.Login, user.Password);
                    return true;
                }
            }
            else
            {
                MessageService.ThrowMessage(ErrorCode.SC_USER_NOT_EXIST_ON_CONFIRM);
            }
            return false;
        }

        private void SetUserInactive(int id)
        {
            User user = DAOUser.GetUser(id);
            user.IsActive = false;
            DAOUser.UpdateUser(user);
        }

    }
}
