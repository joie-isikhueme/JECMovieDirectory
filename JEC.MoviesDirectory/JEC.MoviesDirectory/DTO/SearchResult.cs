namespace JEC.MoviesDirectory.DTO

{
    public class SearchResult
    {
        public IList<MovieResult>? Search { get; set; }
        public string? TotalResults { get; set; }
        public string? Response { get; set; }
    }
}
