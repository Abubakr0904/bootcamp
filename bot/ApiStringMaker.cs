using System;
using QuickType;
using bot.Services;
using System.Threading.Tasks;
using System.Text.Json;

namespace bot
{
    public class ApiHelper
    {
        private static string API = "https://api.aladhan.com/v1/timings/123234?latitude=-130&longitude=21&method=14&school=1";
        public static string RequestMaker(double latitude, double longitude)
        {
            var unix = DateTimeHelpers.GetUnixTime(latitude, longitude);

            API = $"https://api.aladhan.com/v1/timings/{unix}?latitude={latitude}&longitude={longitude}&method=14&school=1";
            return API;
            
        }
        public static async Task<string> MessageMakerAsync(double latitude, double longitude)
        {
            
            ApiHelper.RequestMaker(latitude, longitude);
            Console.WriteLine($"{API}");
            
            var httpService = new HttpClientService();
            var json = "";
            Console.WriteLine($" salom");
            var result = await httpService.GetObjectAsync<Root>(API);
            Console.WriteLine($"{result.Data.Data.Timings} MessageMakerga keldi");
            
            
            if(result.IsSuccess)
            {
                var settings = new JsonSerializerOptions()
                {
                    WriteIndented = false
                };

                json +="Prayer times " + JsonSerializer.Serialize(result.Data.Data.Date.Gregorian.ToString(), settings) + "\n";
                Console.WriteLine($"{json}nima gap");
                
                json += "Fajr — " + JsonSerializer.Serialize(result.Data.Data.Timings.Fajr, settings) + "\n";
                json += "Sunrise — " + JsonSerializer.Serialize(result.Data.Data.Timings.Sunrise, settings) + "\n";
                json += "Dhuhr — " + JsonSerializer.Serialize(result.Data.Data.Timings.Dhuhr, settings) + "\n";
                json += "Asr — " + JsonSerializer.Serialize(result.Data.Data.Timings.Asr, settings) + "\n";
                json += "Maghrib — " + JsonSerializer.Serialize(result.Data.Data.Timings.Maghrib, settings) + "\n";
                json += "Isha — " + JsonSerializer.Serialize(result.Data.Data.Timings.Isha, settings) + "\n";
                

                Console.WriteLine($"{json}");
            }
            else
            {
                json = "Error, please try again";
                Console.WriteLine($"{result.ErrorMessage}");
            }
            return json;

        } 
    }
}