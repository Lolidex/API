using Newtonsoft.Json;

namespace API.Objects
{
    class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("haircolor")]
        public string HairColor { get; set; }

        [JsonProperty("eyecolor")]
        public string EyeColor { get; set; }
    }
}
