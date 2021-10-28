using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using bot.Entity;
using bot.HttpClients;
using bot.Services;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using bot.Extensions;

namespace bot
{
    public class Handlers
    {
        private readonly ILogger<Handlers> _logger;
        private readonly IStorageService _storage;
        private readonly ICacheService _cache;
        private readonly double _latitude;
        private readonly double _longitude;
        public Handlers(ILogger<Handlers> logger, IStorageService storage, ICacheService cache)
        {
            _logger = logger;
            _storage = storage;
            _cache = cache;
        }

        public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken ctoken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException => $"Error occured with Telegram Client: {exception.Message}",
                _ => exception.Message
            };

            _logger.LogCritical(errorMessage);

            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken ctoken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(client, update.Message),
                UpdateType.EditedMessage => BotOnMessageEdited(client, update.EditedMessage),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(client, update.CallbackQuery),
                UpdateType.InlineQuery => BotOnInlineQueryReceived(client, update.InlineQuery),
                UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(client, update.ChosenInlineResult),
                _ => UnknownUpdateHandlerAsync(client, update)
            };

            try
            {
                await handler;
            }
            catch(Exception e)
            {

            }
        }

                        
        private async Task BotOnMessageEdited(ITelegramBotClient client, Message editedMessage)
        {
            // throw new NotImplementedException();
        }

        private async Task UnknownUpdateHandlerAsync(ITelegramBotClient client, Update update)
        {
            // throw new NotImplementedException();
        }

        private async Task BotOnChosenInlineResultReceived(ITelegramBotClient client, ChosenInlineResult chosenInlineResult)
        {
            // throw new NotImplementedException();
        }

        private async Task BotOnInlineQueryReceived(ITelegramBotClient client, InlineQuery inlineQuery)
        {
            // throw new NotImplementedException();
        }

        private async Task BotOnCallbackQueryReceived(ITelegramBotClient client, CallbackQuery callbackQuery)
        {
            // throw new NotImplementedException();
        }

        private async Task BotOnMessageReceived(ITelegramBotClient client, Message message)
        {
            var language = "";
            if(await _storage.ExistsAsync(message.Chat.Id))
            {
                var user12313 = await _storage.GetUserAsync(message.Chat.Id);
                language = user12313.Language;

            }
            if(message.Location != null && message.Type == MessageType.Location)
            {
                var user = new BotUser(
                    chatId: message.Chat.Id,
                    username: message.From.Username,
                    fullname: $"{message.From.FirstName} {message.From.LastName}",
                    longitude: message.Location.Longitude,
                    latitude: message.Location.Latitude,
                    address: string.Empty,
                    language: _storage.GetUserAsync(message.Chat.Id).Result.Language,
                    notification: _storage.GetUserAsync(message.Chat.Id).Result.NotificationSetting);
                
                var result = await _storage.UpdateUserAsync(user);
                if(result.IsSuccess)
                {
                    _logger.LogInformation($"User's location has been updated successfully : {message.Chat.Id}:{message.Location.Latitude}:{message.Location.Longitude}");
                    _logger.LogInformation($"User's location in database : {_storage.GetUserAsync(message.Chat.Id).Result.Latitude}:{_storage.GetUserAsync(message.Chat.Id).Result.Longitude}:{message.Chat.Id}");
                }
                else
                {
                    _logger.LogInformation($"User's location in database : {_storage.GetUserAsync(message.Chat.Id).Result.Latitude}:{_storage.GetUserAsync(message.Chat.Id).Result.Longitude}:{message.Chat.Id}");
                    _logger.LogWarning("Location didn't change");
                    _logger.LogWarning(result.exception.ToString());
                }
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    parseMode: ParseMode.Markdown,
                    text: _storage.GetUserAsync(message.Chat.Id).Result.Language switch
                    {
                        "En" => "Your location has been updated successfully",
                        "Ru" => "Ваше местоположение было успешно обновлено",
                        "Uz" => "Joylashuvingiz muvaffaqqiyatli yangilandi",
                        _    => "Error, please restart the bot"
                    },
                    replyMarkup: MessageBuilder.Menu(language));
                await client.DeleteMessageAsync(
                    chatId: message.Chat.Id,
                    messageId: message.MessageId);
                
                
                // _storage.UpdateUserAsync()
            }
            else
            {
                switch(message.Text)
                {
                    case "/start":
                    {
                        if(!await _storage.ExistsAsync(message.Chat.Id))
                        {
                            var userstart = new BotUser(
                                chatId: message.Chat.Id,
                                username: message.From.Username,
                                fullname: $"{message.From.FirstName} {message.From.LastName}",
                                longitude: 400,
                                latitude: 400,
                                address: string.Empty,
                                language: string.Empty,
                                notification: true);

                            var result = await _storage.InsertUserAsync(userstart);

                            if(result.IsSuccess)
                            {
                                _logger.LogInformation($"New user added: {message.Chat.Id}");
                            }
                        }
                        else
                        {
                            _logger.LogInformation($"User exists");
                        }
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "Tilni tanlang\nChoose language\nВыберите язык",
                            replyMarkup: MessageBuilder.ChooseLanguage());
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    } 
                    case "En":
                    case "Ru":
                    case "Uz":
                    {
                        var initUser = await _storage.GetUserAsync(message.Chat.Id);
                        initUser.Language = message.Text;
                        await _storage.UpdateUserAsync(initUser);

                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: initUser.Language switch
                                    {
                                        "En" => "In order I provide the proper prayer times for you, you should share your current location",
                                        "Ru" => "Для представления точного времени молитвы, введите текущее местоположение",
                                        "Uz" => "Namoz vaqtlari to'g'ri ko'rsatishi uchun joriy joylashuvingizni yuboring",
                                        _    => "Problem with language. Try again"
                                    },
                            replyMarkup: MessageBuilder.LocationRequestButton(initUser.Language)
                            );
                        break;
                    }
                    case "English":
                    case "O'zbekcha":
                    case "Русский":
                    {
                        var langUser =  _storage.GetUserAsync(message.Chat.Id).Result;
                        if(message.Text == "English")
                        {
                            langUser.Language = "En";
                        }
                        else if(message.Text == "O'zbekcha")
                        {
                            langUser.Language = "Uz";
                        }
                        else if(message.Text == "Русский")
                        {
                            langUser.Language = "Ru";
                        }
                        else
                        {
                            _logger.LogWarning($"Error in choosing language");
                        }
                        await _storage.UpdateUserAsync(langUser);
                        
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: langUser.Language switch
                                {
                                    "En" => "Language updated successfully",
                                    "Ru" => "Язык успешно обновлен",
                                    "Uz" => "Til muvaffaqiyatli yangilandi",
                                    _    => "Problem with language. Try again"
                                },
                            replyMarkup: MessageBuilder.Menu(langUser.Language)
                            );
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    case "Don't share":
                    case "Не поделиться":
                    case "Rad etish":
                    {
                        var shareUser = await _storage.GetUserAsync(message.Chat.Id);
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: shareUser.Language switch
                            {
                                "En" => "When you need the prayer times, you can share your location",
                                "Uz" => "Namoz vaqtlarini bilish uchun joylashuvingizni kiritishingiz kerak",
                                "Ru" => "Для представлнния времени молитвы, необходимо ввести местоположение",
                                _    => "Problem with language. Try again"
                            },
                            replyMarkup: MessageBuilder.LocationRequestButton(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    
                    case "Today's prayer times":
                    case "Bugungi namoz vaqtlari":
                    case "Сегодняшнее время молитвы":
                    {
                        var prayerTime = _cache.GetOrUpdatePrayerTimeAsync(
                            message.Chat.Id,
                            _storage.GetUserAsync(message.Chat.Id).Result.Latitude,
                            _storage.GetUserAsync(message.Chat.Id).Result.Longitude);
                            var json = prayerTime.Result.prayerTime;

                        _logger.LogInformation(JsonSerializer.Serialize(prayerTime.Result.prayerTime));
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: json.TimeToString(language),
                            replyMarkup: MessageBuilder.Menu(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    
                    case "Settings":
                    case "Настройки":
                    case "Sozlamalar":
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: language switch
                            {
                                "En" => "Settings",
                                "Ru" => "Настройки",
                                "Uz" => "Sozlamalar",
                                _    => "*Use only buttons*"
                            },
                            replyMarkup: MessageBuilder.Settings(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    case "Change Location":
                    case "Изменить геолокация":
                    case "Joylashuvni o'zgartirish":
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: language switch
                            {
                                "En" => "Reset Location",
                                "Ru" => "Изменить геолокация",
                                "Uz" => "Joylashuvni o'zgartirish",
                                _    => "*En/Ru/Uz*"
                            },
                            replyMarkup: MessageBuilder.ResetLocationButton(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    
                    case "Notification on/off":
                    case "Включить/Отключить уведомления":
                    case "Eslatmani yoqish/o'chirish":
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text:   _notificationMessageMaker(_storage.UpdateNotificationSettingAsync(
                                    _storage.GetUserAsync(message.Chat.Id).Result
                                    ).Result.status,
                                    language
                                    ),
                            replyMarkup: MessageBuilder.Menu(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    case "Back to menu":
                    case "Menyuga qaytish":
                    case "Вернутся к меню":
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: language switch
                            {
                                "En" => "Menu",
                                "Ru" => "Меню",
                                "Uz" => "Menyu",
                                _    => "*Use only buttons*"
                            },
                            replyMarkup: MessageBuilder.Menu(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    case "Tilni o'zgartirish":
                    case "Change language":
                    case "Изменить язык":
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: language switch
                            {
                                "En" => "Choose language",
                                "Ru" => "Выберите язык",
                                "Uz" => "Tilni tanlang",
                                _    => "*Use only buttons*"
                            },
                            replyMarkup: MessageBuilder.ChooseNextLanguage());
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    }
                    default: 
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: language switch
                            {
                                "En" => "Invalid command!\nPlease, restart the bot",
                                "Ru" => "Неравильная команда!\nПожалуйста, перезапустите бота",
                                "Uz" => "Noto'g'ri buyruq!\nIltimos, botni qaytadan yurgizing",
                                _    => "*Error in default*"
                            });
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        System.Console.WriteLine("Invalid command");break;
                }
            }
        }

        private string _notificationMessageMaker(bool status, string language)
        {
            if(language == "Uz")
            {
                if(status)
                {
                    return "Eslatma yoqildi";
                }
                else
                {
                    return "Eslatma o'chirildi";
                }
            }
            else if(language == "Ru")
            {
                if(status)
                {
                    return "Уведомление включено";
                }
                else
                {
                    return "Уведомление выключено";
                }
            }
            else if(language == "Ru")
            {
                if(status)
                {
                    return "Уведомление включено";
                }
                else
                {
                    return "Уведомление выключено";
                }
            }
            return "Error, please use only buttons";
        }
    }
}