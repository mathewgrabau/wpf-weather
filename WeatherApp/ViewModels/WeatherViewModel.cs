using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    /// <summary>
    /// The 
    /// </summary>
    public class WeatherViewModel
    {
        public AccuWeather Weather { get; set; }

        private string _queryText;

        private WeatherApi _api = new WeatherApi();

        public WeatherViewModel()
        {
            Cities = new ObservableCollection<LocationAutoComplete>();
            SelectedLocation = new LocationAutoComplete();
        }

        public string QueryText
        {
            get { return _queryText; }
            set
            {
                _queryText = value;
                GetCities();
            }
        }

        public ObservableCollection<LocationAutoComplete> Cities { get; set; }

        private LocationAutoComplete _selectedLocation;

        public LocationAutoComplete SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
                GetWeather();
            }
        }


        private async void GetCities()
        {
            var cities = await _api.GetLocationAutoCompletesAsync(_queryText);

            Cities.Clear();
            foreach(var city in cities)
            {
                Cities.Add(city);
            }
        }

        private async void GetWeather()
        {
            var weather = await _api.GetWeatherInformationAsync(_selectedLocation.LocalizedName);
            if (weather != null)
            {
                Weather = weather;
            }
        }

    }
}
