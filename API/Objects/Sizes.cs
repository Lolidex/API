using Newtonsoft.Json;

namespace API.Objects
{
    class Sizes
    {       
        [JsonProperty("bust")]
        public int Bust { get; set; }

        [JsonProperty("waist")]
        public int Waist { get; set; }

        [JsonProperty("hips")]
        public int Hips { get; set; } // thic gril
    }
}
