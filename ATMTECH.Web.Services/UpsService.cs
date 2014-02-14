using System;
using System.IO;
using System.Net;
using ATMTECH.Common;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class UpsService : BaseService, IUpsService
    {
        public IMessageService MessageService { get; set; }

        public enum CountryCode
        {
            CA = 0,
            US = 1,
            FR = 2,
            GB = 3,
            DE = 4,
            ES = 5,
            MX = 6,
            IND = 7,
            JP = 8,
            CN = 9,
            LV = 10,
            IL = 11,
            AU = 12
        }

        public enum PickupType
        {
            DailyPickup = 1,
            CustomerCounter = 3,
            OneTimePickup = 6,
            OnCallAirPickup = 7,
            SuggestedRetailRates = 11,
            LetterCenter = 19,
            AirServiceCenter = 20
        }

        public enum PackageType
        {
            UpsLetter = 1,
            Package = 2,
            UpsTube = 3,
            UpsPak = 4,
            UpsExpressBox = 21,
            Ups25KgBox = 24,
            Ups10KgBox = 25
        }

        public enum WeightType
        {
            LBS = 0,
            KGS = 1
        }


        public enum ServiceCode
        {

            UpsNextDayAir = 1,
            UpsGround = 3,
            UpsStandard = 11,
            UpsWorldwideExpress = 7,
            UpsWorldWidExpedited = 8,
            UpsSaver = 65,
            UpsWorldwidePlus = 54
        }

        private string BuildXml(UpsDto upsDto)
        {
            string xml = "";
            xml += "<?xml version='1.0'?><AccessRequest xml:lang='en-US'><AccessLicenseNumber>" + upsDto.AccessLicenceNumber + "</AccessLicenseNumber><UserId>" + upsDto.UserId + "</UserId><Password>" + upsDto.Password + "</Password></AccessRequest>";
            xml += "<?xml version='1.0'?><RatingServiceSelectionRequest xml:lang='en-US'><Request><TransactionReference>";
            xml += "<CustomerContext>Rating and Service</CustomerContext><XpciVersion>1.0001</XpciVersion>";
            xml += "</TransactionReference><RequestAction>Rate</RequestAction><RequestOption>shop</RequestOption>";
            xml += "</Request><PickupType><Code>06</Code></PickupType><Shipment><Shipper><Address><PostalCode>" + upsDto.ShipperPostalCode + "</PostalCode>";
            xml += "<CountryCode>CA</CountryCode></Address></Shipper><ShipTo><Address><PostalCode>" + upsDto.ShippingPostalCode + "</PostalCode><CountryCode>" + upsDto.ShippingCountryCode + "</CountryCode>";
            xml += "<ResidentialAddressIndicator/></Address></ShipTo><Service><Code>" + upsDto.ShippingServiceCode.PadLeft(2, (char)48) + "</Code></Service><Package><PackagingType><Code>" + upsDto.PackageType.PadLeft(2, (char)48) + "</Code>";
            xml += "<Description>Package</Description></PackagingType><PackageWeight><UnitOfMeasurement><Code>" + upsDto.WeightType.ToUpper() + "</Code></UnitOfMeasurement><Weight>" + upsDto.Weight + "</Weight></PackageWeight>";
            xml += "</Package></Shipment></RatingServiceSelectionRequest>";
            return xml;
        }
        public double GetShippingRate(UpsDto upsDto)
        {
            System.Xml.XmlDocument xmlResponse = new System.Xml.XmlDocument();
            double result = 0;
            const string url = "https://www.ups.com/ups.app/xml/Rate";

            HttpWebRequest upsRequest = (HttpWebRequest)WebRequest.Create(url);
            upsRequest.AllowAutoRedirect = false;
            upsRequest.Method = "POST";
            upsRequest.ContentType = "application/x-www-form-urlencoded";
            upsRequest.Accept = "True";
            upsRequest.Timeout = 50000;

            Stream requestStream = upsRequest.GetRequestStream();
            byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(BuildXml(upsDto));

            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            try
            {
                HttpWebResponse upsResponse = (HttpWebResponse)upsRequest.GetResponse();
                xmlResponse.Load(upsResponse.GetResponseStream());
                if (xmlResponse.DocumentElement.FirstChild.InnerText == "Rating and Service1.00011Success")
                {

                    System.Xml.XmlNodeList lNodes = xmlResponse.SelectNodes("/RatingServiceSelectionResponse/RatedShipment");
                    foreach (System.Xml.XmlNode lNode in lNodes)
                    {
                        if (lNode.SelectSingleNode("Service/Code").InnerText == upsDto.ShippingServiceCode.PadLeft(2, (char)48))
                        {
                            var selectSingleNode = lNode.SelectSingleNode("TransportationCharges/MonetaryValue");
                            if (selectSingleNode != null)
                                result = Convert.ToDouble(selectSingleNode.InnerText.Replace(".", ","));
                        }
                    }
                }
                else if (xmlResponse.DocumentElement.FirstChild.InnerText.Length > 36)
                {
                    if (xmlResponse.DocumentElement.FirstChild.InnerText.Substring(0, 36) == "Rating and Service1.00010FailureHard")
                    {
                        throw new System.Exception(xmlResponse.SelectSingleNode("/RatingServiceSelectionResponse/Response/Error/ErrorDescription").InnerText);
                    }
                }
                else
                {
                    MessageService.ThrowMessage(Common.ErrorCode.ADM_UPS_ERROR);

                }
            }
            catch (ProtocolViolationException ex)
            {
                MessageService.ThrowMessage(Common.ErrorCode.ADM_UPS_TIMEOUT_ERROR, ex);
            }
            catch (WebException ex)
            {
                MessageService.ThrowMessage(Common.ErrorCode.ADM_UPS_EMPTY_ERROR, ex);
            }
            catch (System.Exception ex)
            {
                MessageService.ThrowMessage(Common.ErrorCode.ADM_UPS_ERROR, ex);
            }

            return result;
        }
    }

    public class UpsDto
    {
        public string AccessLicenceNumber { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShipperPostalCode { get; set; }
        public string ShippingCountryCode { get; set; }
        public int Weight { get; set; }
        public string ShippingServiceCode { get; set; }
        public string PackageType { get; set; }
        public string WeightType { get; set; }
    }

}
