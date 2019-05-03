using MeteoApp.Models;
using MeteoApp.Models.OpenWeatherClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MeteoApp.ViewModels
{
    class MeteoItemViewModel : BaseViewModel
    {
        Entry _entry;

        String _weatherMainDesc = "Loading...";
        OWMain _owMain;

        public Entry Entry {
            get { return _entry; }
            set { _entry = value;
                OnPropertyChanged();
            }
        }
        public OWMain OWMain{
            get {
                if (_owMain == null) {
 
                    return new OWMain(); }
      
                return _owMain; 
                }
            set
            {
                _owMain = value;
                OnPropertyChanged();
            }
        }
        String ToUpperFirstLetter(String source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }

        public String WeatherMainDesc
        {
            get { return _weatherMainDesc; }
            set
            {
                _weatherMainDesc = ToUpperFirstLetter(value);

                OnPropertyChanged();
            }
        }

        public MeteoItemViewModel(Entry entry)
        {
            Entry = entry;
            urlRequest(entry.Name);
        }
        public async void urlRequest(String place)
        {
            var httpClient = new HttpClient();
            String APIKEY = "afd1e112193ba1e61ad067c236a0a590";
            String baseRequest = "api.openweathermap.org/data/2.5/weather?q=";
            String request = "https://" + baseRequest + place + "&units=metric&lang=it&appid=" + APIKEY;
            Console.WriteLine(request);
            String jsonResponse = await httpClient.GetStringAsync(request);
            OpenWeatherRoot openWeatherRoot = JsonConvert.DeserializeObject<OpenWeatherRoot>(jsonResponse);
            WeatherMainDesc = openWeatherRoot.weather[0].description;
            OWMain = openWeatherRoot.main;
        }
    }
}
