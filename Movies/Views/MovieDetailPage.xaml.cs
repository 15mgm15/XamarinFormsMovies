using System;
using Movies.Models;
using Xamarin.Forms;

namespace Movies
{
    public partial class MovieDetailPage : ContentPage
    {
        MovieDetailViewModel viewModel;

        public MovieDetailPage()
        {
            InitializeComponent();

            var item = new Movie
            {
                
            };

            viewModel = new MovieDetailViewModel(item);
            BindingContext = viewModel;
        }

        public MovieDetailPage(MovieDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
