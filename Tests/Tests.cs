using System.Threading.Tasks;
using NUnit.Framework;

namespace Weatherapi.com.Tests;

public class Tests
{
    [Test]
    public async Task TemperatureMoreTwentyTest()
    {
        var data = await WeatherForecast.LoadWeatherDataAsync();
        Assert.IsTrue(data.CurrentTemperature > -20);
    }

    [Test]
    public async Task AverageTemperatureTest()
    {
        var data = await WeatherForecast.LoadWeatherDataAsync();
        Assert.IsTrue(data.AvgTemperature > -20);
    }

    [Test]
    public async Task SearchMinskTest()
    {
        var data = await WeatherForecast.LoadWeatherDataAsync();
        Assert.IsTrue(data.Region == "Minsk");
    }

    [Test]
    public async Task AstronomySunriseTest()
    {
        var data = await WeatherForecast.LoadWeatherDataAsync();
        Assert.IsTrue(data.Sunrise == "09:06 AM");
    }

    [Test]
    public async Task TimeZoneTest()
    {
        var data = await WeatherForecast.LoadWeatherDataAsync();
        Assert.IsTrue(data.TzId  == "Europe/Minsk");
    }

    [Test]
    public async Task SportsTest()
    {
        var data = await WeatherForecast.LoadWeatherDataAsync();
        Assert.IsTrue(data.Football != null);
    }
}
