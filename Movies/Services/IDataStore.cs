﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies
{
    public interface IDataStore<T>
    {
        Task<Tuple<List<T>, string>> GetItemsAsync(int page = 1);
    }
}
