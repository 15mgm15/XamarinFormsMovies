using System;
using Newtonsoft.Json;

namespace Movies.Models
{
    public class Movie
    {
        [JsonProperty("poster_path")]
        public string PosterPath { get; set;}

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string Language { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_average")]
        public float VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public double VoteCount { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        public bool Favorite { get; set; }

        public string PosterImage { get; set; }

        public string HighResPosterPath { get; set; }
    }
}
