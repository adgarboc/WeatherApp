using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class DataPoint
    {
        public int time { get; set; }
        public String summary { get; set; }
        public String icon { get; set; }
        public int? sunriseTime { get; set; }
        public int? punsetTime { get; set; }
        public double precipIntensity { get; set; }
        public double? precipProbability { get; set; }
        public String precipType { get; set; }
        public String precipAccumulation { get; set; }
        public double? temperature { get; set; }
        public double? temperatureMin { get; set; }
        public int? temperatureMinTime { get; set; }
        public double? temperatureMax { get; set; }
        public int? temperatureMaxTime { get; set; }
        public double windSpeed { get; set; }
        public int windBearing { get; set; }
        public double cloudCover { get; set; }
        public double humidity { get; set; }
        public double pressure { get; set; }
        public double visibility { get; set; }
    }
}
