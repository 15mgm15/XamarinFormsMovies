using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Models;
using Xamarin.Forms;

namespace Movies
{
    public partial class MoviesPage : ContentPage
    {
        MoviesViewModel viewModel;

        public MoviesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MoviesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
