using System;
using System.Text.Json;
using System.Threading.Tasks;
using lesson10.Dto.PrayerTime;
using System.Net.Http;
using System.Net.Http.Headers; 

using lesson10.Dto.User;
using lesson10.Services;
using GoogleMaps.LocationServices;

namespace lesson10
{
    class Program
    {
        private static string prayerTimeApi = "http://api.aladhan.com/v1/calendarByCity?city=London&country=United Kingdom&method=2&month=04&year=2017";
        
        public static void SetSettings(string davlat, string shahar, string oy, string yil)
        {
            prayerTimeApi = "http://api.aladhan.com/v1/calendarByCity?city={shahar}&country={davlat}&method=1&school=1&month={oy}&year=2017";
        }

        static async Task Main(string[] args)
        {
            while(true)
            {
                var httpService = new HttpClientService();
                var result = await httpService.GetObjectAsync<PrayerTime>(prayerTimeApi);

                if(result.IsSuccess)
                {
                    var settings = new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    };

                    var json = JsonSerializer.Serialize(result.Data.Data.Timings, settings);
                    Console.WriteLine($"{json}");
                }
                else
                {
                    Console.WriteLine($"{result.ErrorMessage}");
                }
            }
        }
    }
}
