using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class ToolsPresenter : BaseAdministrationPresenter<IToolsPresenter>
    {
        public IOrderService OrderService { get; set; }
        public IStockService StockService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IProductService ProductService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IDAOUser DAOUser { get; set; }
        public ToolsPresenter(IToolsPresenter view)
            : base(view)
        {

        }
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.ProductWithoutStock = ProductService.GetProductsWithoutStock(View.EnterpriseSelect);
            View.StockTemplate = StockService.GetStockTemplate();
            IList<Customer> customers = CustomerService.GetAll();
            IList<User> user = DAOUser.GetAllUser();
            View.Users = user.Where(user1 => customers.Count(x => x.User.Id == user1.Id) == 0).ToList();
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Enterprise = EnterpriseService.GetAll().Where(x => x.IsActive).ToList();
        }

        public void ApplyStockTemplate(string productId, string templateGroup, int quantity, bool isWithoutStock)
        {
            Product product = ProductService.GetProductSimple(Convert.ToInt32(productId));
            StockService.CreateStockWithTemplate(product, templateGroup, quantity, isWithoutStock);
            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }
        public void ConfirmOrder(string id)
        {
            OrderService.ConfirmOrder(Convert.ToInt32(id));
            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }
        public void DisplayOrder(int id)
        {
            Order order = OrderService.GetOrder(id);
            OrderService.PrintOrder(order);
        }
        public void AssociateUser(int idUser, int idEnterprise)
        {
            User user = AuthenticationService.GetUser(idUser);
            if (user != null)
            {
                Customer customer = CustomerService.GetCustomer(user.Id);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        IsActive = true,
                        Enterprise = new Enterprise { Id = idEnterprise },
                        User = new User
                        {
                            Id = idUser
                        }

                    };

                    CustomerService.SaveCustomer(customer);
                    MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
                }

            }
        }
        public void CreateEnterpriseFromAnother(int id, string newName)
        {
            EnterpriseService.CreateEnterpriseFromAnother(id, newName, AuthenticationService.AuthenticateUser);
            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }
    }
}
