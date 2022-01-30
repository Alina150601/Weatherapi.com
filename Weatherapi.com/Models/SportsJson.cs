using System.Collections.Generic;

namespace Weatherapi.com.Models;

public class SportsJson
{
    public List<Football> football { get; set; }
    public List<Cricket> cricket { get; set; }
    public List<object> golf { get; set; }
}
