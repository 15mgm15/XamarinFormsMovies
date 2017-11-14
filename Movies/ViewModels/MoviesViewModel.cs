﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Movies.Models;
using Xamarin.Forms.Extended;

namespace Movies
{
    public class MoviesViewModel : BaseViewModel
    {
        #region Properties and Commands

        public InfiniteScrollCollection<Movie> Items { get; set; }

        public Command LoadItemsCommand { get; set; }
        public Command RefreshItemsCommand { get; set; }

        int Page;

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        bool _isLoadingMore;
        public bool IsLoadingMore
        {
            get { return _isLoadingMore; }
            set { SetProperty(ref _isLoadingMore, value); }
        }

        #endregion

        public MoviesViewModel()
        {
            Title = "Upcoming Movies";
            Items = new InfiniteScrollCollection<Movie>{
                OnLoadMore = async () =>
                {
                    await LoadMoreData();
                    return null;
                }
            };

            Page = 1;


            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            RefreshItemsCommand = new Command(async () => await ExecuteRefreshItemsCommand());
        }

        #region Methods

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await CallApiAndLoadList();
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

        async Task ExecuteRefreshItemsCommand()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            try
            {
                Items.Clear();
                Page = 1;
                await CallApiAndLoadList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Class: {0} Method: {1} Exception: {2}",
                                nameof(MoviesViewModel), nameof(ExecuteRefreshItemsCommand), ex.Message);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        async Task LoadMoreData()
        {
            try
            {
                if (IsLoadingMore)
                {
                    return;
                }

                IsLoadingMore = true;

                Page++;
                if (Page > 1)
                {
                    await CallApiAndLoadList();
                }
            }
            catch (Exception ex)
            {
                Page--;
                Debug.WriteLine("Class: {0} Method: OnLoadMore InfiniteScrollCollection, Exception: {2}",
                                nameof(MoviesViewModel), ex.Message);
            }
            finally
            {
                IsLoadingMore = false;
            }
        }

        async Task CallApiAndLoadList()
        {
            var response = await DataStore.GetItemsAsync(Page);
            var moviesList = response?.Item1;

            if (moviesList == null || !moviesList.Any())
            {
                return;
            }

            foreach (var movie in moviesList)
            {
                var alreadyAdded = Items.FirstOrDefault(m => m.Id == movie.Id);
                if(alreadyAdded == null)
                {
                    Items.Add(movie);   
                }
            }
        }

        #endregion
    }
}
