using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using static Telegram.Bot.Types.Enums.MessageType;
using static Telegram.Bot.Types.Enums.ParseMode;

namespace TelegramBotApi.Models.Commands
{
    public class TestCommand : Command
    {
        public override string CommandName => @"/test";

        public override bool Contains(Message message)
        {
            if (message.Type == Text && message.Text.Contains(CommandName))
                return message.Text.Contains(CommandName);

            return false;
        }

        public override async Task Execute(Message message, TelegramBotClient botClient) => await botClient.SendTextMessageAsync(message.Chat.Id, "Hallo I'm ASP.NET Core Bot", parseMode: Markdown);
    }
}
