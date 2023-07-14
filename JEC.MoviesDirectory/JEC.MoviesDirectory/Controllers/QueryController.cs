using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JEC.MoviesDirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly ISearchQueryRepository _searchQueryRepository;

        public QueryController(ISearchQueryRepository searchQueryRepository)
        {
            _searchQueryRepository = searchQueryRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            var queries = await _searchQueryRepository.GetQueries();

            return Results.Ok(queries);
        }
    }
}
