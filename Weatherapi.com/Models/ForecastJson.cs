namespace Weatherapi.com.Models;

public class ForecastJson
{
    public Location location { get; set; }
    public Current current { get; set; }
    public Forecast forecast { get; set; }
}
