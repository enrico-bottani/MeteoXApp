using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp.Models
{
    class LocationsDatabase
    {
        public SQLiteAsyncConnection Database { get; set; } 

        public LocationsDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Locations.db");
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Location>().Wait();
        }

        private async Task<List<Location>> GetItemsAsync()
        {
            return await Database.Table<Location>().ToListAsync();
        }

        private async Task<List<Location>> GetItemsNotDoneAsync()
        {
            return await Database.QueryAsync<Location>("SELECT * FROM [Location] WHERE [Done] = 0");
        }

        private async Task<Location> GetItemAsync(int id)
        {
            return await Database.Table<Location>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        private async Task<int> SaveItemAsync(Location item)
        {
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        private async Task<int> DeleteItemAsync(Location item)
        {
            return await Database.DeleteAsync(item);
        }

        /**
         * AREA OPERAZIONI API DA USARE IN APP
         */

        public async Task<List<Location>> GetLocations()
        {
            return await Database.Table<Location>().ToListAsync();
        }

        public async Task<Location> GetLocation(string name)
        {
            return await Database.GetAsync<Location>((l) => l.Name.Equals(name));
        }

        public async void Insert(Location l)
        {
            if (Database.GetAsync<Location>((x) => x.Name.Equals(l.Name)) == null)
                await Database.InsertAsync(l);
            else
                await Database.UpdateAsync(l);
        }

        public async void Delete(string name)
        {
            var loc = Database.FindAsync<Location>((l) => l.Name.Equals(name));
            await Database.DeleteAsync<Location>(loc);
        }
    }
}
