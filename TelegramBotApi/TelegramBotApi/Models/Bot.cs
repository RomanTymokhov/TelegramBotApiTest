using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotApi.Models.Commands;

namespace TelegramBotApi.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>
            {
                new TestCommand()
                //TODO: Add more commands
            };

            botClient = new TelegramBotClient(BotSettings.Key);
            await botClient.SetWebhookAsync(string.Format(BotSettings.Url, "api/message/update"));
            return botClient;
        }
    }
}
