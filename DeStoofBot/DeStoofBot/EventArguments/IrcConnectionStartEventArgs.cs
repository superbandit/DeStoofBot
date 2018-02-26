using System;

namespace DeStoofBot.EventArguments
{
    public class IrcConnectionStartEventArgs : EventArgs
    {
        public string Broadcaster { get; set; }

        public IrcConnectionStartEventArgs(string broadcaster)
        {
            this.Broadcaster = broadcaster;
        }

    }
}
