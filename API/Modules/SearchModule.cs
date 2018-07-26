using API.Responses;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Modules
{
    public class SearchModule : NancyModule
    {

        public SearchModule() : base("/search")
        {

            Get("/", x => {
                var parameters = this.Bind<SearchParameters>();

                if (parameters.IsEmpty)
                {
                    // no search parameters provided
                    return Response.AsJson(new ErrorResponse()
                    {
                        Code = 400,
                        Message = "No search parameters provided"
                    });
                }

                return Response.AsText("tttttt");
            });

            
        }

    }

    internal class SearchParameters
    {
        public string EyeColor { get; set; }
        public string HairColor { get; set; }

        public bool IsEmpty
        {
            get
            {
                return EyeColor == null && HairColor == null;
            }
        }
    }

}
