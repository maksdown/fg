using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace DushnilkaBot
{
	class Program
	{
		private static string token { get; set; } = "2076772894:AAGxSSoPwEidxLEyqE2kHl4ZuqWVOB6meMc";
		private static TelegramBotClient client;
		static void Main(string[] args)
		{
			client = new TelegramBotClient(token);
			client.StartReceiving();
			client.OnMessage += OnMessaheHandler;
			Console.ReadLine();
			client.StopReceiving();
		}

		private static async void OnMessaheHandler(object sender, MessageEventArgs e)
		{
			var msg = e.Message;
			if (msg.Text != null)
			{
				Console.WriteLine($"Сообщение: {msg.Text}");
				switch (msg.Text)
				{
					case "Стикеры":
						var vid = await client.SendStickerAsync(
							chatId: msg.Chat.Id,
							sticker: "https://cdn.tlgrm.app/stickers/c62/4a8/c624a88d-1fe3-403a-b41a-3cdb9bf05b8a/192/1.webp",
							replyMarkup: GetButtons()) ;
						break;
					case "Ты крокозябра":
						var obz = await client.SendTextMessageAsync(
							chatId: msg.Chat.Id,
							text: "Сам ты такой",
							replyMarkup: GetButtons());
						await client.SendStickerAsync(
							chatId: msg.Chat.Id,
							sticker: "https://cdn.tlgrm.app/stickers/9df/619/9df6199a-ff6a-338d-9f74-625b0a647045/192/12.webp",
							replyMarkup: GetButtons());
						break;

					default:
						break;
				}
			}
		}

		private static IReplyMarkup GetButtons()
		{
			return new ReplyKeyboardMarkup
			{
				Keyboard = new List<List<KeyboardButton>>
				{
					new List<KeyboardButton>{ new KeyboardButton {Text = "Стикеры" } },
					new List<KeyboardButton>{ new KeyboardButton {Text = "Ты крокозябра" } },
				}
			};

		}
	}
}
