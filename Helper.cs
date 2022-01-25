using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Weatherapi.com;

public class Helper
{
    public async Task CurrentWeather()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var parameters = new Dictionary<string, string>();
        parameters.Add("key", "ef805c60dbc742c886293118222101");
        parameters.Add("q", "Minsk");
        parameters.Add("aqi", "no");
        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync("http://api.weatherapi.com/v1/current.json", content);
        response.EnsureSuccessStatusCode();
        var result = response.Content.ReadAsStringAsync().Result;

        dynamic data = JObject.Parse(result);
        var intTemperature = int.Parse(data["current"]["temp_c"].ToString());
        Console.WriteLine(intTemperature);
        Assert.IsTrue(intTemperature > -20);
    }

    public async Task AverageTemperature()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var parameters = new Dictionary<string, string>();
        parameters.Add("key", "ef805c60dbc742c886293118222101");
        parameters.Add("q", "Minsk");
        parameters.Add("days", "1");
        parameters.Add("aqi", "no");
        parameters.Add("alerts", "no");
        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync("http://api.weatherapi.com/v1/forecast.json", content);
        response.EnsureSuccessStatusCode();
        var result = response.Content.ReadAsStringAsync().Result;

        var jsonDoc = JsonDocument.Parse(result);
        var avgTemperature = jsonDoc
            .RootElement
            .GetProperty("forecast")
            .GetProperty("forecastday")
            .EnumerateArray()
            .First()
            .GetProperty("day")
            .GetProperty("avgtemp_c")
            .GetDouble();
        Console.WriteLine(avgTemperature);
        Assert.IsTrue(avgTemperature > -20);
    }

    public async Task SearchMinsk()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var parameters = new Dictionary<string, string>();
        parameters.Add("key", "ef805c60dbc742c886293118222101");
        parameters.Add("q", "Minsk");
        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync("http://api.weatherapi.com/v1/search.json", content);
        response.EnsureSuccessStatusCode();
        var result = response.Content.ReadAsStringAsync().Result;

        var jsonDoc = JsonDocument.Parse(result);

        var region = jsonDoc
            .RootElement
            .EnumerateArray()
            .First()
            .GetProperty("name")
            .GetString();
        Console.WriteLine(region);
        Assert.IsTrue(region == "Minsk");


    }

    public async Task Sunrice()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var parameters = new Dictionary<string, string>();
        parameters.Add("key", "ef805c60dbc742c886293118222101");
        parameters.Add("q", "Minsk");
        parameters.Add("dt", "2022-01-21");
        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync("http://api.weatherapi.com/v1/astronomy.json", content);
        response.EnsureSuccessStatusCode();
        var result = response.Content.ReadAsStringAsync().Result;

        var jsonDoc = JsonDocument.Parse(result);
        var sunrise = jsonDoc
            .RootElement
            .GetProperty("astronomy")
            .GetProperty("astro")
            .GetProperty("sunrise")
            .GetString();
        Console.WriteLine(sunrise);
        Assert.IsTrue(sunrise == "09:08 AM");
    }

    public async Task TimeZone()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var parameters = new Dictionary<string, string>();
        parameters.Add("key", "ef805c60dbc742c886293118222101");
        parameters.Add("q", "Minsk");
        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync("http://api.weatherapi.com/v1/timezone.json", content);
        response.EnsureSuccessStatusCode();
        var result = response.Content.ReadAsStringAsync().Result;

        var jsonDoc = JsonDocument.Parse(result);
        var tz_id = jsonDoc
            .RootElement
            .GetProperty("location")
            .GetProperty("tz_id")
            .GetString();
        Console.WriteLine(tz_id);
        Assert.IsTrue(tz_id == "Europe/Minsk");
    }

    public async Task Sports()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(15);

        var parameters = new Dictionary<string, string>();
        parameters.Add("key", "ef805c60dbc742c886293118222101");
        parameters.Add("q", "Minsk");
        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync("http://api.weatherapi.com/v1/sports.json", content);
        response.EnsureSuccessStatusCode();
        var result = response.Content.ReadAsStringAsync().Result;

        var jsonDoc = JsonDocument.Parse(result);
        var tz_id = jsonDoc
            .RootElement
            .GetProperty("football")
            .ToString();
        Console.WriteLine(tz_id);
        Assert.IsTrue(tz_id != null);
    }
}
