using System;
using DAL;
using Parameters;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace FoodPriceBot
{
    class Program
    {
        private static TelegramBotClient _bot=new TelegramBotClient(MainParameter.token);
        private static Products _products=new Products();
        private static MessageEventArgs _e;
        static void Main(string[] args)
        {
            _bot.StartReceiving();
            _bot.OnMessage += Bot_OnMessage;
            _bot.OnMessageEdited += Bot_OnMessage;
            Console.ReadKey();
            _bot.StopReceiving();
        }

        private static void Bot_OnMessage(object? sender, MessageEventArgs e)
        {
            _e = e;
            var text = e.Message.Text;
            switch (text)
            {
                case  "/grocery":sendMessage(_products.GetGrocery()); break;
                case  "/canned_food":sendMessage(_products.GetCannedFood()); break;
                case  "/dairy_products":sendMessage(_products.GetDairyProducts()); break;
                case  "/meat_products":sendMessage(_products.GetMeatProducts()); break;
                case  "/drinks":sendMessage(_products.GetDrinks()); break;
                case  "/fish_and_seafood":sendMessage(_products.GetFishAndSeafood()); break;
                case  "/sauces_and_spices":sendMessage(_products.GetSaucesAndSpices()); break;
                case  "/fruits_and_vegetables":sendMessage(_products.GetFruitsAndVegetables()); break;
                case  "/bakery_products":sendMessage(_products.GetBakeryProducts()); break;
                case  "/eggs":sendMessage(_products.GetEggs()); break;
                default: sendMessage("Команда не розпізнана, повторіть спробу");break;
            }

            Console.WriteLine(e.Message.Chat.Username+":"+ text);
        }
        private static void sendMessage(string text)
        {
            _bot.SendTextMessageAsync(_e.Message.Chat.Id, text);
        }
    }
}