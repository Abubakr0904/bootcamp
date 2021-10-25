namespace QuickType
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class Meta
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("method")]
        public Method Method { get; set; }

        [JsonProperty("latitudeAdjustmentMethod")]
        public string LatitudeAdjustmentMethod { get; set; }

        [JsonProperty("midnightMode")]
        public string MidnightMode { get; set; }

        [JsonProperty("school")]
        public string School { get; set; }

        [JsonProperty("offset")]
        public Dictionary<string, long> Offset { get; set; }
    }
}
