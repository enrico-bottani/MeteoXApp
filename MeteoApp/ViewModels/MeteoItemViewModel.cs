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
                    Console.WriteLine("OWMain isNull");
                    return new OWMain(); }
                Console.WriteLine("OWMain is not null");
                return _owMain; 
                }
            set
            {
                Console.WriteLine("OWMain update: "+value.temp_min);
                _owMain = value;
                OnPropertyChanged();
            }
        }

        public String WeatherMainDesc
        {
            get { return _weatherMainDesc; }
            set
            {
                _weatherMainDesc = value;
                Console.WriteLine(value);
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
            String request = "https://" + baseRequest + place + "&units=metric&appid=" + APIKEY;
            Console.WriteLine(request);
            String jsonResponse = await httpClient.GetStringAsync(request);
            OpenWeatherRoot openWeatherRoot = JsonConvert.DeserializeObject<OpenWeatherRoot>(jsonResponse);
            WeatherMainDesc = openWeatherRoot.weather[0].main;
            OWMain = openWeatherRoot.main;
            Console.WriteLine("Weather: " + openWeatherRoot.weather[0].main + " Temp-min:" + openWeatherRoot.main.temp_min);
        }
    }
}
