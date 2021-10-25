namespace QuickType
{
    using Newtonsoft.Json;

    public partial class Gregorian
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("weekday")]
        public GregorianWeekday Weekday { get; set; }

        [JsonProperty("month")]
        public GregorianMonth Month { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("designation")]
        public Designation Designation { get; set; }
    }
}
