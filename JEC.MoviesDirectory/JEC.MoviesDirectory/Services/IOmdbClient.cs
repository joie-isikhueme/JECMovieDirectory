namespace JEC.MoviesDirectory.Services
{
    public interface IOmdbClient
    {
        public Task<Result<SearchResult>> SearchMoviesAsync(string query, CancellationToken ct, int page);
        public Task<Result<Movie>> GetMovieAsync(string movieId, CancellationToken ct);
        //public Task<Result<MovieResult>> GetMovieByTitleAsync(string title, CancellationToken ct);
    }

    

}
