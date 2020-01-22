using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp.Model;

namespace WeatherApp.Test
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void GetLocations()
        {
            var query = String.Empty;
            var maxResults = -1;
            var list = Client.GetLocations(query, maxResults);
            Assert.AreEqual(list, null);
            query = "Madrid";
            maxResults = new Random().Next(0, 20);
            list = Client.GetLocations(query, maxResults);
            Assert.IsTrue(list != null && list.Count >= 0);
        }

        [TestMethod]
        public void GetWeather()
        {
            var coords = new Coordinates
            {
                latitude = 0D,
                longitude = 0D
            };
            var weather = Client.GetWeather(null);
            Assert.IsNull(weather);
            weather = Client.GetWeather(coords);
            Assert.IsNotNull(weather);
        }
    }
}
