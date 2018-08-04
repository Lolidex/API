using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.Responses
{
    class AutoCompleteResponse
    {
        [JsonProperty("autocomplete")]
        public List<string> AutoComplete { get; set; }
    }
}
