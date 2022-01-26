using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weatherapi.com;

public class WeatherForecast
{
    private readonly HttpClient _client = new()
    {
        Timeout = TimeSpan.FromSeconds(15)
    };

    public double CurrentTemperature { get; set; }
    public double AvgTemperature { get; set; }
    public string? Region { get; set; }
    public string? Sunrise { get; set; }
    public string? TzId { get; set; }
    public string Football { get; set; }

    private WeatherForecast()
    {
    }

    public static async Task<WeatherForecast> LoadWeatherDataAsync()
    {
        var instance = new WeatherForecast();
        await instance.SetCurrentTemperatureAsync();
        await instance.SetAvgTemperatureAsync();
        await instance.SetRegionAsync();
        await instance.SetSunriseAsync();
        await instance.SetTzIdAsync();
        await instance.SetFootballAsync();

        return instance;
    }

    private async Task SetCurrentTemperatureAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            {"key", "ef805c60dbc742c886293118222101"},
            {"q", "Minsk"},
            {"aqi", "no"}
        };
        var JSON = await PostAsync("http://api.weatherapi.com/v1/current.json", parameters);
        var jsonDoc = JsonDocument.Parse(JSON);
        CurrentTemperature = jsonDoc.RootElement.GetProperty("current").GetProperty("temp_c").GetDouble();
    }

    private async Task SetAvgTemperatureAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            {"key", "ef805c60dbc742c886293118222101"},
            {"q", "Minsk"},
            {"days", "1"},
            {"aqi", "no"},
            {"alerts", "no"}
        };
        var JSON = await PostAsync("http://api.weatherapi.com/v1/forecast.json", parameters);
        var jsonDoc = JsonDocument.Parse(JSON);
        AvgTemperature = jsonDoc.RootElement.GetProperty("forecast").GetProperty("forecastday").EnumerateArray().First()
            .GetProperty("day").GetProperty("avgtemp_c").GetDouble();
    }

    private async Task SetRegionAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            {"key", "ef805c60dbc742c886293118222101"},
            {"q", "Minsk"}
        };

        var JSON = await PostAsync("http://api.weatherapi.com/v1/search.json", parameters);
        var jsonDoc = JsonDocument.Parse(JSON);
        Region = jsonDoc.RootElement.EnumerateArray().First().GetProperty("name").GetString();
    }

    private async Task SetSunriseAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            {"key", "ef805c60dbc742c886293118222101"},
            {"q", "Minsk"},
            {"dt", "2022-01-21"}
        };

        var JSON = await PostAsync("http://api.weatherapi.com/v1/astronomy.json", parameters);
        var jsonDoc = JsonDocument.Parse(JSON);
        Sunrise = jsonDoc.RootElement.GetProperty("astronomy").GetProperty("astro").GetProperty("sunrise").GetString();
    }

    private async Task SetTzIdAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            {"key", "ef805c60dbc742c886293118222101"},
            {"q", "Minsk"}
        };

        var JSON = await PostAsync("http://api.weatherapi.com/v1/timezone.json", parameters);
        var jsonDoc = JsonDocument.Parse(JSON);
        TzId = jsonDoc.RootElement.GetProperty("location").GetProperty("tz_id").GetString();
    }

    private async Task SetFootballAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            {"key", "ef805c60dbc742c886293118222101"},
            {"q", "Minsk"}
        };

        var JSON = await PostAsync("http://api.weatherapi.com/v1/sports.json", parameters);
        var jsonDoc = JsonDocument.Parse(JSON);
        Football = jsonDoc.RootElement.GetProperty("football").ToString();
    }

    private async Task<string> PostAsync(string url, Dictionary<string, string> parameters)
    {
        var content = new FormUrlEncodedContent(parameters);

        var response = await _client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
        var resultJson = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(resultJson);

        return resultJson;
    }
}