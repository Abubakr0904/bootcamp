using System;
using RestSharp;

namespace lesson10
{
    public class GoogleTimeZone 
    {
        public double dstOffset { get; set; }
        public double rawOffset { get; set; }
        public string status { get; set; }
        public string timeZoneId { get; set; }
        public string timeZoneName { get; set; }
        
        public static DateTime GetLocalDateTime(double latitude, double longitude, DateTime utcDate)
        {
            var client = new RestClient("https://maps.googleapis.com");
            var request = new RestRequest("maps/api/timezone/json", RestSharp.Method.GET);
            request.AddParameter("location", latitude + "," + longitude);
            request.AddParameter("timestamp", utcDate.ToTimestamp());
            request.AddParameter("sensor", "false");
            var response = client.Execute<GoogleTimeZone>(request);

            return utcDate.AddSeconds(response.Data.rawOffset + response.Data.dstOffset);
        }
    }
}