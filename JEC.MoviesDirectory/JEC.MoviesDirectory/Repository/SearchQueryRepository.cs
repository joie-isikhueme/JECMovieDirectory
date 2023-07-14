using JEC.MoviesDirectory.Data;
using Microsoft.EntityFrameworkCore;

namespace JEC.MoviesDirectory.Repository
{
    public class SearchQueryRepository : ISearchQueryRepository
    {
        private readonly SearchResultDbContext _context;

        public SearchQueryRepository(SearchResultDbContext context)
        {
            _context = context;
        }

        public async Task SaveQuery(SearchQuery query)
        {
            _context.SearchQueries.Add(query);
            var result = await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SearchQuery>> GetQueries()
        {         
            var queries = await _context.SearchQueries.OrderBy(s => s.ID).Take(5).ToListAsync();

            return queries;
        }
    }
}
