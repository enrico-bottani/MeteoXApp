using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MeteoApp.Models
{
    [Table("Items")]
    public class Location
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public String Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Location(String name, float latitude, float longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
        public Location()
        {
            Name = "Nowhere";
            Latitude = 0.0;
            Longitude = 0.0;
        }
    }
}
