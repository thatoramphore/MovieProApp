﻿using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MovieProApp.Enums;
using MovieProApp.Models.Settings;
using MovieProApp.Models.TMDB;
using MovieProApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MovieProApp.Services
{
    public class TMDBMovieService : IRemoteMovieService
    {
        //Dependencies
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClient;

        public TMDBMovieService(IOptions<AppSettings> appSettings, IHttpClientFactory httpClient)
        {
            _appSettings = appSettings.Value;
            _httpClient = httpClient;
        }

        public async Task<ActorDetail> ActorDetailAsync(int id)
        {
            //Step 1: Setup a default return object
            ActorDetail actorDetail = new();

            //Step 2: Assemble the full request uri string
            var query = $"{_appSettings.TMDBSettings.BaseUrl}/person/{id}";
            var queryParams = new Dictionary<string, string>()
            {
                { "api_key", _appSettings.MovieProSettings.TmDbApiKey },
                { "language", _appSettings.TMDBSettings.QueryOptions.Language}
            };
            var requestUri = QueryHelpers.AddQueryString(query, queryParams);

            //Step 3: Create a client and execute the request
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await client.SendAsync(request);

            //Step 4: Return the ActorDetail object
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var dcjs = new DataContractJsonSerializer(typeof(ActorDetail));
                actorDetail = (ActorDetail)dcjs.ReadObject(responseStream);
            }

            return actorDetail;
        }

        public async Task<MovieDetail> MovieDetailAsync(int id)
        {
            //Step 1: Setup a default instance of MovieDetail
            MovieDetail movieDetail = new MovieDetail();
            //Step 2: Assemble the full request uri string
            var query = $"{_appSettings.TMDBSettings.BaseUrl}/movie/{id}";

            var queryParams = new Dictionary<string, string>()
            {
                { "api_key", _appSettings.MovieProSettings.TmDbApiKey},
                { "language", _appSettings.TMDBSettings.QueryOptions.Language },
                { "append_to_response", _appSettings.TMDBSettings.QueryOptions.AppendToResponse }
            };

            //add parameters to the query string
            var requestUri = QueryHelpers.AddQueryString(query, queryParams);

            //Step 3: Create a client and execute the request
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await client.SendAsync(request);     //await response

            //Step 4: Return the MovieDetail object
            if (response.IsSuccessStatusCode)
            {
                
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var dcjs = new DataContractJsonSerializer(typeof(MovieDetail));
                movieDetail = dcjs.ReadObject(responseStream) as MovieDetail;
                
            }

            return movieDetail;
        }

        public async Task<MovieSearch> SearchMoviesAsync(MovieCategory category, int count)
        {
            //Step 1: Setup a default instance of MovieSearch
            MovieSearch movieSearch = new MovieSearch();
            //Step 2: Assemble the full request uri string
            var query = $"{_appSettings.TMDBSettings.BaseUrl}/movie/{category}";

            var queryParams = new Dictionary<string, string>()
            {
                { "api_key", _appSettings.MovieProSettings.TmDbApiKey},
                { "language", _appSettings.TMDBSettings.QueryOptions.Language },
                { "page", _appSettings.TMDBSettings.QueryOptions.Page }
            };

            //add parameters to the query string
            var requestUri = QueryHelpers.AddQueryString(query, queryParams);

            //Step 3: Create a client and execute the request
            var client = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);   
            var response = await client.SendAsync(request);     //await response

            //Step 4: Return the MovieSearch object
            if (response.IsSuccessStatusCode)
            {
                var dcjs = new DataContractJsonSerializer(typeof(MovieSearch));
                using var responseStream = await response.Content.ReadAsStreamAsync();
                movieSearch = (MovieSearch)dcjs.ReadObject(responseStream);
                movieSearch.results = movieSearch.results.Take(count).ToArray();  //manage results count per page
                //set poster_path - to prepend the full url to the image 
                movieSearch.results.ToList().ForEach(r => r.poster_path = $"{_appSettings.TMDBSettings.BaseImagePath}/{_appSettings.MovieProSettings.DefaultPosterSize}/{r.poster_path}");
            }

            return movieSearch;
        }
    }
}
