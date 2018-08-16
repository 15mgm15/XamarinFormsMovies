using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public static string BaseImgUrl = "http://image.tmdb.org/t/p/w500";
        public static string HighResBaseImgUrl = "http://image.tmdb.org/t/p/w1000";
        const string BaseUrl = "http://api.themoviedb.org/3/";
        const string ApiKey = "api_key=ab41356b33d100ec61e6c098ecc92140";
        const string PageString = "&page=";
        const string Results = "results";
        //const string SessionId = "&session_id=cf067fbacd2ddd5c675ae143ea44a50033e0a46a";

        #endregion

        readonly HttpClient Client;
        List<Movie> Items;

        public CloudDataStore()
        {
            Client = new HttpClient();
            Items = new List<Movie>();
        }

        #region Methods

        public async Task<Tuple<List<Movie>, string>> GetItemsAsync(int Page)
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    string topRatedUrl = BaseUrl + "movie/upcoming?" + ApiKey + PageString + Page;
                    var json = await Client.GetStringAsync(topRatedUrl).ConfigureAwait(false);
                    var baseMoviesResponse = await Task.Run(() => JsonConvert.DeserializeObject<MoviesResponse>(json));
                    Items = baseMoviesResponse.Results;
                    return new Tuple<List<Movie>, string>(Items, StaticData.Success);
                }
                return new Tuple<List<Movie>, string>(null, StaticData.NoInternetConection);
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(GetItemsAsync), ex.Message);
                return new Tuple<List<Movie>, string>(null, ex.Message);
            }
        }

        #endregion
    }
}
