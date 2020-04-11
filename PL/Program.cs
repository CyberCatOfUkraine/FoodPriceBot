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
    public class Program
    {
        private static readonly TelegramBotClient _bot = new TelegramBotClient(MainParameter.token);
        private static readonly Products _products = new Products();
        private static MessageEventArgs _e;
        private static readonly Dictionary<string, string> _actions = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            InitializeDictionary();
            _bot.StartReceiving();
            _bot.OnMessage += Bot_OnMessage;
            _bot.OnMessageEdited += Bot_OnMessage;
            CreateHostBuilder(args).Build().Run();
        }

        private static void InitializeDictionary()
        {
            _actions.Add("/grocery", _products.GetGrocery());
            _actions.Add("/canned_food", _products.GetCannedFood());
            _actions.Add("/dairy_products", _products.GetDairyProducts());
            _actions.Add("/meat_products", _products.GetMeatProducts());
            _actions.Add("/drinks", _products.GetDrinks());
            _actions.Add("/fish_and_seafood", _products.GetFishAndSeafood());
            _actions.Add("/sauces_and_spices", _products.GetSaucesAndSpices());
            _actions.Add("/fruits_and_vegetables", _products.GetFruitsAndVegetables());
            _actions.Add("/bakery_products", _products.GetBakeryProducts());
            _actions.Add("/eggs", _products.GetEggs());
            _actions.Add("/start", "Введіть параметр...");
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
            foreach (var (key, value) in _actions)
            {
                if(key == text)
                    SendMessage(value);
            }
            Console.WriteLine(e.Message.Chat.Username + ":" + text);
        }

        private static void SendMessage(string text)
        {
            _bot.SendTextMessageAsync(_e.Message.Chat.Id, text);
        }
    }
}