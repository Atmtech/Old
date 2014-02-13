using System;
using System.Collections.Generic;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.PurolatorEstimatingProxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Test
{
    [Ignore]
    [TestClass]
    public class PurolatorServiceTest
    {
        [TestMethod]
        public void WithPackageExpressReturnTotalPrice911()
        {
            PurolatorService purolatorService = new PurolatorService();
            PurolatorPackage purolatorPackage = new PurolatorPackage
                                                    {
                                                        PackageType = PurolatorPackageType.CUSTOMER_PACKAGING,
                                                        CountryReceiverCode = "CA",
                                                        ReceiverPostalCode = "G6K1A6",
                                                        SenderPostalCode = "G1R5P8",
                                                        TotalWeight = 10,
                                                        WeightUnit = WeightUnit.lb
                                                    };

            const string url = "https://devwebservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx";
            const string userName = "9968ce4f2f594cc9b7b2b6c3c1e763f3";
            const string password = "+nD.&qZj";
            const string accountId = "9999999999";

            ConfigurationPurolatorWebService configuration = new ConfigurationPurolatorWebService() { Login = userName, Url = url, Password = password, AccountId = accountId };

            IList<PurolatorEstimateReturn> purolatorEstimateReturn = purolatorService.GetQuickEstimate(purolatorPackage, configuration);
            Assert.AreEqual(purolatorEstimateReturn[1].TotalPrice, Convert.ToDecimal("9,11"));
        }

        [TestMethod]
        public void ProductionKeyPackageExpressReturnTotal()
        {
            PurolatorService purolatorService = new PurolatorService();
            PurolatorPackage purolatorPackage = new PurolatorPackage();
            purolatorPackage.PackageType = PurolatorPackageType.CUSTOMER_PACKAGING;
            purolatorPackage.CountryReceiverCode = "CA";
            purolatorPackage.ReceiverPostalCode = "G1M2K2";
            purolatorPackage.SenderPostalCode = "G1M3R8";
            purolatorPackage.TotalWeight = 1;
            purolatorPackage.WeightUnit = WeightUnit.lb;

            const string url = "https://webservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx";
            const string userName = "f5effc1701f841d69d8a4a20ffd41ced";
            const string password = "}2Jk-aJ|";
            const string accountId = "1539293";

            ConfigurationPurolatorWebService configuration = new ConfigurationPurolatorWebService() { Login = userName, Url = url, Password = password, AccountId = accountId };

            IList<PurolatorEstimateReturn> purolatorEstimateReturn = purolatorService.GetQuickEstimate(purolatorPackage, configuration);
            Assert.AreEqual(purolatorEstimateReturn[1].TotalPrice, Convert.ToDecimal("15,72"));
        }

        [TestMethod]
        public void ProductionKeyPackageExpressReturnTotalPrice967()
        {
            PurolatorService purolatorService = new PurolatorService();
            PurolatorPackage purolatorPackage = new PurolatorPackage();
            purolatorPackage.PackageType = PurolatorPackageType.CUSTOMER_PACKAGING;
            purolatorPackage.CountryReceiverCode = "CA";
            purolatorPackage.ReceiverPostalCode = "G6K1A6";
            purolatorPackage.SenderPostalCode = "G1R5P8";
            purolatorPackage.TotalWeight = 10;
            purolatorPackage.WeightUnit = WeightUnit.lb;

            const string url = "https://webservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx";
            const string userName = "f5effc1701f841d69d8a4a20ffd41ced";
            const string password = "}2Jk-aJ|";
            const string accountId = "1539293";
            
            ConfigurationPurolatorWebService configuration = new ConfigurationPurolatorWebService() { Login = userName, Url = url, Password = password, AccountId = accountId };

            IList<PurolatorEstimateReturn> purolatorEstimateReturn = purolatorService.GetQuickEstimate(purolatorPackage, configuration);
            Assert.AreEqual(purolatorEstimateReturn[1].TotalPrice, Convert.ToDecimal("9,7"));
        }

        [TestMethod]
        public void WithPackageTotalWeightUpper150Lb()
        {
            PurolatorService purolatorService = new PurolatorService();
            PurolatorPackage purolatorPackage = new PurolatorPackage();
            purolatorPackage.PackageType = PurolatorPackageType.CUSTOMER_PACKAGING;
            purolatorPackage.CountryReceiverCode = "CA";
            purolatorPackage.ReceiverPostalCode = "G6K1A6";
            purolatorPackage.SenderPostalCode = "G1R5P8";
            purolatorPackage.TotalWeight = 200;
            purolatorPackage.WeightUnit = WeightUnit.lb;

            const string url = "https://devwebservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx";
            const string userName = "9968ce4f2f594cc9b7b2b6c3c1e763f3";
            const string password = "+nD.&qZj";
            const string accountId = "9999999999";

            ConfigurationPurolatorWebService configuration = new ConfigurationPurolatorWebService() { Login = userName, Url = url, Password = password, AccountId = accountId };

            IList<PurolatorEstimateReturn> purolatorEstimateReturn = purolatorService.GetQuickEstimate(purolatorPackage, configuration);
            Assert.AreEqual(purolatorEstimateReturn[0].IsFail, true);
        }

        [TestMethod]
        public void WithBadUrlAdressReturnNull()
        {
            PurolatorService purolatorService = new PurolatorService();
            PurolatorPackage purolatorPackage = new PurolatorPackage();
            purolatorPackage.PackageType = PurolatorPackageType.CUSTOMER_PACKAGING;
            purolatorPackage.CountryReceiverCode = "CA";
            purolatorPackage.ReceiverPostalCode = "G6K1A6";
            purolatorPackage.SenderPostalCode = "G1R5P8";
            purolatorPackage.TotalWeight = 200;
            purolatorPackage.WeightUnit = WeightUnit.lb;

            const string url = "https://devwebservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx2212121";
            const string userName = "9968ce4f2f594cc9b7b2b6c3c1e763f3";
            const string password = "+nD.&qZj";
            const string accountId = "9999999999";

            ConfigurationPurolatorWebService configuration = new ConfigurationPurolatorWebService() { Login = userName, Url = url, Password = password, AccountId = accountId };

            IList<PurolatorEstimateReturn> purolatorEstimateReturn = purolatorService.GetQuickEstimate(purolatorPackage, configuration);
            Assert.IsNull(purolatorEstimateReturn);
        }

        [TestMethod]
        public void WithBadLoginReturnNull()
        {
            PurolatorService purolatorService = new PurolatorService();
            PurolatorPackage purolatorPackage = new PurolatorPackage();
            purolatorPackage.PackageType = PurolatorPackageType.CUSTOMER_PACKAGING;
            purolatorPackage.CountryReceiverCode = "CA";
            purolatorPackage.ReceiverPostalCode = "G6K1A6";
            purolatorPackage.SenderPostalCode = "G1R5P8";
            purolatorPackage.TotalWeight = 200;
            purolatorPackage.WeightUnit = WeightUnit.lb;

            const string url = "https://devwebservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx";
            const string userName = "9968ce4f2f594cc9b7b2b6c3c1e763f3221";
            const string password = "+nD.&qZj";
            const string accountId = "9999999999";

            ConfigurationPurolatorWebService configuration = new ConfigurationPurolatorWebService() { Login = userName, Url = url, Password = password, AccountId = accountId };

            IList<PurolatorEstimateReturn> purolatorEstimateReturn = purolatorService.GetQuickEstimate(purolatorPackage, configuration);
            Assert.IsNull(purolatorEstimateReturn);
        }
    }
}
