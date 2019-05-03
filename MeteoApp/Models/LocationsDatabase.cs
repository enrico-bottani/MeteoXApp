using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp.Models
{
    public class LocationsDatabase
    {
        public SQLiteConnection Database { get; set; } 

        public LocationsDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Locations.db");
            Database = new SQLiteConnection(dbPath);
            Database.CreateTable<Location>();


            //Location l = new Location();
            //l.ID = 1;
            //l.Name = "a";
            //l.Longitude = 10;
            //l.Latitude = 20;


            //SaveItem(l);

            //var a = GetItems();
        }

        private List<Location> GetItems()
        {
            return Database.Table<Location>().ToList();
        }

        private List<Location> GetItemsNotDone()
        {
            return  Database.Query<Location>("SELECT * FROM [Location] WHERE [Done] = 0");
        }

        private Location GetItem(int id)
        {
            return Database.Table<Location>().Where(i => i.ID == id).FirstOrDefault();
        }

        private int SaveItem(Location item)
        {
            return Database.Insert(item);
        }

        private int DeleteItem(Location item)
        {
            return Database.Delete(item);
        }

        /**
         * AREA OPERAZIONI API DA USARE IN APP
         */

        public List<Location> GetLocations()
        {
            return Database.Table<Location>().ToList();
        }

        public Location GetLocation(string name)
        {
            return Database.Get<Location>((l) => l.Name.Equals(name));
        }

        public void Insert(Location l)
        {
            SaveItem(l);
        }

        public void Delete(string name)
        {
            var loc = Database.Find<Location>((l) => l.Name.Equals(name));
            Database.Delete<Location>(loc);
        }
    }
}
