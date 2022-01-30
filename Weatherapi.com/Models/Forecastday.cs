using System.Collections.Generic;

namespace Weatherapi.com.Models;

public class Forecastday
{
    public string date { get; set; }
    public int date_epoch { get; set; }
    public Day day { get; set; }
    public Astro astro { get; set; }
    public List<Hour> hour { get; set; }
}
