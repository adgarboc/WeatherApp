using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.ViewModel;
using WeatherApp.Common;
using WeatherApp.Model;

namespace WheatherApp.ViewModel
{
    public class Search : ObservableObject
    {
        private const int MinLength = 3;

        public MainWindow Mw { get; set; }

        private String _textSearch;
        public String TextSearch
        {
            get { return _textSearch; }
            set
            {
                _textSearch = value;
                OnPropertyChanged("TextSearch");
            }
        }

        private List<Location> _locations;
        public List<Location> Locations
        {
            get 
            { 
                return _locations; 
            }
            set
            {
                _locations = value;
                OnPropertyChanged("Locations");
            }
        }

        private Location _location;
        public Location Location
        {    
            get 
            { 
                return _location; 
            }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
                Mw.GetWeather(value);
            }
        }
        private ICommand _searchIt;
        public ICommand SearchIt
        {
            get 
            { 
                return _searchIt ?? (_searchIt = new RelayCommand(param => GetSearch())); 
            }
        }
        private void GetSearch()
        {
            if (String.IsNullOrEmpty(TextSearch)) return;
            if (TextSearch.Length >= MinLength)
            {
                Locations = Client.GetLocations(TextSearch);
            }
        }
    }
}
