using System.Net.Http;
using System;
using lesson10.Services;

namespace abdulrcsApi
{

    class Program
    {
        public static string prayerTime = "https://muslimsalat.com/city.json?key=api_key";

        static void Main(string[] args)
        {
            var city = Console.ReadLine();
            Helpers.ChoosePlace(city);

            var result = new HttpClient()
        }
    }
}
