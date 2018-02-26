using System;
using System.Diagnostics;
using DeStoofBot.Models;

namespace DeStoofBot.Irc
{
    class MessageSplitter
    {
        // :destoofpot!destoofpot@destoofpot.tmi.twitch.tv PRIVMSG #destoofpot :test
        public UserMessage Disectmessage(string message)
        {
            UserMessage userMessage = new UserMessage();
            string[] components = message.Split(' ');
            string[] information =  components[0].Split('!');
            userMessage.Channel = components[2].Substring(1);
            userMessage.User = information[0].Substring(1);
            userMessage.Message = string.Join(" ", components, 3, components.Length - 3).Substring(1);

            return userMessage;
        }
    }
}
