namespace QuickType
{
    using Newtonsoft.Json;

    public partial class HijriMonth
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("ar")]
        public string Ar { get; set; }
    }
}
