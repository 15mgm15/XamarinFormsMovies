using System;
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

            MainPage = new NavigationPage(new MoviesPage()){};
        }
    }
}
