using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
// using bot.Services;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace bot
{
    public class Handlers
    {
        private static float _longitude;
        private static float _latitude;
        private static ILogger<Handlers> _logger;
        // private readonly IStorageService _storage;
        public Handlers(ILogger<Handlers> logger)
        {
            _logger = logger;
            // _storage = storage;
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
                UpdateType.Message => BotOnMessageReceived(client, update.Message, new MessageBuilder()),
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
            catch (Exception e)
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

        private async Task BotOnMessageReceived(ITelegramBotClient client, Message message, MessageBuilder messageBuilder)
        {
                if(message.Location != null)
                {
                    
                    _longitude = message.Location.Longitude;
                    _latitude = message.Location.Latitude;
                    Console.WriteLine($"{_latitude} {_longitude}");
                }
                Console.WriteLine($"{message.Text}");

                var a = await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: message.Text switch
                    {
                        "/start"            =>      "Assalamu alaykum\nTo provide the correct prayer times in your timezone, we need your location. \nCan you share it?",
                        "Reset Location"            =>      "Turn on the geolocation on your device",
                        "Settings"                  =>      "Settings",
                        "Cancel"                    =>      "Menu",
                        "Menu"                      =>      "Menu",
                        "Share"                     =>      "Share Location",
                        "Notification on/off"       =>      "Choose notification settings",
                        "Today's Prayer Times"      =>      MessageBuilder.DailyPrayerTimes(),

                        _                           =>      ""
                    },
                    // text: "Share location",
                    // parseMode: ParseMode.Markdown,
                    replyMarkup: message.Text switch
                    {
                        "/start"            =>      MessageBuilder.LocationRequestButton(),
                        "Reset Location"    =>      MessageBuilder.LocationRequestButton(),
                        "Settings"          =>      MessageBuilder.Settings(),
                        "Cancel"            =>      MessageBuilder.Menu(),
                        "Menu"              =>      MessageBuilder.Menu(),
                        "Back To Menu"      =>      MessageBuilder.Menu(),
                        "Share"             =>      MessageBuilder.Menu(),
                        "Don't share"       =>      MessageBuilder.NotShare(),
                        "Notification on/off"=>     MessageBuilder.NotificationOnOff(),
                        _                   =>      MessageBuilder.Menu(),
                    }
                );

            
            // switch(message.Text)
            // {
            //     case "/start": 
            //         break;
            // }

        }

        
    }
}