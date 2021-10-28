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
                                    new KeyboardButton(){ Text = "En", },
                                    new KeyboardButton(){ Text = "Ru", },
                                }
                            },
                ResizeKeyboard = true
            };
        public static ReplyKeyboardMarkup ChooseNextLanguage()
            => new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = "O'zbekcha" }, 
                                    new KeyboardButton(){ Text = "Русский", },
                                    new KeyboardButton(){ Text = "English", },
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
                menuOption.Add("Сегодняшнее время молитвы");
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
                menuOption.Add("Rad etish");
            }
            else if(language == "En")
            {
                menuOption.Add("Share");
                menuOption.Add("Don't share");
            }
            else if(language == "Ru")
            {
                menuOption.Add("Поделиться");
                menuOption.Add("Не поделиться");
            };
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = menuOption[0], RequestLocation = true },
                                    new KeyboardButton(){ Text = menuOption[1] } 
                                }
                            },
                ResizeKeyboard = true
            };
        }

        public static ReplyKeyboardMarkup ResetLocationButton(string language)
        {
            var menuOption = new List<string>();
            if(language == "Uz")
            {
                menuOption.Add("Ulashish");
                menuOption.Add("Menyuga qaytish");
            }
            else if(language == "En")
            {
                menuOption.Add("Share");
                menuOption.Add("Back to menu");
            }
            else if(language == "Ru")
            {
                menuOption.Add("Поделиться");
                menuOption.Add("Вернутся к меню");
            };
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = menuOption[0], RequestLocation = true },
                                    new KeyboardButton(){ Text = menuOption[1] } 
                                }
                            },
                ResizeKeyboard = true
            };
        }

        public static ReplyKeyboardMarkup Settings(string language)
        {
            var menuOption = new List<string>();
            if(language == "Uz")
            {
                menuOption.Add("Tilni o'zgartirish");
                menuOption.Add("Joylashuvni o'zgartirish");
                menuOption.Add("Eslatmani yoqish/o'chirish");
                menuOption.Add("Menyuga qaytish");
            }
            else if(language == "En")
            {
                menuOption.Add("Change language");
                menuOption.Add("Change Location");
                menuOption.Add("Notification On/Off");
                menuOption.Add("Back to menu");   
            }
            else if(language == "Ru")
            {
                menuOption.Add("Изменить язык");
                menuOption.Add("Изменить геолокация");
                menuOption.Add("Включить/Отключить уведомления");
                menuOption.Add("Вернутся к меню");
            };

            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                            {
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = menuOption[0] },
                                },
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = menuOption[1] },
                                },
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = menuOption[2] }
                                },
                                new List<KeyboardButton>()
                                {
                                    new KeyboardButton(){ Text = menuOption[3] }
                                }
                                
                            },
                ResizeKeyboard = true
            };
        }
    }
}