using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseKeeper.Models;
using SQLite;

namespace CourseKeeper.Services
{
    public class CourseKeeperDatabase : ICourseDataStore<Term>
    {
        List<Term> items;
        static SQLiteAsyncConnection database;
        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteAsyncConnection(
                        System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CourseKeeperSQLite.db3"));
                }
                return database;
            }
        }

        public CourseKeeperDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Term>().Wait();
        }

        public Task<List<Term>> GetItemsAsync()
        {
            return database.Table<Term>().ToListAsync();
        }

        public Task<Term> GetItemAsync(string id)
        {
            return database.Table<Term>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveItemAsync(Term item)
        {
            if (item.ID != null)
            {

                return database.UpdateAsync(item).IsCompleted;
            }
            else
            {
                return database.InsertAsync(item).IsCompleted;
            }
        }

        public async Task<bool> DeleteItemAsync(Term item)
        {
            return database.DeleteAsync(item).IsCompleted;
        }
    }
}