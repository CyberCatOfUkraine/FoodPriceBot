using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parameters;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace PL
{
    public static class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient(MainParameter.token);
        private static readonly Products Products = new Products();
        private static MessageEventArgs _e;
        private static readonly Dictionary<string, string> Actions = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            InitializeDictionary();
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessage;
            CreateHostBuilder(args).Build().Run();
        }

        private static void InitializeDictionary()
        {
            Actions.Add("/grocery", Products.GetGrocery());
            Actions.Add("/canned_food", Products.GetCannedFood());
            Actions.Add("/dairy_products", Products.GetDairyProducts());
            Actions.Add("/meat_products", Products.GetMeatProducts());
            Actions.Add("/drinks", Products.GetDrinks());
            Actions.Add("/fish_and_seafood", Products.GetFishAndSeafood());
            Actions.Add("/sauces_and_spices", Products.GetSaucesAndSpices());
            Actions.Add("/fruits_and_vegetables", Products.GetFruitsAndVegetables());
            Actions.Add("/bakery_products", Products.GetBakeryProducts());
            Actions.Add("/eggs", Products.GetEggs());
            Actions.Add("/start", "Введіть параметр...");
        }
        
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => { services.AddHostedService<Worker>(); });
        }

        private static void Bot_OnMessage(object? sender, MessageEventArgs e)
        {
            _e = e;
            var text = _e.Message.Text;
            foreach (var (key, value) in Actions)
            {
                if(key == text)
                    SendMessage(value);
            }
            Console.WriteLine(e.Message.Chat.Username + ":" + text);
        }

        private static void SendMessage(string text)
        {
            Bot.SendTextMessageAsync(_e.Message.Chat.Id, text);
        }
    }
}