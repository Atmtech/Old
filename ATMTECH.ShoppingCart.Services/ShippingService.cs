using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;
using ATMTECH.Web.Services.PurolatorEstimatingProxy;

namespace ATMTECH.ShoppingCart.Services
{
    public class ShippingService : BaseService, IShippingService
    {
        public IPurolatorService PurolatorService { get; set; }
        public IMessageService MessageService { get; set; }
        public IUpsService UpsService { get; set; }
        public IParameterService ParameterService { get; set; }

        private decimal GetShippingTotalUps(Order order, ShippingParameter shippingParameter)
        {

            UpsDto upsDto = new UpsDto
                              {
                                  AccessLicenceNumber = shippingParameter.AccountId,
                                  UserId = shippingParameter.Login,
                                  Password = shippingParameter.Password,
                                  ShipperPostalCode = shippingParameter.SenderPostalCode,
                                  WeightType = shippingParameter.WeightType.ToString(),
                                  Weight = (int)order.TotalWeight,
                                  PackageType = shippingParameter.PackageType,
                                  ShippingServiceCode = shippingParameter.ServiceCode,
                                  ShippingCountryCode = order.ShippingAddress.Country.Iso,
                                  ShippingPostalCode = order.ShippingAddress.PostalCode
                              };

            return Convert.ToDecimal(UpsService.GetShippingRate(upsDto));
        }

        private decimal GetShippingTotalPurolator(Order order, ShippingParameter shippingParameter)
        {
            decimal total = 0;
            if ((int)order.TotalWeight == 0)
            {
                MessageService.ThrowMessage(ErrorCode.SC_WEIGHT_EQUAL_ZERO_CANNOT_EVALUATE_SHIPPING_COST);
            }
            PurolatorPackage purolatorPackage = new PurolatorPackage
                                                    {
                                                        TotalWeight = (int)order.TotalWeight,
                                                        SenderPostalCode = shippingParameter.SenderPostalCode,
                                                        PackageType = shippingParameter.PackageType,
                                                        BillingAccountNumer = shippingParameter.BillingAccount,
                                                        ReceiverPostalCode = order.ShippingAddress.PostalCode,
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
            catch (System.Exception ex)
            {
                MessageService.ThrowMessage(ErrorCode.SC_PUROLATOR_ERROR, ex);
            }

            return total;
        }

        public decimal GetShippingTotal(Order order, ShippingParameter shippingParameter)
        {
            if (ParameterService.GetValue("Environment") != "PROD")
            {
                return 0;
            }

            if (order == null)
            {
                MessageService.ThrowMessage(ErrorCode.SC_ORDER_NULL);
            }

            if (shippingParameter == null)
            {
                return 0;
            }

            if (order.OrderLines.Count == 0 || order.OrderLines.Count(x => x.IsActive) == 0)
            {
                return 0;
            }

            if ((int)order.TotalWeight == 0)
            {
                order.TotalWeight = 10;
            }

            switch (shippingParameter.ShippingType)
            {
                case ShippingType.Ups:
                    return GetShippingTotalUps(order, shippingParameter);
                case ShippingType.Purolator:
                    return GetShippingTotalPurolator(order, shippingParameter);
                case ShippingType.Dhl:
                    break;
                case ShippingType.Dicom:
                    break;
                case ShippingType.CanadaPost:
                    break;
                case ShippingType.UsMail:
                    break;
                default:
                    MessageService.ThrowMessage(ErrorCode.SC_SHIPPING_CODE_DONT_EXIST);
                    break;
            }
            return 0;
        }



    }

    public class ShippingParameter
    {
        public enum WeightTypes
        {
            Kg = 0,
            Lbs = 1
        }

        public string SenderPostalCode { get; set; }
        public WeightTypes WeightType { get; set; }
        public ShippingType ShippingType { get; set; }
        public String PackageType { get; set; }
        public string ServiceType { get; set; }
        public string BillingAccount { get; set; }
        public string CountryReceiverCode { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AccountId { get; set; }
        public string ServiceCode { get; set; }
    }
}
