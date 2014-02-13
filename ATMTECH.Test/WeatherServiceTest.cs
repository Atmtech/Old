using ATMTECH.Entities;
using ATMTECH.Shell.Tests;
using ATMTECH.Web.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Test
{
    [TestClass]
    public class WeatherServiceTest : BaseTest<WeatherService>
    {
        [TestMethod]
        public void GetWeather_ShouldNotBeNull()
        {
            Weather weather = InstanceTest.GetWeather("Quebec, Que", "Canada");
            weather.Should().NotBeNull();
        }

        [TestMethod]
        public void GetWeather_AllProperty_ShouldNotBeNull()
        {
            Weather weather = InstanceTest.GetWeather("Quebec, Que", "Canada");
            weather.Pressure.Should().NotBeNull();
            weather.SkyConditions.Should().NotBeNull();
            weather.Wind.Should().NotBeNull();
            weather.Temperature.Should().NotBeNull();
        }
    }
}
