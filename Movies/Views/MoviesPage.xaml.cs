using Movies.Views.Base;
using Xamarin.Forms;

namespace Movies
{
    public partial class MoviesPage : BaseContentPage
    {
        MoviesViewModel viewModel;

        public MoviesPage()
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, string.Empty);

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
