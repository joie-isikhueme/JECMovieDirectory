namespace JEC.MoviesDirectory.Models
{
    public class Result<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public HttpError? Error { get; set; } 
    }
}
