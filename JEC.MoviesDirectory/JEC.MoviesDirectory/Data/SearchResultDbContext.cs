using Microsoft.EntityFrameworkCore;

namespace JEC.MoviesDirectory.Data
{
    public class SearchResultDbContext : DbContext
    {
        public SearchResultDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<SearchQuery> SearchQueries { get; set;}
    }
}
