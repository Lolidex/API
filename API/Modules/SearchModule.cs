using Nancy;
using API.Objects;
using API.Responses;
using Nancy.ModelBinding;
using RethinkDb.Driver;
using System.Collections.Generic;
using RethinkDb.Driver.Net;
using System.Linq;

namespace API.Modules
{
    public class SearchModule : NancyModule
    {
        private RethinkDB R = RethinkDB.R;

        public SearchModule() : base("/search")
        {
            Get("/", x => {
                var parameters = this.Bind<SearchParameters>();

                if (parameters.IsEmpty())
                {
                    // no search parameters provided
                    return Response.AsJson(new ErrorResponse()
                    {
                        Code = 400,
                        Message = "No search parameters provided, following available: " + 
                            string.Join(", ", typeof(SearchParameters).GetProperties().Select(prop => prop.Name).ToList())
                    });
                }

                Cursor<Character> result = R.Db("Lolidex").Table("Characters").Filter(parameters.ToReQLHashMap()).Run<Character>(Program.Conn);
                List<Character> characters = new List<Character>();
                
                // loop through the results and add them to a list
                foreach(Character character in result)
                {
                    characters.Add(character);
                }

                return Response.AsJson(new SearchResponse()
                {
                    Results = characters.Count,
                    Characters = characters
                });
            });          
        }
    }
}
