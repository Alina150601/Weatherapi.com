using System.Threading.Tasks;
using NUnit.Framework;

namespace Weatherapi.com.Tests;

public class Tests
{
    private WeatherForecast _data;

    [OneTimeSetUp]
    public async Task LoadData()
    {
        _data = await WeatherForecast.LoadWeatherDataAsync();
    }

    [Test]
    public void TemperatureMoreTwentyTest()
    {
        Assert.IsTrue(_data.CurrentTemperature > -20);
    }

    [Test]
    public void AverageTemperatureTest()
    {
        Assert.IsTrue(_data.AvgTemperature > -20);
    }

    [Test]
    public void SearchMinskTest()
    {
        Assert.IsTrue(_data.Region == "Minsk");
    }

    [Test]
    public void AstronomySunriseTest()
    {
        Assert.IsTrue(_data.Sunrise == "09:06 AM");
    }

    [Test]
    public void TimeZoneTest()
    {
        Assert.IsTrue(_data.TzId  == "Europe/Minsk");
    }

    [Test]
    public void SportsTest()
    {
        Assert.IsTrue(_data.Football != null);
    }
}
