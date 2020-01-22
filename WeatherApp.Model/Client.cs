using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherApp.Model
{
    public static class Client
    {
        private static readonly CultureInfo culture = new CultureInfo("EN-US");
        public static List<Location> GetLocations(string query, int maxResults = 20)
        {
            if (String.IsNullOrEmpty(query) ||
                !(maxResults > 0 && maxResults <= 20)) return null;

            var url = String.Format(Properties.Resources.UrlBing,
                                    query,
                                    maxResults,
                                    Properties.Resources.KeyBing);

            List<Location> list;
            try
            {
                var doc = XDocument.Load(url);
                var locs = from q in doc.Descendants()
                            .Where(q => q.Name.LocalName == "Location")
                           select new
                           {
                               Name = q.Descendants()
                                  .Where(r => r.Name.LocalName == "Address")
                                  .Elements()
                                  .First(s => s.Name.LocalName == "Locality")
                                  .Value,
                               Country = q.Descendants()
                                  .Where(r => r.Name.LocalName == "Address")
                                  .Elements()
                                  .First(s => s.Name.LocalName == "CountryRegion")
                                  .Value,
                               Latitude = q.Descendants()
                                  .Where(r => r.Name.LocalName == "Point")
                                  .Elements()
                                  .First(s => s.Name.LocalName == "Latitude")
                                  .Value,
                               Longitude = q.Descendants()
                                  .Where(r => r.Name.LocalName == "Point")
                                  .Elements()
                                  .First(s => s.Name.LocalName == "Longitude")
                                  .Value,
                           };

                list = locs.Select(q => new Location
                {
                    name = q.Name,
                    country = q.Country,
                    coordinates = new Coordinates
                    {
                        latitude = Convert.ToDouble(q.Latitude, culture),
                        longitude = Convert.ToDouble(q.Longitude, culture)
                    }
                }).ToList();
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static Weather GetWeather(Coordinates coordinates)
        {
            if (coordinates == null) return null;

            var url = String.Format(Properties.Resources.UrlAPI,
                                    Properties.Resources.KeyAPI,
                                    coordinates.latitude.ToString(culture),
                                    coordinates.longitude.ToString(culture));
            Weather weather = null;
            try
            {
                var dser = new DataContractJsonSerializer(typeof(Weather));
                var req = WebRequest.Create(url);

                using (var s = req.GetResponse().GetResponseStream())
                {
                    if (s != null)
                    {
                        weather = (Weather)dser.ReadObject(s);
                    }
                }
            }
            catch (Exception)
            {
                weather = null;
            }
            return weather;
        }
    }
}
