using API.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.Responses
{
    class SearchResponse
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("characters")]
        public List<Character> Characters { get; set; }
    }
}
