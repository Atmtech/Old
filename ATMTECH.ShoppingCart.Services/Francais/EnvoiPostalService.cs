using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;
using ATMTECH.Web.Services.PurolatorEstimatingProxy;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class EnvoiPostalService : BaseService, IEnvoiPostalService
    {
        public IMessageService MessageService { get; set; }
        public IPurolatorService PurolatorService { get; set; }
        public IParameterService ParameterService { get; set; }

        public decimal ObtenirCotationPurolator(Order commande)
        {

            decimal total = 0;
            if (commande.ShippingAddress == null)
            {
                return total;
            }


            if (string.IsNullOrEmpty(commande.ShippingAddress.PostalCode))
            {
                return total;
            }

            if ((int)commande.TotalWeight == 0)
            {
                MessageService.ThrowMessage(ErrorCode.SC_WEIGHT_EQUAL_ZERO_CANNOT_EVALUATE_SHIPPING_COST);
                return total;
            }

            ShippingParameter shippingParameter = new ShippingParameter
            {
                BillingAccount = "99999999",
                CountryReceiverCode = ParameterService.GetValue("PurolatorCountryReceiverCode"),
                PackageType = PurolatorPackageType.EXPRESS_BOX,
                ServiceType = PurolatorServiceType.EXPRESS_BOX,
                SenderPostalCode = ParameterService.GetValue("PurolatorSenderPostalCode"),
                ShippingType = ShippingType.Purolator,
                WeightType = ShippingParameter.WeightTypes.Lbs,
                AccountId = ParameterService.GetValue("PurolatorBillingAccount"),
                Login = ParameterService.GetValue("PurolatorUserName"),
                Password = ParameterService.GetValue("PurolatorPassword"),
                Url = ParameterService.GetValue("PurolatorWebServiceUrl")
            };


            PurolatorPackage purolatorPackage = new PurolatorPackage
            {
                TotalWeight = (int)commande.TotalWeight,
                SenderPostalCode = shippingParameter.SenderPostalCode,
                PackageType = shippingParameter.PackageType,
                BillingAccountNumer = shippingParameter.BillingAccount,
                ReceiverPostalCode = commande.ShippingAddress.PostalCode,
                CountryReceiverCode = shippingParameter.CountryReceiverCode
            };


            switch (shippingParameter.WeightType)
            {
                case ShippingParameter.WeightTypes.Kg:
                    purolatorPackage.WeightUnit = WeightUnit.kg;
                    break;
                case ShippingParameter.WeightTypes.Lbs:
                    purolatorPackage.WeightUnit = WeightUnit.lb;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ConfigurationPurolatorWebService configurationPurolatorWebService = new ConfigurationPurolatorWebService
            {
                AccountId =
                    shippingParameter.AccountId,
                Login = shippingParameter.Login,
                Password =
                    shippingParameter.Password,
                Url = shippingParameter.Url
            };


            try
            {
                IList<PurolatorEstimateReturn> purolatorEstimateReturns = PurolatorService.GetQuickEstimate(purolatorPackage, configurationPurolatorWebService);
                if (purolatorEstimateReturns != null)
                {
                    total =
                        purolatorEstimateReturns.Where(x => x.ServiceId == shippingParameter.ServiceType).ToList()[0]
                            .TotalPrice;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().IndexOf("mandatory") <= 0)
                {
                    MessageService.ThrowMessage(ErrorCode.SC_PUROLATOR_ERROR, ex);
                }
            }

            return total;
        }

        public bool EstCodePostalValideAvecPurolator(string codePostal)
        {
            ShippingParameter shippingParameter = new ShippingParameter
            {
                BillingAccount = "99999999",
                CountryReceiverCode = ParameterService.GetValue("CountryReceiverCode"),
                PackageType = PurolatorPackageType.EXPRESS_BOX,
                ServiceType = PurolatorServiceType.EXPRESS_BOX,
                SenderPostalCode = ParameterService.GetValue("SenderPostalCode"),
                ShippingType = ShippingType.Purolator,
                WeightType = ShippingParameter.WeightTypes.Lbs,
                AccountId = ParameterService.GetValue("PurolatorBillingAccount"),
                Login = ParameterService.GetValue("PurolatorUserName"),
                Password = ParameterService.GetValue("PurolatorPassword"),
                Url = ParameterService.GetValue("PurolatorWebServiceUrl")
            };


            PurolatorPackage purolatorPackage = new PurolatorPackage
            {
                TotalWeight = 1,
                SenderPostalCode = shippingParameter.SenderPostalCode,
                PackageType = shippingParameter.PackageType,
                BillingAccountNumer = shippingParameter.BillingAccount,
                ReceiverPostalCode = codePostal,
                CountryReceiverCode = shippingParameter.CountryReceiverCode
            };


            switch (shippingParameter.WeightType)
            {
                case ShippingParameter.WeightTypes.Kg:
                    purolatorPackage.WeightUnit = WeightUnit.kg;
                    break;
                case ShippingParameter.WeightTypes.Lbs:
                    purolatorPackage.WeightUnit = WeightUnit.lb;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ConfigurationPurolatorWebService configurationPurolatorWebService = new ConfigurationPurolatorWebService
            {
                AccountId =
                    shippingParameter.AccountId,
                Login = shippingParameter.Login,
                Password =
                    shippingParameter.Password,
                Url = shippingParameter.Url
            };

            IList<PurolatorEstimateReturn> purolatorEstimateReturns = PurolatorService.GetQuickEstimate(purolatorPackage, configurationPurolatorWebService);
            foreach (PurolatorEstimateReturn purolatorEstimateReturn in purolatorEstimateReturns)
            {
                if (purolatorEstimateReturn.FailMessage != null && purolatorEstimateReturn.FailMessage.IndexOf("1100594") >= 0)
                    return false;
            }
            return true;
        }
    }
}

