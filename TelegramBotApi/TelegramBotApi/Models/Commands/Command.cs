using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotApi.Models.Commands
{
    public abstract class Command
    {
        public abstract string CommandName { get; }

        public abstract bool Contains(Message message);

        public abstract Task Execute(Message message, TelegramBotClient client);
    }
}
