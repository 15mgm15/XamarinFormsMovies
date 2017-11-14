using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<Tuple<List<T>, string>> GetItemsAsync(bool forceRefresh = false);
    }
}
