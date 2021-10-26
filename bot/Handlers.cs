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

namespace bot
{
    public class Handlers
    {
        private readonly ILogger<Handlers> _logger;
        private readonly IStorageService _storage;
        private readonly double _latitude;
        private readonly double _longitude;
        private readonly IPrayerTimeService _prayerTimeClient;

        public Handlers(ILogger<Handlers> logger, IStorageService storage, IPrayerTimeService prayerTimeClient)
        {
            _logger = logger;
            _storage = storage;
            _prayerTimeClient = prayerTimeClient;
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
            if(message.Location != null)
            {
                var user = new BotUser(
                    chatId: message.Chat.Id,
                    username: message.From.Username,
                    fullname: $"{message.From.FirstName} {message.From.LastName}",
                    longitude: message.Location.Longitude,
                    latitude: message.Location.Latitude,
                    address: string.Empty);
                
                var result = await _storage.UpdateUserAsync(user);
                if(result.IsSuccess)
                {
                    _logger.LogInformation($"User's location has been updated successfully : {message.Chat.Id}");
                }
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    parseMode: ParseMode.Markdown,
                    text: "Your location has been updated successfully",
                    replyMarkup: MessageBuilder.Menu());
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
                            text: "In order I provide the proper prayer times for you, you should share your current location",
                            replyMarkup: MessageBuilder.LocationRequestButton());
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Don't share":
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "When you need the prayer times, you can share your location",
                            replyMarkup: MessageBuilder.LocationRequestButton());
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Today's Prayer Times":
                        var prayerTime = _prayerTimeClient.GetPrayerTimeAsync(
                            _storage.GetUserAsync(message.Chat.Id).Result.Latitude,
                            _storage.GetUserAsync(message.Chat.Id).Result.Latitude);
                            var json = prayerTime.Result.prayerTime;

                        _logger.LogInformation(JsonSerializer.Serialize(prayerTime.Result.prayerTime));
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: $@"*Prayer Times*: {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}
*Fajr*:               {json.Fajr}
*Sunrise*:        {json.Sunrise}
*Dhuhr*:           {json.Dhuhr}
*Asr*:                {json.Asr}
*Maghrib*:       {json.Maghrib}
*Isha*:              {json.Isha}

*Calculation Method*: {json.CalculationMethod}
                            ",
                            replyMarkup: MessageBuilder.Menu());
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
                            replyMarkup: MessageBuilder.LocationRequestButton());
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
                            replyMarkup: MessageBuilder.Menu());
                        await client.DeleteMessageAsync(
                            chatId: message.Chat.Id,
                            messageId: message.MessageId);
                        break;
                    case "Back to menu":
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            parseMode: ParseMode.Markdown,
                            text: "Menu",
                            replyMarkup: MessageBuilder.Menu());
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