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
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Entrys.db");
            Database = new SQLiteConnection(dbPath);
            Database.CreateTable<Entry>();


            //Entry l = new Entry();
            //l.ID = 1;
            //l.Name = "a";
            //l.Longitude = 10;
            //l.Latitude = 20;


            //SaveItem(l);

            //var a = GetItems();
        }

        private List<Entry> GetItems()
        {
            return Database.Table<Entry>().ToList();
        }

        private List<Entry> GetItemsNotDone()
        {
            return Database.Query<Entry>("SELECT * FROM [Entry] WHERE [Done] = 0");
        }

        private Entry GetItem(int id)
        {
            return Database.Table<Entry>().Where(i => i.ID == id).FirstOrDefault();
        }

        private int SaveItem(Entry item)
        {
            return Database.Insert(item);
        }

        private int DeleteItem(Entry item)
        {
            return Database.Delete(item);
        }

        /**
         * AREA OPERAZIONI API DA USARE IN APP
         */

        public List<Entry> GetEntrys()
        {
            return Database.Table<Entry>().ToList();
        }

        public Entry GetEntry(string name)
        {
            return Database.Get<Entry>((l) => l.Name.Equals(name));
        }

        public void Insert(Entry l)
        {
            SaveItem(l);
        }

        public void Delete(string name)
        {
            var loc = Database.Find<Entry>((l) => l.Name.Equals(name));
            Database.Delete<Entry>(loc);
        }
    }
}