namespace QuickType
{
    using Newtonsoft.Json;

    public partial class Method
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
