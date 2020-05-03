using PopsicleJokesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopsicleJokesApp.Data
{
    public class PopsicleJokeItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public PopsicleJokeItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(JokeItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(JokeItem)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }


        public Task<List<JokeItem>> GetItemsAsync()
        {
            return Database.Table<JokeItem>().ToListAsync();
        }

        public Task<List<JokeItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<JokeItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<JokeItem> GetItemAsync(int id)
        {
            return Database.Table<JokeItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(JokeItem item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
    }
}
