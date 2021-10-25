namespace QuickType
{
    using Newtonsoft.Json;

    public partial class Date
    {
        [JsonProperty("readable")]
        public string Readable { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("hijri")]
        public Hijri Hijri { get; set; }

        [JsonProperty("gregorian")]
        public Gregorian Gregorian { get; set; }
    }
}
