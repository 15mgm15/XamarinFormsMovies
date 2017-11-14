using System;

using Xamarin.Forms;

namespace Movies
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<CloudDataStore>();

            MainPage = new NavigationPage(new MoviesPage());
        }
    }
}
