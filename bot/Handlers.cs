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
            throw new NotImplementedException();
        }

        private async Task UnknownUpdateHandlerAsync(ITelegramBotClient client, Update update)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnChosenInlineResultReceived(ITelegramBotClient client, ChosenInlineResult chosenInlineResult)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnInlineQueryReceived(ITelegramBotClient client, InlineQuery inlineQuery)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnCallbackQueryReceived(ITelegramBotClient client, CallbackQuery callbackQuery)
        {
            throw new NotImplementedException();
        }

        private async Task BotOnMessageReceived(ITelegramBotClient client, Message message)
        {
            BotUser user;
            string language;
            if(await _storage.ExistsAsync(message.Chat.Id))
            {
                user = _storage.GetUserAsync(message.Chat.Id).Result;
                language = _storage.GetUserAsync(message.Chat.Id).Result.Language;
            }
            if(message.Location != null && message.Type == MessageType.Location)
            {
                    user = new BotUser(
                    chatId: message.Chat.Id,
                    username: message.From.Username,
                    fullname: $"{message.From.FirstName} {message.From.LastName}",
                    longitude: message.Location.Longitude,
                    latitude: message.Location.Latitude,
                    address: string.Empty);
                    language: _storage.GetUserAsync(message.Chat.Id).Result.Language;
                    );
                var result = await _storage.UpdateUserAsync(user);
                
                if(result.IsSuccess)
                {
                    _logger.LogInformation($"User's location has been updated successfully : {message.Chat.Id}");
                }
                else
                {
                    _logger.LogCritical($"Error occured with location update : {message.Chat.Id}");
                }
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    parseMode: ParseMode.Markdown,
                    text: user.Language switch
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
                        if(!await _storage.ExistsAsync(message.Chat.Id))
                        {
                                var user = new BotUser(
                                chatId: message.Chat.Id,
                                username: message.From.Username,
                                fullname: $"{message.From.FirstName} {message.From.LastName}",
                                longitude: 0,
                                latitude: 0,
                                address: string.Empty);

                            var result = await _storage.InsertUserAsync(user);

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
                    case "En":
                        user =_storage.GetUserAsync(message.Chat.Id).Result;
                        user.Language = "En";
                        await _storage.UpdateUserAsync(user);
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "In order I provide the proper prayer times for you, you should share your current location",
                            replyMarkup: MessageBuilder.LocationRequestButton("Share", "Don't share"));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Ru":
                        user.Language = "Ru";
                        await _storage.UpdateUserAsync(user);
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "Чтобы я указал вам правильное время молитвы, вы должны сообщить свое текущее местоположение",
                            replyMarkup: MessageBuilder.LocationRequestButton(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Uz":
                        user =_storage.GetUserAsync(message.Chat.Id).Result;
                        user.Language = "Uz";
                        await _storage.UpdateUserAsync(user);
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "Namoz vaqtlari to'g'ri ko'rsatishi uchun joriy joylashuvingizni yuboring",
                            replyMarkup: MessageBuilder.LocationRequestButton("Uz"));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;

                        
                    case "Don't share":
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "When you need the prayer times, you can share your location",
                            replyMarkup: MessageBuilder.LocationRequestButton(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Today's Prayer Times":
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
                            replyMarkup: MessageBuilder.Menu(language switch
                            {
                                
                            }));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Settings":
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "Settings",
                            replyMarkup: MessageBuilder.Settings());
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Reset Location":
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "Settings",
                            replyMarkup: MessageBuilder.LocationRequestButton(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Notification on/off":
                        
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text:  _storage.UpdateNotificationSettingAsync(
                            _storage.GetUserAsync(message.Chat.Id).Result
                            ).Result.status
                                ? "Notification is now on" 
                                : "Notification is now off",
                            replyMarkup: MessageBuilder.Menu(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Back to menu":
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "Menu",
                            replyMarkup: MessageBuilder.Menu(language));
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    default: System.Console.WriteLine("Invalid command");break;
                }
            }
        }
    }
}