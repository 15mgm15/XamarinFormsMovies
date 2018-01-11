using Microsoft.AppCenter.Analytics;
using Movies.Models;
using Movies.Views.Base;

namespace Movies
{
    public partial class MovieDetailPage : BaseContentPage
    {
        public MovieDetailPage(Movie movie)
        {
            InitializeComponent();
            BindingContext = movie;

            Analytics.TrackEvent(nameof(MovieDetailPage) + " Opened, specific moview: " + movie.Title);
        }
    }
}
