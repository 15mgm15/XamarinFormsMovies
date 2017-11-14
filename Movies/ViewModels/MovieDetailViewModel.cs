using System;
using Movies.Models;

namespace Movies
{
    public class MovieDetailViewModel : BaseViewModel
    {
        public Movie Item { get; set; }
        public MovieDetailViewModel(Movie item = null)
        {
            
        }
    }
}
