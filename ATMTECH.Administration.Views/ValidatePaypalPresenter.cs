using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class ValidatePaypalPresenter : BaseAdministrationPresenter<IValidatePaypalPresenter>
    {
        public IEnterpriseService EnterpriseService { get; set; }
        public IOrderService OrderService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public ValidatePaypalPresenter(IValidatePaypalPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Enterprises = EnterpriseService.GetEnterpriseByAccess(AuthenticationService.AuthenticateUser);

            User user = AuthenticationService.AuthenticateUser;
            if (user == null) return;
            if (!user.IsAdministrator)
            {
                NavigationService.Redirect("default.aspx");
            }
        }

        public string Generate()
        {
            Enterprise enterprise = EnterpriseService.GetEnterprise(Convert.ToInt32(View.EnterpriseSelected));
            IList<Order> orders = OrderService.GetAllToValidatePaypal(enterprise, View.DateStart,
                                                                                      View.DateEnd).OrderByDescending(x => x.FinalizedDate).ToList();
            string html = "<table><tr><td>Date</td><td>Nom</td><td>Numéro de facture</td><td>Hors taxes</td></tr>";
            foreach (Order order in orders)
            {
                html += "<tr>";
                html += "<td>";
                html += order.FinalizedDate;
                html += "</td>";
                html += "<td>";
                html += order.CustomerFullName;
                html += "</td>";
                html += "<td>";
                html += order.Id;
                html += "</td>";
                html += "<td>";
                html += order.GrandTotal;
                html += "</td>";
                html += "</tr>";
            }

            html += "</table>";
            return html;
        }

    }
}
