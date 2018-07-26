using Nancy;
using Nancy.ErrorHandling;
using Nancy.Responses;
using Newtonsoft.Json;

namespace API.Handlers
{
    public class ErrorHandler : IStatusCodeHandler
    {

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = (Response)JsonConvert.SerializeObject(new Error()
            {
                Code = (int)statusCode,
                Message = statusCode.ToString()
            });
            response.ContentType = "application/json";

            context.Response = response;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return true;
        }
    }

    internal class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
