namespace QuickType
{
    using Newtonsoft.Json;

    public partial class Root
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
