using System;
namespace MeteoApp.Models.OpenWeatherClasses
{
    public class OWMain
    {
        public double temp, pressure, humidity, temp_min, temp_max;
        public double TempMin { get {
                return temp_min;
        }
        }
        public double TempMax
        {
            get
            {
                return temp_max;
            }
        }
        public OWMain()
        {
        }
    }
}
