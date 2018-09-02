using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotApi.Models;

namespace TelegramBotApi.Controllers
{
    [Route("api/message/update")]
    public class MessageController : ControllerBase
    {
        //// GET api/values
        //[HttpGet]
        //public string Get()
        //{
        //    return "Method GET unuvalable";
        //}
        //// ...

        // POST api/values
        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in Bot.Commands)
            {
                if (command.Contains(update.Message))
                {
                    await command.Execute(update.Message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}
