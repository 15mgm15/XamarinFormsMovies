using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Movies.Helpers;
using Movies.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Movies
{
    public class CloudDataStore : IDataStore<Movie>
    {
        #region Static data

        const string BaseUrl = "http://api.themoviedb.org/3/";
        const string ApiKey = "api_key=ab41356b33d100ec61e6c098ecc92140";
        const string BaseImgUrl = "http://image.tmdb.org/t/p/w92";
        const string PageString = "&page=";
        const string Results = "results";
        const string HighResBaseImgUrl = "http://image.tmdb.org/t/p/w300";
        //const string SessionId = "&session_id=cf067fbacd2ddd5c675ae143ea44a50033e0a46a";

        #endregion

        HttpClient client;
        List<Movie> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            items = new List<Movie>();
        }

        #region Methods

        public async Task<Tuple<List<Movie>, string>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                if (forceRefresh && CrossConnectivity.Current.IsConnected)
                {
                    //TODO: Page:  + PageString + Page
                    string topRatedUrl = BaseUrl + "movie/top_rated?" + ApiKey;
                    var json = await client.GetStringAsync(topRatedUrl);
                    var baseMoviesResponse = await Task.Run(() => JsonConvert.DeserializeObject<MoviesResponse>(json));
                    items = baseMoviesResponse.Results;
                    return new Tuple<List<Movie>, string>(items, StaticData.Success);
                }
                return new Tuple<List<Movie>, string>(null, StaticData.NoInternetConection);
            }
            catch (Exception ex)
            {
                return new Tuple<List<Movie>, string>(null, ex.Message);
            }
        }

        public async Task<Movie> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Movie>(json));
            }

            return null;
        }

        #endregion
    }
}
