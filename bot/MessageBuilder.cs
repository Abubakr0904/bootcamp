using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
namespace bot
{
    public class MessageBuilder
    {
        public static ReplyKeyboardMarkup ChooseLanguage()
            => new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = "Uz" }, 
                                },
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = "En", },
                                    new KeyboardButton(){ Text = "Ru", },
                                }
                            },
                ResizeKeyboard = true
            };
        public static ReplyKeyboardMarkup Menu(string language)
        {
            var menuOption = new List<string>();
            if(language == "Uz")
            {
                menuOption.Add("Bugungi namoz vaqtlari");
                menuOption.Add("Sozlamalar");
            }
            else if(language == "En")
            {
                menuOption.Add("Today's prayer times");
                menuOption.Add("Settings");
            }
            else if(language == "Ru")
            {
                menuOption.Add("сегодняшнее время молитвы");
                menuOption.Add("Настройки");
            };
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = menuOption[0] }, 
                                    new KeyboardButton(){ Text = menuOption[1], },
                                }
                            },
                ResizeKeyboard = true
            };
        }

        public static ReplyKeyboardMarkup LocationRequestButton(string language)
        {
            var menuOption = new List<string>();
            if(language == "Uz")
            {
                menuOption.Add("Ulashish");
                menuOption.Add("Menyuga qaytish");
            }
            else if(language == "En")
            {
                menuOption.Add("Today's prayer times");
                menuOption.Add("Settings");
            }
            else if(language == "Ru")
            {
                menuOption.Add("сегодняшнее время молитвы");
                menuOption.Add("Настройки");
            };
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = str1, RequestLocation = true },
                                    new KeyboardButton(){ Text = str2 } 
                                }
                            },
                ResizeKeyboard = true
            };
        }
        public static ReplyKeyboardMarkup Settings()
        => new ReplyKeyboardMarkup()
        {
            Keyboard = new List<List<KeyboardButton>>()
                        {
                            new List<KeyboardButton>()
                            {
                                new KeyboardButton(){ Text = "Reset Location", RequestLocation = true },
                                new KeyboardButton(){ Text = "Notification on/off" }
                            },
                            new List<KeyboardButton>()
                            {
                                new KeyboardButton(){ Text = "Back to menu" }
                            }
                        },
            ResizeKeyboard = true
        };

        // public static ReplyKeyboardMarkup NotificationOnOff()
        // => new ReplyKeyboardMarkup()
        // {
        //     Keyboard = new List<List<KeyboardButton>>()
        //                 {
        //                     new List<KeyboardButton>()
        //                     {
        //                         new KeyboardButton(){ Text = "On", RequestLocation = true },
        //                         new KeyboardButton(){ Text = "Off" }
        //                     },
        //                 },
        //     ResizeKeyboard = true
        // };
        

        public static string DailyPrayerTimes(double latitude, double longitude)
        {            
            return "prayer times";
        }

        // public static ReplyKeyboardMarkup NotShare()
        // => new ReplyKeyboardMarkup()
        // {
        //     Keyboard = new List<List<KeyboardButton>>()
        //                 {
        //                     new List<KeyboardButton>()
        //                     {
        //                         new KeyboardButton(){ Text = "Restart" }
        //                     }
        //                 },
        //     ResizeKeyboard = true
        // };
    }
}