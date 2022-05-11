using System.Net.Http;

namespace NBPApp.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set;}
    }
}
