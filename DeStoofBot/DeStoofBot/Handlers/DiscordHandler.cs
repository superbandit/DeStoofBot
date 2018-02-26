using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace DeStoofBot.Handlers
{
    class DiscordHandler
    {
        public DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;
        
        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();

            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();

            string botToken = "NDE2Njk4NTk3OTIxNTIxNjc1.DXIQjw.MQ5hZ4b3GV4St1mDEM-573tnUF4";

            //event subscriptions
            client.Log += Log;

            await RegisterCommandsAsync();
            await client.LoginAsync(TokenType.Bot, botToken);
            await client.StartAsync();
            //await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Debug.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;

            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            SocketUserMessage message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix("!", ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                SocketCommandContext context = new SocketCommandContext(client, message);

                var result = await commands.ExecuteAsync(context, argPos, services);
                if (!result.IsSuccess)
                {
                    Debug.WriteLine(result.ErrorReason);
                }
            }
        }

        public async void SendDiscordMessage(string message)
        {
            SocketTextChannel channel = client.GetChannel(416714064283303956) as SocketTextChannel;
            await channel.SendMessageAsync(message);
        }
    }
}
