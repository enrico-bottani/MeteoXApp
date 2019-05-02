using System;
using MeteoApp.Models.OpenWeatherClasses;

namespace MeteoApp.Models
{
    public class OpenWeatherRoot
    {
        public Coord coord;
        public OWMain main;
        public Weather[] weather;
        public OpenWeatherRoot()
        {
        }
    }
}
