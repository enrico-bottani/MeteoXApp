using System;

namespace MeteoApp
{
    public class Entry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        private double lat,lon;
        private bool hasLatLong = false;
        public bool HasLatLong
        {
            get { return hasLatLong; }
        }

        public double Lat {get { return lat; }
            set {
                lat = value;
                hasLatLong = true;
        } 
        }
        public double Lon
        {
            get { return lon; }
            set
            {
                lon = value;
                hasLatLong = true;
            }
        }
    }
}