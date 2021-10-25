namespace QuickType
{
    using Newtonsoft.Json;

    public partial class Data
    {
        [JsonProperty("timings")]
        public Timings Timings { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
