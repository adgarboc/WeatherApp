using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.Converters
{
    public class Degrees : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value.Length == 2)
                {
                    var farenheit = value[0] is double ? (double)value[0] : 0;
                    var isFarenheit = value[1] is bool && (bool)value[1];
                    var celsius = (farenheit - 32) / 1.8;
                    return isFarenheit ? farenheit.ToString("N2") : celsius.ToString("N2");
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
