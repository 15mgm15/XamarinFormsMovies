using Movies.Models;
using Movies.Views.Base;
using Xamarin.Forms;

namespace Movies
{
    public partial class MovieDetailPage : BaseContentPage
    {
        public MovieDetailPage(Movie movie)
        {
            InitializeComponent();
            BindingContext = movie;
            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }
    }
}
