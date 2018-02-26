using System;
using System.Net;
using System.Threading.Tasks;
using DeStoofBot.Handlers;
using DeStoofBot.UserForm;
using DeStoofBot.EventArguments;
using DeStoofBot.Models;
using Discord.WebSocket;
using Discord;

namespace DeStoofBot.Start
{
    class Program
    {
        static void Main(string[] args)
        {
            new ApplicationHandler();
        }       
    }

    class ApplicationHandler
    {
        IrcHandler ircHandler;
        FrontForm form;
        DiscordHandler discordHandler;

        public ApplicationHandler()
        {
            ircHandler = new IrcHandler();
            ircHandler.MessageReceived += Twitch_MessageReceived;
            ircHandler.MessageReceived += Twitch_CheckForCommands;

            discordHandler = new DiscordHandler();
            discordHandler.RunBotAsync().GetAwaiter().GetResult();
            discordHandler.client.MessageReceived += Discord_MessageReceived;

            form = new FrontForm();
            form.StartConnection += Form_StartConnection;
            form.ShowForm();
        }

        private Task Discord_MessageReceived(SocketMessage arg)
        {
            if (arg.Author.IsBot) return null;
            ircHandler.SendMessage("[" + DateTime.Now.ToShortTimeString() + "] " + ((IGuildUser)arg.Author).Nickname + ": " + arg.ToString());
            form.AddText("[" + DateTime.Now.ToShortTimeString() + "]", true, System.Drawing.Color.Cyan);
            form.AddText(((IGuildUser)arg.Author).Nickname + ": ", false, System.Drawing.Color.Chartreuse);
            form.AddText(arg.ToString(), false, System.Drawing.Color.White);
            return Task.CompletedTask;
        }

        private void Form_StartConnection(object sender, IrcConnectionStartEventArgs args)
        {
            form.AddText("Connecting to: ", true, System.Drawing.Color.White);
            form.AddText(args.Broadcaster, false, System.Drawing.Color.Red);
            try
            {
                ircHandler.StartConnection(args.Broadcaster);
            }
            catch (InvalidOperationException ex)
            {
                form.AddText(ex.Message, true, System.Drawing.Color.Red);
            }

        }

        private void Twitch_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            discordHandler.SendDiscordMessage("[" + DateTime.Now.ToShortTimeString() + "] " +args.UserMessage.User + ": " + args.UserMessage.Message);

            form.AddText("[" + DateTime.Now.ToShortTimeString() + "]", true, System.Drawing.Color.Cyan);
            form.AddText(args.UserMessage.User + ": ", false, System.Drawing.Color.Chartreuse);
            form.AddText(args.UserMessage.Message, false, System.Drawing.Color.White);
        }

        private void Twitch_CheckForCommands(object sender, MessageReceivedEventArgs args)
        {
            UserMessage message = args.UserMessage;

            if(message.Message.ToLower().Contains("!followage"))
            {
                string user = message.User;
                string channel = message.Channel;
                
                using (WebClient client = new WebClient())
                {
                    string s = (client.DownloadString($"https://2g.be/twitch/following.php?user={user}&channel={channel}&format=monthday")) + ".";
                    ircHandler.SendMessage(s);
                }               
            }
        }
    }
}

