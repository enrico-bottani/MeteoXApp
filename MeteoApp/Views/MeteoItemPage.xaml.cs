
using System;
using System.Net.Http;
using MeteoApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        public MeteoItemPage()
        {
            InitializeComponent();
                urlRequest("Balerna,ch");
                
           
        }
        public async void urlRequest(String place) {
            var httpClient = new HttpClient();
            String APIKEY = "afd1e112193ba1e61ad067c236a0a590";
            String baseRequest = "api.openweathermap.org/data/2.5/weather?q=";
            String request = "https://"+baseRequest+place+ "&units=metric&appid=" + APIKEY;
            Console.WriteLine(request);
            String jsonResponse = await httpClient.GetStringAsync(request);
            OpenWeatherRoot responseRoot = JsonConvert.DeserializeObject<OpenWeatherRoot>(jsonResponse);
            Console.WriteLine("Weather: " +responseRoot.weather[0].main+" Temp-min:"+responseRoot.main.temp_min);
        }
    }
}