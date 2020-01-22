using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class MainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private String _sample;
        public String Sample
        {
            get { return _sample; }
            set
            {
                _sample = value;
                OnPropertyChanged("Sample");
            }
        }
    }
}
