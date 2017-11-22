using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Movies.Models
{
    public class MoviesResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("results")]
        public List<Movie> Results { get; set; }
    }
}
