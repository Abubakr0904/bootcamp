namespace QuickType
{
    using Newtonsoft.Json;

    public partial class Params
    {
        [JsonProperty("Fajr")]
        public long Fajr { get; set; }

        [JsonProperty("Isha")]
        public long Isha { get; set; }
    }
}
