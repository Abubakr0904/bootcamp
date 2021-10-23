using System.Collections.Generic;

namespace lesson10.Dto.PrayerTime
{

    public class PrayerTime
    {
        public int code { get; set; }
        public string status { get; set; }
        public List<Datum> data { get; set; }
    }


}