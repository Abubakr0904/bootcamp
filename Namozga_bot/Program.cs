using System.ComponentModel.Design.Serialization;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using lesson10.Services;
using System.Linq;
using lesson10.Dto.PrayerTime;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Globalization;
using Namozga_bot;
using RestSharp;


namespace lesson10
{
    public static class Program
    {
        public static string prayerTimeApi = $"http://api.aladhan.com/v1/hijriCalendar?latitude=40&longitude=69&method=2&month=01&year=2021";
        private static TelegramBotClient? Bot;

        [Obsolete]
        static async Task Main(string[] args)
        {
            Bot = new TelegramBotClient("2052009924:AAFupB_U7LO4dXAJjCLoLvqOrCHvWV1dOBs");

            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;
            
            using var cts = new CancellationTokenSource();

            Bot.StartReceiving(new List<UpdateType>() {UpdateType.Message, UpdateType.EditedMessage}.ToArray(), cts.Token);

            Bot.OnMessage += Bot_OnMessage;

            Console.WriteLine($"My First BOT: {me.LastName}");
            Console.ReadLine();
            
        }

        public static string json = "";
        [Obsolete]
        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            
            
            if(e.Message.Type == MessageType.Text)
            {
                Console.WriteLine($"{e.Message.Text} - {e.Message.From.FirstName}");
                var hijriDate = Settings.ConverttoHijri(GoogleTimeZone.GetLocalDateTime(69, 41, DateTime.UtcNow)).ToList();
                
                Settings.SetDateAndPlace(hijriDate, 69, 41);
                var httpService = new HttpClientService();
                var result = await httpService.GetObjectAsync<PrayerTime>(prayerTimeApi);

                if(result.IsSuccess)
                {
                    var settings = new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    };

                    json = JsonSerializer.Serialize(result.Data.data, settings)
                    .Replace("\"", "").Replace("{\n", "").Replace("\n}", "")
                    .Replace(",", "");

                    Console.WriteLine($"{json}");
                }
                else
                {
                    Console.WriteLine($"{result.ErrorMessage}");
                }
                await Bot.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: json             
                );
                
            }
        }
    }
            // var davlat = "";
            // var shahar = "";
            // while (true)
            // {
            //     Console.WriteLine("Qaysi davlatning namoz vaqtlarini bilmoqchisiz?");
            //     davlat = Console.ReadLine();
            //     Console.WriteLine($"{davlat}ning qaysi shahridagi namoz vaqtlari kerak?");
            //     shahar = Console.ReadLine();

            


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
    // }   
}
