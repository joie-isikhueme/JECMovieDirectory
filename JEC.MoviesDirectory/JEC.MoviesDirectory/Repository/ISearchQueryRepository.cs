namespace JEC.MoviesDirectory.Repository
{
    public interface ISearchQueryRepository
    {
        Task<IEnumerable<SearchQuery>> GetQueries();
        Task SaveQuery(SearchQuery query);
    }
}