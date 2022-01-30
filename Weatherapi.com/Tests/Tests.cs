using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Weatherapi.com.Tests;

public class Tests
{
    private WeatherApiController _weatherApiController;

    [OneTimeSetUp]
    public void WeatherForecast()
    {
        _weatherApiController = new WeatherApiController();
    }

    [Test]
    public async Task CurrentTemperatureTest()
    {
        var currentTemperatureJson = await _weatherApiController.GetCurrentJsonAsync();
        Assert.IsTrue(currentTemperatureJson.current.temp_c > -20);
    }

    [Test]
    public async Task AverageTemperatureTest()
    {
        var currentForecastJson = await _weatherApiController.GetForecastJsonAsync();
        Assert.IsTrue(currentForecastJson.forecast.forecastday.First().day.avgtemp_c > -20);
    }

    [Test]
    public async Task SearchMinskTest()
    {
        var currentForecastJson = await _weatherApiController.GetSearchJsonAsync();
        Assert.IsTrue(currentForecastJson.Any(x=>x.region.Equals("Minsk")));
    }

    [Test]
    public async Task AstronomySunriseTest()
    {
        var currentForecastJson = await _weatherApiController.GetAstronomyJsonAsync();
        Assert.IsTrue(currentForecastJson.Astronomy.astro.sunrise == "09:06 AM");
    }

    [Test]
    public async Task  TimeZoneTest()
    {
        var currentForecastJson = await _weatherApiController.GetTimezoneJsonAsync();
        Assert.IsTrue(currentForecastJson.location.tz_id  == "Europe/Minsk");
    }

    [Test]
    public async Task SportsTest()
    {
        var currentForecastJson = await _weatherApiController.GetSportsJsonAsync();
        Assert.IsTrue(currentForecastJson.football != null);
    }
}
