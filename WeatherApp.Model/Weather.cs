using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Weather
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public String timeZone { get; set; }
        public int offset { get; set; }
        public DataPoint currently { get; set; }
        public DataBlock minutely { get; set; }
        public DataBlock hourly { get; set; }
        public DataBlock dayly { get; set; }
        public object[] alerts { get; set; }
        public object flags { get; set; }
    }
}
