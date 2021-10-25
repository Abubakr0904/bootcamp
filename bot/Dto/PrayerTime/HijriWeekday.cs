namespace QuickType
{
    using Newtonsoft.Json;

    public partial class HijriWeekday
    {
        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("ar")]
        public string Ar { get; set; }
    }
}
