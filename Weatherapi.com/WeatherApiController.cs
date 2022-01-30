using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weatherapi.com.Models;

namespace Weatherapi.com;

public class WeatherApiController
{
    private readonly HttpClient _client;

    public WeatherApiController()
    {
        _client = new HttpClient();
       _client.Timeout = TimeSpan.FromSeconds(15);
    }

    public async Task<CurrentJson> GetCurrentJsonAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            { "key", "ef805c60dbc742c886293118222101" },
            { "q", "Minsk" },
            { "aqi", "no" }
        };
        var json = await PostAsync("http://api.weatherapi.com/v1/current.json", parameters);
        return JsonConvert.DeserializeObject<CurrentJson>(json);
    }

    public async Task<ForecastJson> GetForecastJsonAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            { "key", "ef805c60dbc742c886293118222101" },
            { "q", "Minsk" },
            { "days", "1" },
            { "aqi", "no" },
            { "alerts", "no" }
        };
        var json = await PostAsync("http://api.weatherapi.com/v1/forecast.json", parameters);
        return JsonConvert.DeserializeObject<ForecastJson>(json);
    }

    public async Task<SearchJson[]> GetSearchJsonAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            { "key", "ef805c60dbc742c886293118222101" },
            { "q", "Minsk" }
        };

        var json = await PostAsync("http://api.weatherapi.com/v1/search.json", parameters);

        return JsonConvert.DeserializeObject<SearchJson[]>(json);
    }

    public async Task<AstronomyJson> GetAstronomyJsonAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            { "key", "ef805c60dbc742c886293118222101" },
            { "q", "Minsk" },
            { "dt", "2022-01-21" }
        };

        var json = await PostAsync("http://api.weatherapi.com/v1/astronomy.json", parameters);
        return JsonConvert.DeserializeObject<AstronomyJson>(json);
    }

    public async Task<TimezoneJson> GetTimezoneJsonAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            { "key", "ef805c60dbc742c886293118222101" },
            { "q", "Minsk" }
        };

        var json = await PostAsync("http://api.weatherapi.com/v1/timezone.json", parameters);
        return JsonConvert.DeserializeObject<TimezoneJson>(json);
    }

    public async Task<SportsJson> GetSportsJsonAsync()
    {
        var parameters = new Dictionary<string, string>
        {
            { "key", "ef805c60dbc742c886293118222101" },
            { "q", "Minsk" }
        };

        var json = await PostAsync("http://api.weatherapi.com/v1/sports.json", parameters);
        return JsonConvert.DeserializeObject<SportsJson>(json);
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
