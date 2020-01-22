using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public static class Client
    {
        private static readonly CultureInfo culture = new CultureInfo("EN-US");
        public static List<Location> GetLocations(string query, int maxResults = 20)
        {
            return null;
        }
        public static Weather GetWeather(Coordinates coordinates)
        {
            return null;
        }
    }
}
