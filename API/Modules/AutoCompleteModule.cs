using Nancy;
using RethinkDb.Driver;
using RethinkDb.Driver.Net;
using System.Collections.Generic;
using API.Responses;

namespace API.Modules
{
    public class AutoCompleteModule : NancyModule
    {
        private RethinkDB R = RethinkDB.R;

        public AutoCompleteModule() : base("/autocomplete")
        {
            Get("/", x =>
            {
                var search = Request.Query["name"];

                // if search query is empty then suggest nothing
                if (string.IsNullOrEmpty(search))
                {
                    return Response.AsJson(new AutoCompleteResponse()
                    {
                        AutoComplete = new List<string>()
                    });
                }

                Cursor<string> result = R.Db("Lolidex").Table("Characters").Filter(row => row.G("Name").Match("(?i)^" + search)).G("Name").Limit(5).Run<string>(Program.Conn);
                List<string> autocomplete = new List<string>();

                // loop through the results and add them to a list
                foreach (string name in result)
                {
                    autocomplete.Add(name);
                }

                return Response.AsJson(new AutoCompleteResponse()
                {
                    AutoComplete = autocomplete
                });
            });
        }   
    }
}
