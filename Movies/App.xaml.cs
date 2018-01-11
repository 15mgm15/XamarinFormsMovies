using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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

            AppCenter.Start("ios=eb19303a-5b45-41d7-808d-44f5744149e0;" +
                            "android=13f1224a-d4bb-4817-bef0-ef829ea96d13;",
                   typeof(Analytics), typeof(Crashes));

            DependencyService.Register<CloudDataStore>();

            MainPage = new BaseNavigationPage(new MoviesPage()){};
        }
    }
}
