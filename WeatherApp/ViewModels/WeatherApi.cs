using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class WeatherApi
    {
        // Define the API key here
        // TODO figure out a better way to manage this data.
        public const string API_KEY = "";
        // The two placeholders allow me to properly specify the request data.
        public const string BASE_URL = "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}";

        public const string AUTOCOMPLETE_URL = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";

        public async Task<AccuWeather> GetWeatherInformationAsync(string cityName)
        {
            AccuWeather results = new AccuWeather();

            string url = string.Format(BASE_URL, cityName, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                // Need to extract it
                results = JsonConvert.DeserializeObject<AccuWeather>(json);
            }

            return results;
        }

        public async Task<List<LocationAutoComplete>> GetLocationAutoCompletesAsync(string query)
        {
            List<LocationAutoComplete> results = new List<LocationAutoComplete>();

            if (query == null)
            {
                query = string.Empty;
            }

            string url = string.Format(AUTOCOMPLETE_URL, API_KEY, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                // Need to extract it
                results = JsonConvert.DeserializeObject<List<LocationAutoComplete>>(json);
            }

            return results ?? new List<LocationAutoComplete>();
        }
    }
}
