using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DeStoofBot.Irc
{
    public class IrcConnection
    {
        private IrcClient irc;
        private PingSender ping;

        private static string botName = "DeStoofBot";
        private static string twitchOAuth = "oauth:md7lxoimmj5x7fc3zoi3ev7i5ii0pg";

        private bool active = true;

        public IrcConnection()
        {

        }

        public void Connect(string broadcasterName)
        {
            irc = new IrcClient("irc.twitch.tv", 6667, botName, twitchOAuth, broadcasterName);
            ping = new PingSender(irc);
            ping.Start();
        }

        public void Disconnect()
        {
            active = false;
            ping.Stop();
            irc.Disconnect();
        }

        public void GetMessages(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {             
                string message = irc.ReadMessage();
                worker.ReportProgress(0, message);
            }
        }
        public void SendMessage(string message)
        {
            if(irc != null)
                irc.SendPublicChatMessage(message);
        }
    }
}
