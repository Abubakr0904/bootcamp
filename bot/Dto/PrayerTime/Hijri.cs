namespace QuickType
{
    using Newtonsoft.Json;

    public partial class Hijri
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("day")]
        public long Day { get; set; }

        [JsonProperty("weekday")]
        public HijriWeekday Weekday { get; set; }

        [JsonProperty("month")]
        public HijriMonth Month { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("designation")]
        public Designation Designation { get; set; }

        [JsonProperty("holidays")]
        public object[] Holidays { get; set; }
    }
}
