using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Common;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class Weather : ObservableObject
    {
        private Uri _imageSource;
        public Uri ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        private Model.Weather _city;
        public Model.Weather City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
                GetCurrent();
            }
        }

        private bool _isFarenheit;
        public bool IsFarenheit
        {
            get { return _isFarenheit; }
            set
            {
                _isFarenheit = value;
                OnPropertyChanged("IsFarenheit");
            }
        }

        private DataPoint _currentWeather;
        public DataPoint CurrentWeather
        {
            get { return _currentWeather; }
            set
            {
                _currentWeather = value;
                OnPropertyChanged("CurrentWeather");
            }
        }

        private void GetCurrent()
        {
            if (City != null && City.currently != null)
            {
                CurrentWeather = City.currently;
                var png = String.Format(@"{0}Resources{1}.png",
                    Environment.CurrentDirectory, CurrentWeather.icon);
                ImageSource = new FileInfo(png).Exists
                    ? ImageSource = new Uri(png, UriKind.RelativeOrAbsolute)
                    : null;
            }
            else
            {
                ImageSource = null;
            }
        }
    }
}
