using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp.Models
{
    class LocationsDatabase
    {
        public SQLiteAsyncConnection Database { get; set; } 

        public LocationsDatabase(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Location>().Wait();
        }

        public Task<List<Location>> GetItemsAsync()
        {
            return Database.Table<Location>().ToListAsync();
        }

        public Task<List<Location>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Location>("SELECT * FROM [Location] WHERE [Done] = 0");
        }

        public Task<Location> GetItemAsync(int id)
        {
            return Database.Table<Location>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Location item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Location item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
