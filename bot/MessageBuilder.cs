using System;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
namespace bot
{
    public class MessageBuilder
    {
        public static ReplyKeyboardMarkup Menu()
            => new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = "Today's Prayer Times" }, 
                                    new KeyboardButton(){ Text = "Settings", },
                                }
                            },
                ResizeKeyboard = true
            };

        public static ReplyKeyboardMarkup LocationRequestButton()
            => new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = "Share", RequestLocation = true },
                                    new KeyboardButton(){ Text = "Don't share" } 
                                }
                            },
                ResizeKeyboard = true
            };

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