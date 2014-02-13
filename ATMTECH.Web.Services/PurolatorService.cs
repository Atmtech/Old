using System;
using System.Collections.Generic;
using System.Net;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;
using ATMTECH.Web.Services.PurolatorEstimatingProxy;

namespace ATMTECH.Web.Services
{
    // Serveur Production : https://webservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx
    // Serveur Developpement : https://devwebservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx

    public class PurolatorService : BaseService, IPurolatorService
    {
        #region Estimation
        private EstimatingService GetServiceEstimation(ConfigurationPurolatorWebService configuration)
        {
            EstimatingService service = new EstimatingService(configuration.Url);
            string username = configuration.Login;
            string password = configuration.Password;
            service.Credentials = new NetworkCredential(username, password);
            service.RequestContextValue = new RequestContext
                {
                    Version = "1.3",
                    Language = Language.en,
                    GroupID = "",
                    RequestReference = "RequestReference"
                };
            return service;
        }

        public IList<PurolatorEstimateReturn> GetQuickEstimate(PurolatorPackage purolatorPackage, ConfigurationPurolatorWebService configuration)
        {
            EstimatingService service = GetServiceEstimation(configuration);
            GetQuickEstimateRequestContainer request = new GetQuickEstimateRequestContainer
                {
                    BillingAccountNumber = configuration.AccountId,
                    SenderPostalCode = purolatorPackage.SenderPostalCode,
                    PackageType = purolatorPackage.PackageType,
                    ReceiverAddress = new ShortAddress
                        {
                            Country = purolatorPackage.CountryReceiverCode,
                            Province = purolatorPackage.ProvinceReceiverCode,
                            PostalCode = purolatorPackage.ReceiverPostalCode
                        },
                    TotalWeight = new TotalWeight
                        {
                            Value = purolatorPackage.TotalWeight,
                            WeightUnit = purolatorPackage.WeightUnit
                        }
                };

            try
            {
                GetQuickEstimateResponseContainer response = service.GetQuickEstimate(request);
                IList<PurolatorEstimateReturn> purolatorEstimateReturns = new List<PurolatorEstimateReturn>();
                if (response.ResponseInformation.Errors.Length > 0)
                {
                    PurolatorEstimateReturn purolatorEstimateReturn = new PurolatorEstimateReturn();

                    string errormsg = string.Empty;
                    foreach (Error error in response.ResponseInformation.Errors)
                    {
                        errormsg += error.Code + " " + error.Description;
                    }
                    purolatorEstimateReturn.IsFail = true;
                    purolatorEstimateReturn.FailMessage = errormsg;
                    purolatorEstimateReturn.TotalPrice = 0;
                    purolatorEstimateReturns.Add(purolatorEstimateReturn);
                    return purolatorEstimateReturns;
                }
                else
                {
                    foreach (ShipmentEstimate estimate in response.ShipmentEstimates)
                    {
                        PurolatorEstimateReturn purolatorEstimate = new PurolatorEstimateReturn
                            {
                                IsFail = false,
                                TotalPrice = estimate.TotalPrice,
                                ServiceId = estimate.ServiceID,
                                ExpectedArrival = estimate.ExpectedDeliveryDate
                            };
                        purolatorEstimateReturns.Add(purolatorEstimate);
                    }
                    return purolatorEstimateReturns;
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(" EXCEPTION: {0}", ex.Message);
            }
            return null;
        }
        #endregion
    }

    public class PurolatorEstimateReturn
    {
        public decimal TotalPrice { get; set; }
        public bool IsFail { get; set; }
        public string FailMessage { get; set; }
        public string ServiceId { get; set; }
        public string ExpectedArrival { get; set; }
    }

    public class PurolatorPackage
    {
        public string BillingAccountNumer { get; set; }
        public string SenderPostalCode { get; set; }
        public string ReceiverPostalCode { get; set; }
        public string PackageType { get; set; }
        public int TotalWeight { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public string CountryReceiverCode { get; set; }
        public string ProvinceReceiverCode { get; set; }
    }

    public class PurolatorPackageType
    {
        public const string EXPRESS_ENVELOPE = "ExpressEnvelope";
        public const string EXPRESS_PACK = "ExpressPack";
        public const string CUSTOMER_PACKAGING = "CustomerPackaging";
        public const string EXPRESS_BOX = "ExpressBox";
    }

    public class PurolatorServiceType
    {
        public const string EXPRESS_BOX = "PurolatorExpressBox";
    }

    public class ConfigurationPurolatorWebService
    {
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
    }

}
