using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseKeeper.Services
{
    public interface ICourseDataStore<T>
    {
        Task<bool> SaveItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<List<T>> GetItemsAsync();
    }
}
