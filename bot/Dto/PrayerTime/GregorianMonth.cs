namespace QuickType
{
    using Newtonsoft.Json;

    public partial class GregorianMonth
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("en")]
        public string En { get; set; }
    }
}
