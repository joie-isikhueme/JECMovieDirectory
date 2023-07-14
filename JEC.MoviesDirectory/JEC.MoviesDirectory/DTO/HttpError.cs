using System.Net;

namespace JEC.MoviesDirectory.Models
{
    public class HttpError
    {
        public HttpStatusCode? StatusCode { get;set; }
        public string? Message { get;set; }
    }
}
