using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    class Location
    {
        public string name { get; set; }
        public string country { get; set; }
        public Coordinates coordinates { get; set; }
    }
}
