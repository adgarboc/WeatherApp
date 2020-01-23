using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.Common;
using WeatherApp.Components;
using System.Windows.Controls;

namespace WeatherApp.ViewModel
{
    public class MainWindow : ObservableObject
    {
        private bool _isSearchExpanded;
        public bool IsSearchExpanded
        {
            get { return _isSearchExpanded; }
            set
            {
                _isSearchExpanded = value;
                OnPropertyChanged("IsSearchExpanded");
            }
        }

        public Search Search { get; set; }

        public Frame Browser { get; set; }

        public void Init()
        {
            Search = new Search { Mw = this };
        }

        public void GetWeather(Location location)
        {
            if (location != null)
            {
                var city = Client.GetWeather(location.coordinates);
                var vm = new Weather { City = city, IsFarenheit = false };
                Browser.Navigate(new Components.Weather { DataContext = vm });
                IsSearchExpanded = false;
            }
        }
    }
}
