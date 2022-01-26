using System.Threading.Tasks;
using NUnit.Framework;

namespace Weatherapi.com;

public class Tests
{
    [Test]
    public async Task TemperatureMoreTwentyTest()
    {
        var helper = new Helper();
        await helper.CurrentWeather();
    }

    [Test]
    public async Task AverageTemperatureTest()
    {
        var helper = new Helper();
        await helper.AverageTemperature();
    }

    [Test]
    public async Task SearchMinskTest()
    {
        var helper = new Helper();
        await helper.SearchMinsk();
    }

    [Test]
    public async Task AstronomySunriseTest()
    {
        var helper = new Helper();
        await helper.Sunrice();
    }

    [Test]
    public async Task TimeZoneTest()
    {
        var helper = new Helper();
        await helper.TimeZone();
    }

    [Test]
    public async Task SportsTest()
    {
        var helper = new Helper();
        await helper.Sports();
    }
}
