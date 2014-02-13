using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Shell.Tests;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.ErrorCode;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Tests.Builder;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.ShoppingCart.Tests.Services
{
    [Ignore]
    [TestClass]
    public class CustomerServiceTest : BaseTest<CustomerService>
    {
        public Mock<IDAOCustomer> MockDAOCustomer { get { return ObtenirMock<IDAOCustomer>(); } }
        public Mock<IAddressService> MockAddressService { get { return ObtenirMock<IAddressService>(); } }
        public Mock<IEnterpriseService> MockEnterpriseService { get { return ObtenirMock<IEnterpriseService>(); } }
        public Mock<IValidateCustomerService> MockValidateCustomerService { get { return ObtenirMock<IValidateCustomerService>(); } }
        public Mock<IDAOUser> MockDAOUser { get { return ObtenirMock<IDAOUser>(); } }

        [TestMethod]
        public void GetCustomerDoitAvoirBillingEtShippingAddress()
        {
            Customer customerReturn = CustomerBuilder.CreateValid();
            Address address = AddressBuilder.CreateValid();
            Enterprise enterprise = EnterpriseBuilder.CreateValid();

            MockDAOCustomer.Setup(test => test.GetCustomer(It.IsAny<int>())).Returns(customerReturn);
            MockAddressService.Setup(test => test.GetAddress(It.IsAny<int>())).Returns(address);
            MockEnterpriseService.Setup(test => test.GetEnterprise(It.IsAny<int>())).Returns(enterprise);

            Customer customer = InstanceTest.GetCustomer(1);

            customer.BillingAddress.Should().Be(address);
            customer.ShippingAddress.Should().Be(address);

            MockDAOCustomer.Verify(test => test.GetCustomer(customer.Id), Times.Once());
            MockAddressService.Verify(test => test.GetAddress(address.Id), Times.Exactly(2));
            MockEnterpriseService.Verify(test => test.GetEnterprise(enterprise.Id), Times.Once());
        }

        [TestMethod]
        public void CreateCustomerDevraitSortirMessageInvalidSiAucunCustomer()
        {
            InstanceTest.CreateCustomer(null);
            MockMessageService.Verify(test => test.ThrowMessage(ErrorCode.SC_SEND_MAIL_FAILED), Times.Once());
        }

        [TestMethod]
        public void CreateCustomerDevraitValiderCustomer()
        {
            InstanceTest.CreateCustomer(null);
            MockValidateCustomerService.Verify(test => test.IsValidCustomerOnCreate(null), Times.Once());
        }

        [TestMethod]
        public void CreateCustomerDevraitRetournerFalseSiCustomerNull()
        {
            bool rtn = InstanceTest.CreateCustomer(null);
            rtn.Should().BeFalse();
        }

        [TestMethod]
        public void CreateCustomerDevraitEtreInactifALaCreation()
        {
            Customer customer = CustomerBuilder.CreateValid();
            User user = UserBuilder.CreateValid();
            user.IsActive = true;

            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns(user);

            InstanceTest.CreateCustomer(customer);

            MockDAOUser.Verify(test => test.UpdateUser(It.Is<User>(arg => arg.IsActive == false)));
        }

        [TestMethod]
        public void CreateCustomerDevraitEnvoyerunCourriel()
        {
            Customer customer = CustomerBuilder.CreateValid();
            User user = UserBuilder.CreateValid();

            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns(user);
            MockDAOCustomer.Setup(test => test.CreateCustomer(It.IsAny<Customer>())).Returns(1);
            MockDAOCustomer.Setup(test => test.GetCustomer(It.IsAny<int>())).Returns(customer);
            MockParameterService.Setup(test => test.GetValue(Constant.ADMIN_MAIL)).Returns("ADMIN_MAIL");
            MockParameterService.Setup(test => test.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE)).Returns("MAIL_SUBJECT_CONFIRM_CREATE");
            MockParameterService.Setup(test => test.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE)).Returns("MAIL_BODY_CONFIRM_CREATE");

            InstanceTest.CreateCustomer(customer);

            MockMailService.Verify(test => test.SendEmail(user.Email, "ADMIN_MAIL", "MAIL_SUBJECT_CONFIRM_CREATE", "MAIL_BODY_CONFIRM_CREATE"));

        }

        [TestMethod]
        public void CreateCustomerDevraitEnvoyerunMessageErreurSiCourrielEchou()
        {
            Customer customer = CustomerBuilder.CreateValid();
            User user = UserBuilder.CreateValid();

            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns(user);
            MockDAOCustomer.Setup(test => test.CreateCustomer(It.IsAny<Customer>())).Returns(1);
            MockDAOCustomer.Setup(test => test.GetCustomer(It.IsAny<int>())).Returns(customer);
            MockParameterService.Setup(test => test.GetValue(Constant.ADMIN_MAIL)).Returns("ADMIN_MAIL");
            MockParameterService.Setup(test => test.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE)).Returns("MAIL_SUBJECT_CONFIRM_CREATE");
            MockParameterService.Setup(test => test.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE)).Returns("MAIL_BODY_CONFIRM_CREATE");

            MockMailService.Setup(
                test =>
                test.SendEmail(user.Email, "ADMIN_MAIL", "MAIL_SUBJECT_CONFIRM_CREATE", "MAIL_BODY_CONFIRM_CREATE"))
                           .Returns(false);

            InstanceTest.CreateCustomer(customer);

            MockMessageService.Verify((test => test.ThrowMessage(ErrorCode.SC_SEND_MAIL_FAILED)));

        }

        [TestMethod]
        public void GetCustomerByEnterpriseRetourneListeCustomerPourEnterprise()
        {
            InstanceTest.GetCustomerByEnterprise(1);
            MockDAOCustomer.Verify(test => test.GetCustomerByEnterprise(1), Times.Once());
        }

        [TestMethod]
        public void SaveCustomerDoitValiderCustomer()
        {
            Customer customer = CustomerBuilder.CreateValid();
            InstanceTest.SaveCustomer(customer);

            MockValidateCustomerService.Verify(test => test.IsValidCustomerOnUpdate(customer), Times.Once());
        }

        [TestMethod]
        public void SaveCustomerDoitSauvegarderCustomer()
        {
            Customer customer = CustomerBuilder.CreateValid();
            InstanceTest.SaveCustomer(customer);

            MockDAOCustomer.Verify(test => test.SaveCustomer(customer), Times.Once());
        }

        [TestMethod]
        public void SendForgetPasswordDoitObtenirUserParCourriel()
        {
            InstanceTest.SendForgetPassword("test@test.com");

            MockDAOUser.Verify(test => test.GetUserByEmail("test@test.com"),Times.Once());
        }

        [TestMethod]
        public void SendForgetPasswordQuandUserEstNullOnRetourneFalse()
        {
            bool rtn = InstanceTest.SendForgetPassword("test@test.com");
            rtn.Should().BeFalse();
        }

        [TestMethod]
        public void SendForgetPasswordQuandUserNestPasNullEtQuelonNeTrouvePAsDeCustomerRetourneFalse()
        {
            User user = UserBuilder.CreateValid();
            MockDAOUser.Setup(test => test.GetUserByEmail(user.Email)).Returns(user);

            bool rtn = InstanceTest.SendForgetPassword(user.Email);
            rtn.Should().BeFalse();
        }

        [TestMethod]
        public void SendForgetPasswordQuandUserNestPasNullEtQuonTrouveCustomerOnEnvoitCourriel()
        {
            User user = UserBuilder.CreateValid();
            Customer customer = CustomerBuilder.CreateValid();

            MockEnterpriseService.Setup(test => test.GetEnterprise());
            MockDAOUser.Setup(test => test.GetUserByEmail(user.Email)).Returns(user);
            MockDAOCustomer.Setup(test => test.GetCustomer(It.IsAny<int>())).Returns(customer);
            MockParameterService.Setup(test => test.GetValue(Constant.ADMIN_MAIL)).Returns("ADMIN_MAIL");
            MockParameterService.Setup(test => test.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE)).Returns("MAIL_SUBJECT_FORGET_PASSWORD");
            MockParameterService.Setup(test => test.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE)).Returns("MAIL_BODY_FORGET_PASSWORD");

            //bool rtn = InstanceTest.SendForgetPassword(user.Email);
          //  rtn.Should().BeFalse();
        }
    }
}
