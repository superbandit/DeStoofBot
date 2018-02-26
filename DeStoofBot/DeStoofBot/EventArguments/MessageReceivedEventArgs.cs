using System;
using DeStoofBot.Models;

namespace DeStoofBot.EventArguments
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public UserMessage UserMessage { get; set; }

        public MessageReceivedEventArgs(UserMessage message)
        {
            this.UserMessage = message;
        }

    }
}
