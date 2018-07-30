using API.Responses;
using Nancy;
using Nancy.ErrorHandling;
using Newtonsoft.Json;

namespace API.Handlers
{
    public class ErrorHandler : IStatusCodeHandler
    {
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = (Response)JsonConvert.SerializeObject(new ErrorResponse()
            {
                Code = (int)statusCode,
                Message = statusCode.ToString()
            });
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            context.Response = response;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return false;
        }
    }
}
