using System;
using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using ATMTECH.Web;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.PurolatorEstimatingProxy;

namespace ATMTECH.Test.Website
{
    public partial class _Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void EmptyDisplay()
        {
            txtResultat.Text = string.Empty;
        }
        private void Display(string display)
        {
            txtResultat.Text += display;
        }

        protected void TestOpenWindow(object sender, EventArgs e)
        {
            fenetreOuvrir.OuvrirFenetre("ccaccaca");
        }

        protected void TestPurolator(object sender, EventArgs e)
        {
            PurolatorService purolatorService = new PurolatorService();
            PurolatorPackage purolatorPackage = new PurolatorPackage();
            purolatorPackage.PackageType = PurolatorPackageType.EXPRESS_BOX;
            purolatorPackage.CountryReceiverCode = "CA";
            purolatorPackage.ReceiverPostalCode = "G6K1A6";
            purolatorPackage.SenderPostalCode = "G1R5P8";
            purolatorPackage.TotalWeight = 10;
            purolatorPackage.WeightUnit = WeightUnit.lb;
            string url =  Utils.Configuration.GetConfigurationKey("PurolatorWebServiceUrl");
            string userName = Utils.Configuration.GetConfigurationKey("PurolatorUserName");
            string password = Utils.Configuration.GetConfigurationKey("PurolatorPassword");
            string accountId = Utils.Configuration.GetConfigurationKey("PurolatorBillingAccount");

            ConfigurationPurolatorWebService configuration = new ConfigurationPurolatorWebService() { Login = userName, Url = url, Password = password, AccountId = accountId };

            IList<PurolatorEstimateReturn> purolatorEstimateReturn = purolatorService.GetQuickEstimate(purolatorPackage, configuration);

            EmptyDisplay();
            if (purolatorEstimateReturn != null)
            {
                foreach (PurolatorEstimateReturn estimateReturn in purolatorEstimateReturn)
                {
                    Display(estimateReturn.ServiceId + " " + estimateReturn.ExpectedArrival + " " +
                            estimateReturn.TotalPrice + "<br>");
                }
            }
        }

        protected void TestGenerateCreateTableSqlFromClass(object sender, EventArgs e)
        {
            EmptyDisplay();
            ManageClass manageClass = new ManageClass();
            Display(manageClass.GenerateCreateTableSqlFromClass("ATMTECH.Test.Entities", "EntityTest"));
        }

        protected void TestGenerateAlterTableSqlFromClass(object sender, EventArgs e)
        {
            EmptyDisplay();
            ManageClass manageClass = new ManageClass();
            Display(manageClass.GenerateAlterTableSqlFromClass("ATMTECH.Test.Entities", "EntityTest"));
        }

        protected void TestIpCountry(object sender, EventArgs e)
        {
            EmptyDisplay();
            NavigationService navigationService = new NavigationService();
            Display(navigationService.GetCountryFromIp("217.208.23.45").CountryName);
        }
    }
}
