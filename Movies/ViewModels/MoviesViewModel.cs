using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Movies.Models;

namespace Movies
{
    public class MoviesViewModel : BaseViewModel
    {
        #region Properties and Commands

        public ObservableCollection<Movie> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        #endregion

        public MoviesViewModel()
        {
            Title = "Upcoming Movies";
            Items = new ObservableCollection<Movie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        #region Methods

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var response = await DataStore.GetItemsAsync(true);
                var moviesList = response?.Item1;

                if(moviesList == null || !moviesList.Any())
                {
                    return;
                }

                foreach (var movie in moviesList)
                {
                    Items.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Class: {0} Method: {1} Exception: {2}", 
                                nameof(MoviesViewModel), nameof(ExecuteLoadItemsCommand),ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
