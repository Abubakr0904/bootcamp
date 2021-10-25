namespace QuickType
{
    using System;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Timings
    {
        [JsonProperty("Fajr")]
        public string Fajr { get; set; }

        [JsonProperty("Sunrise")]
        public string Sunrise { get; set; }

        [JsonProperty("Dhuhr")]
        public string Dhuhr { get; set; }

        [JsonProperty("Asr")]
        public string Asr { get; set; }

        [JsonProperty("Sunset")]
        public string Sunset { get; set; }

        [JsonProperty("Maghrib")]
        public string Maghrib { get; set; }

        [JsonProperty("Isha")]
        public string Isha { get; set; }

        [JsonProperty("Imsak")]
        public string Imsak { get; set; }

        [JsonProperty("Midnight")]
        public string Midnight { get; set; }
    }
}
