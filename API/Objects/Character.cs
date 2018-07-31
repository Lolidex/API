using Newtonsoft.Json;
using System;

namespace API.Objects
{
    class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("translatedname")]
        public string TranslatedName { get; set; }

        [JsonProperty("nickname")]
        public string[] Nickname { get; set; }

        [JsonProperty("isloli")]
        public bool IsLoli { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("birthdate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }

        [JsonProperty("birthplace")]
        public string BirthPlace { get; set; }

        [JsonProperty("bloodtype")]
        public string BloodType { get; set; }

        [JsonProperty("source")]
        public string[] Source { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("haircolor")]
        public string HairColor { get; set; }

        [JsonProperty("lefteyecolor")]
        public string LeftEyeColor { get; set; }

        [JsonProperty("righteyecolor")]
        public string RightEyeColor { get; set; }
    }
}
