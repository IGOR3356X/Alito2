using Alito.Classes.Entities.User;
using Alito.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Alito.Classes
{
    internal class BotLogic
    {
        private TelegramBotClient botClient = new TelegramBotClient("6719677792:AAHNkG5A943qr_if48dwEd0sLP8NmLut0zI");

        public BotLogic()
        {
            botClient.StartReceiving(Upd, Error);
        }
        async Task Upd(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;
            var result = update.CallbackQuery;
            if (message != null)
                switch (message.Text)
                {
                    case "/start":
                        if (!JSONHelper.Instanse.IsHaveUser(message.Chat.Id))
                            await client.SendTextMessageAsync(message.Chat.Id,
                                "Введите Имя питомца", cancellationToken: token);
                        else
                            await client.SendTextMessageAsync(message.Chat.Id,
                                "Ты уже зарегистрирован, дурашка", cancellationToken: token);
                        break;

                    case "/help":
                        await client.SendTextMessageAsync(message.Chat.Id,
                            "/home для главного меню", cancellationToken: token);
                        break;

                    case "/home":
                        var inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                            new[] { InlineKeyboardButton.WithCallbackData("Выбор заданий")},
                            new[] { InlineKeyboardButton.WithCallbackData("Магазин")},
                            new[] { InlineKeyboardButton.WithCallbackData("Питомец")},
                            new[] { InlineKeyboardButton.WithCallbackData("Статистика")}
                        });
                        await client.SendTextMessageAsync(message.Chat.Id, "Выбери задания", replyMarkup: inlineKeyboard,
                            cancellationToken: token);
                        break;

                    default:
                        if (!JSONHelper.Instanse.IsHaveUser(message.Chat.Id))
                            JSONHelper.Instanse.AddUser(message.Chat.Id, message.From.Username, message.Text);
                        else
                            await client.SendTextMessageAsync(message.Chat.Id,
                            "/help для просмотра команд", cancellationToken: token);
                        break;
                }
            if (result != null)
                switch (result.Data)
                {
                    case "Выбор заданий":
                        var inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                            new[] { InlineKeyboardButton.WithCallbackData("ОГЭ")},
                            new[] { InlineKeyboardButton.WithCallbackData("ЕГЭ")}
                        });
                        break;
                    case "Магазин":
                        break;
                    case "Питомец":
                        var pet = JSONHelper.Instanse.FindUser(result.From.Id).Pet;
                        await client.SendTextMessageAsync(result.From.Id,
                            $"Информация о питомце:\nИмя: {pet.Name}\nСчастье: {pet.Happy}\nУровень: {pet.Level}\nНеобходимо счастьья для повышения: {pet.NeedHappyToLVL}", cancellationToken: token);
                        break;
                    case "Статистика":
                        var stats = JSONHelper.Instanse.FindUser(result.From.Id).Statistic;
                        break;
                    case "ОГЭ":
                        var user = JSONHelper.Instanse.FindUser(result.From.Id);
                        user._selectedTest = new SelectedTest(0, 0, true);
                        List<InlineKeyboardButton> buttons = new List<InlineKeyboardButton>();
                        foreach (var subject in JSONHelper.Instanse._json.Exams.OGE.Subjects)
                            buttons.Add(new InlineKeyboardButton(subject.Name));
                        var inlineKeyboard2 = new InlineKeyboardMarkup(new[] {  buttons  });

                        await client.SendTextMessageAsync(result.From.Id, "Выбери задания", replyMarkup: inlineKeyboard2,
                            cancellationToken: token);
                        break;
                    case "ЕГЭ":
                        var user2 = JSONHelper.Instanse.FindUser(message.Chat.Id);
                        user2._selectedTest = new SelectedTest(0, 0, false);
                        List<InlineKeyboardButton> buttons2 = new List<InlineKeyboardButton>();
                        foreach (var subject in JSONHelper.Instanse._json.Exams.EGE.Subjects)
                            buttons2.Add(new InlineKeyboardButton(subject.Name));
                        var inlineKeyboard3 = new InlineKeyboardMarkup(new[] { buttons2 });

                        await client.SendTextMessageAsync(result.From.Id, "Выбери задания", replyMarkup: inlineKeyboard3,
                            cancellationToken: token);
                        break;
                    default:
                        var sub = JSONHelper.Instanse.FindSubject(result.Data, 
                            JSONHelper.Instanse.FindUser(result.From.Id)._selectedTest.isOGE);
                        if (sub != null)
                            return;
                        break;
                }
        }

        async Task Error(ITelegramBotClient arg1, Exception exception, CancellationToken arg3)
        {
            MessageBox.Show("Произошла ошибка при работе бота. Подробнее:" + exception.Message.ToString());
        }

    }
}
