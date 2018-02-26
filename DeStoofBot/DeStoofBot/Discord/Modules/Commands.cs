using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace DeStoofBot.Discord.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("commands")]
        public async Task CommandsAsync()
        {
            await ReplyAsync("Ik stuur aleen de twitchchat automatisch op :)");
        }

        [Command("pleh")]
        public async Task PlehAsync()
        {
            await ReplyAsync("Wtf lars...");
        }
    }
}