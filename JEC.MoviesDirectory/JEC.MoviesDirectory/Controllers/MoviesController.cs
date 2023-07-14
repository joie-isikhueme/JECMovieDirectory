using JEC.MoviesDirectory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace JEC.MoviesDirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IOmdbClient _client;
        private readonly ISearchQueryRepository _searchQueryRepository;

        public MoviesController(IOmdbClient omdbClient, ISearchQueryRepository searchQueryRepository)
        {
            _client = omdbClient;
            _searchQueryRepository = searchQueryRepository;
        }

        [HttpGet("search")]
        public async Task<IResult> Search(string query, int page) 
        {
            var res = await _client.SearchMoviesAsync(query, CancellationToken.None, page);

            if (res.IsSuccess !=  true)
            {
                switch (res.Error.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return Results.NotFound();
                    case HttpStatusCode.Unauthorized:
                        return Results.Unauthorized();
                    case HttpStatusCode.InternalServerError:
                        return Results.StatusCode(500);
                }
            }

            await _searchQueryRepository.SaveQuery(new SearchQuery { Query = query });

            return Results.Ok(res.Data);
        }

        [HttpGet("{id}")]
        public async Task<IResult> FindMovie(string id)
        {
            var res = await _client.GetMovieAsync(id, CancellationToken.None);

            if (res.IsSuccess != true)
            {
                switch (res.Error.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return Results.NotFound();
                    case HttpStatusCode.Unauthorized:
                        return Results.Unauthorized();
                    case HttpStatusCode.InternalServerError:
                        return Results.StatusCode(500);
                }
            }

            return Results.Ok(res.Data);
        }


        [HttpGet("title")]
        public async Task<IResult> FindMovieByTitle(string title)
        {
            var res = await _client.GetMovieByTitleAsync(title, CancellationToken.None);

            if (res.IsSuccess != true)
            {
                switch (res.Error.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return Results.NotFound();
                    case HttpStatusCode.Unauthorized:
                        return Results.Unauthorized();
                    case HttpStatusCode.InternalServerError:
                        return Results.StatusCode(500);
                }
            }

            return Results.Ok(res.Data);
        }
    }
}
