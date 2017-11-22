using System;
using Movies.Views.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Movies
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            DependencyService.Register<CloudDataStore>();

            MainPage = new BaseNavigationPage(new MoviesPage()){};
        }
    }
}
