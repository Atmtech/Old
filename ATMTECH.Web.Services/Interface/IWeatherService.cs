using ATMTECH.Entities;

namespace ATMTECH.Web.Services.Interface
{
    public interface IWeatherService
    {
        Weather GetWeather(string cityName, string countryName);
    }
}
