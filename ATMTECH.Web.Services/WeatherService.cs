using System.Data;
using System.IO;
using System.Xml;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.GlobalWeatherService;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class WeatherService : BaseService, IWeatherService
    {
        public Weather GetWeather(string cityName, string countryName)
        {
            GlobalWeatherService.GlobalWeatherSoapClient x = new GlobalWeatherSoapClient();
            string xml = x.GetWeather(cityName, countryName);
            DataSet ds = new DataSet();
            ds.ReadXml(new XmlTextReader(new StringReader(xml)));
            DataRow row = ds.Tables[0].Rows[0];
            Weather weather = new Weather { Pressure = row.ItemArray[8].ToString(), SkyConditions = row.ItemArray[4].ToString(), Temperature = row.ItemArray[5].ToString(), Wind = row.ItemArray[2].ToString() };
            return weather;
        }
    }
}
