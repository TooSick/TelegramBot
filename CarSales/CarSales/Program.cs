using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace CarSales
{
    class Program
    {
        private static string token { get; set; } = "1883355718:AAE8-4e4PswDnWwDqYdUiRSZ-fr1sFh69II";
        private static TelegramBotClient client;
        private static String img;
        private static String[] urlArr = new String[10];
        private static String href = "https://cars.av.by";
        private static String[] hrefArr = new String[10];

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
                if (msg.Text == "BMW" || msg.Text == "Mercedes-Benz" || msg.Text == "Audi" || msg.Text == "Porsche")
                {
                    switch (msg.Text)
                    {
                        case "BMW":
                            urlArr = CarSales.Parser.Parser.ParsImg("BMW");
                            hrefArr = CarSales.Parser.Parser.ParsHref("BMW");
                            for (int i = 0; i < 10; i++)
                            {
                                img = urlArr[i];
                                href += hrefArr[i];
                                await client.SendPhotoAsync(msg.Chat.Id, photo: img, replyMarkup: GetButtons());
                                await client.SendTextMessageAsync(msg.Chat.Id, href, replyMarkup: GetButtons());
                                href = "https://cars.av.by";
                            }
                            break;
                        case "Mercedes-Benz":
                            urlArr = CarSales.Parser.Parser.ParsImg("Mercedes-Benz");
                            for (int i = 0; i < 10; i++)
                            {
                                img = urlArr[i];
                                await client.SendPhotoAsync(msg.Chat.Id, photo: img, replyMarkup: GetButtons());
                            }
                            break;
                        case "Audi":
                            urlArr = CarSales.Parser.Parser.ParsImg("Audi");
                            for (int i = 0; i < 10; i++)
                            {
                                img = urlArr[i];
                                await client.SendPhotoAsync(msg.Chat.Id, photo: img, replyMarkup: GetButtons());
                            }
                            break;
                        case "Porsche":
                            urlArr = CarSales.Parser.Parser.ParsImg("Porsche");
                            for (int i = 0; i < 10; i++)
                            {
                                img = urlArr[i];
                                await client.SendPhotoAsync(msg.Chat.Id, photo: img, replyMarkup: GetButtons());
                            }
                            break;
                    }
                    //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GetButtons());
                }
                else
                    await client.SendTextMessageAsync(msg.Chat.Id, "Такой команды не существует", replyMarkup: GetButtons());

            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "BMW" }, new KeyboardButton { Text = "Mercedes-Benz" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Audi"}, new KeyboardButton { Text = "Porsche" } }
                }
            };
        }
    }
}
