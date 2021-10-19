using System;
using System.Text.Json;
using System.Threading.Tasks;
using lesson10.Dto.PrayerTime;
using System.Collections.Generic;
using lesson10.Dto.User;
using lesson10.Services;
using System.Linq;

namespace lesson10
{
    class Program
    {


        public static string usersApi = "https://randomuser.me/api/";
        static async Task Main(string[] args)
        {
            var davlat = "";
            var shahar = "";
            while (true)
            {
                Console.WriteLine("Qaysi davlatning namoz vaqtlarini bilmoqchisiz?");
                davlat = Console.ReadLine();
                Console.WriteLine($"{davlat}ning qaysi shahridagi namoz vaqtlari kerak?");
                shahar = Console.ReadLine();

                string prayerTimeApi = $"http://api.aladhan.com/v1/timingsByCity?city={shahar}&country={davlat}&method=8";
            
                var httpService = new HttpClientService();
                var result = await httpService.GetObjectAsync<PrayerTime>(prayerTimeApi);

                if(result.IsSuccess)
                {
                    var settings = new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    };

                    var json = JsonSerializer.Serialize(result.Data.Data.Timings, settings)
                    .Replace("\"", "").Replace("{\n", "").Replace("\n}", "")
                    .Replace(",", "");

                    Console.WriteLine($"{json}");
                    
                    
                    // var dictionary = Program.StrToDict(json);

                    // PrintDict(dictionary);
                }
                else
                {
                    Console.WriteLine($"{result.ErrorMessage}");
                }
            }
        }

        // public static void PrintDict<K, V>(Dictionary<K, V> dict)
        // {
        //     foreach (KeyValuePair<K, V> entry in dict) {
        //         Console.WriteLine(entry.Key + "time : " + entry.Value);
        //     }
        // }

        // public static Dictionary<string, string> StrToDict(string str)
        // {
        //     var dict = new Dictionary<string, string>();
        //     var first = 0; 
        //     for(int i = 0; i < str.Length; i++)
        //     {
        //         var key = "";
        //         var value = "";
        //         if(str[i] == ':' && str[i+3] != ',')
        //         {
        //             key = str.Substring(first, i-1);
        //             first = i+1;
        //         }
        //         else if(str[i] == ',')
        //         {
        //             value = str.Substring(i-5, i-1);
        //             first = i+1;
        //         }
        //         dict.Add(key, value);
        //     }

        //     return dict;
        // } 
    }
}
