using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
// using bot.Services;
using bot.Entity;

namespace bot
{
    class Program
    {
        static Task Main(string[] args)
            => CreateHostBuilder(args)
                .Build()
                .RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureServices(Configure);

        private static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<TelegramBotClient>(b => new TelegramBotClient("2052009924:AAFupB_U7LO4dXAJjCLoLvqOrCHvWV1dOBs"));
            services.AddHostedService<Bot>();
            // services.AddTransient<IStorageService, InternalStorageService>();
            services.AddTransient<Handlers>();
            // services.AddTransient<BotUser>();
            // services.AddTransient<IStorageService, DbStorageService>();
        }
    }
}
