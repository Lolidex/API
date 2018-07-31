using Nancy;
using API.Responses;
using System;
using RethinkDb.Driver;

namespace API.Modules
{
    public class AddModule : NancyModule
    {
        private RethinkDB R = RethinkDB.R;

        public AddModule() : base("/add")
        {
            Post("/", x =>
            {
                if (!IsTokenValid(Request.Headers.Authorization))
                {
                    return Response.AsJson(new ErrorResponse()
                    {
                        Code = 401,
                        Message = "You need to provide a valid token"
                    });
                }

                return Response.AsText("TODO");
            });

            Get("/", x =>
            {
                return Response.AsJson(new ErrorResponse()
                {
                    Code = 405,
                    Message = "This endpoint can only be called using a POST request"
                });
            });

        }

        public bool IsTokenValid(string token)
        {
            if (String.IsNullOrEmpty(token))
                return false;

            return R.Db("Lolidex").Table("Tokens").Filter(R.HashMap("Token", token)).Count().Eq(1).Run(Program.Conn);
        }
    }
}
