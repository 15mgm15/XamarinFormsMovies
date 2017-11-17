using Movies.Views.Base;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Movies
{
    public partial class MoviesPage : BaseContentPage
    {
        MoviesViewModel viewModel;

        public MoviesPage()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);

            BindingContext = viewModel = new MoviesViewModel
            {
                Navigation = Navigation
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
