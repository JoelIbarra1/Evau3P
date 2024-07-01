using Evau3P.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evau3P.Services
{
    public class DataBaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DataBaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Jokes>().Wait();
        }

        public Task<List<Jokes>> GetSWCharactersAsync()
        {
            return _database.Table<Jokes>().ToListAsync();
        }

        public Task<int> SaveSWCharactersAsync(Jokes swCharacters)
        {
            if (swCharacters.Id != 0)
            {
                return _database.UpdateAsync(swCharacters);
            }
            else
            {
                return _database.InsertOrReplaceAsync(swCharacters);
            }
        }

        public Task<int> DeleteSWCharactersAsync(Jokes swCharacters)
        {
            return _database.DeleteAsync(swCharacters);
        }
    }
}
