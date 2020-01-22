using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    class DataBlock
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public DataPoint[] data { get; set; }

    }
}
