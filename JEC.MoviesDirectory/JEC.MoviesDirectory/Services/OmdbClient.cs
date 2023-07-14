using JEC.MoviesDirectory.DTO;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Serialization;

namespace JEC.MoviesDirectory.Services
{
    public class OmdbClient : IOmdbClient
    {
        private IConfiguration _configuration { get; set; }
        private string _apiKey { get; set; }
        private HttpClient _httpClient { get; set; }
        private string _baseUrl { get; set; }

        public OmdbClient(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _apiKey = configuration.GetValue<string>("OmdbApiKey");
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("BaseUrl");
        }

        public async Task<Result<SearchResult>> SearchMoviesAsync(string query, CancellationToken ct, int page = 1) 
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/?s={query}&page={page}&apikey={_apiKey}", ct);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<SearchResult>();

                return new Result<SearchResult> { Data = result, IsSuccess = true};
            } catch (HttpRequestException ex)
            {
                var error = new HttpError() { Message = ex.Message, StatusCode = ex.StatusCode };

                return new Result<SearchResult>
                {
                    IsSuccess = false,
                    Error = error
                };
            }
        }

        public async Task<Result<Movie>> GetMovieAsync(string movieId, CancellationToken ct)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/?i={movieId}&apikey={_apiKey}", ct);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Movie>();

                return new Result<Movie> { Data = result, IsSuccess = true };
            }
            catch (HttpRequestException ex)
            {
                var error = new HttpError() { Message = ex.Message, StatusCode = ex.StatusCode };

                return new Result<Movie>
                {
                    IsSuccess = false,
                    Error = error
                };
            }
        }

        public async Task<Result<MovieResult>> GetMovieByTitleAsync(string title, CancellationToken ct)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}?s={title}&apikey={_apiKey}", ct);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<MovieResult>();

                return new Result<MovieResult> { Data = result, IsSuccess = true };
            }
            catch (HttpRequestException ex)
            {
                var error = new HttpError() { Message = ex.Message, StatusCode = ex.StatusCode };

                return new Result<MovieResult>
                {
                    IsSuccess = false,
                    Error = error
                };
            }
        }

    }
}
