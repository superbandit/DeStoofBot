using System;
using System.ComponentModel;
using DeStoofBot.Models;
using DeStoofBot.Irc;
using DeStoofBot.EventArguments;

namespace DeStoofBot.Handlers
{
    class IrcHandler
    {
        public delegate void MessageReceivedHandler(object sender, MessageReceivedEventArgs args);
        public event MessageReceivedHandler MessageReceived;

        IrcConnection ChatConnection;
        BackgroundWorker BackgroundWorker;

        MessageSplitter MessageSplitter;

        public IrcHandler()
        {
            MessageSplitter = new MessageSplitter();
            ChatConnection = new IrcConnection();
            BackgroundWorker = new BackgroundWorker();

            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.WorkerSupportsCancellation = true;

            BackgroundWorker.DoWork += new DoWorkEventHandler(ChatConnection.GetMessages);
            BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ReceiveMessage);
        }

        public void StartConnection(string broadcastername)
        {
            ChatConnection.Connect(broadcastername);
            BackgroundWorker.RunWorkerAsync();
        }

        public void StopConnection()
        {
            BackgroundWorker.CancelAsync();
            ChatConnection.Disconnect();            
        }

        public void ReceiveMessage(object sender, ProgressChangedEventArgs e)
        {
            string message = (string)e.UserState;
            if (message.Contains("PRIVMSG"))
            {
                UserMessage userMessage = MessageSplitter.Disectmessage((e.UserState) as string);
                MessageReceived(this, new MessageReceivedEventArgs(userMessage));
            }
        }
        public void SendMessage(string message)
        {
            ChatConnection.SendMessage(message);
        }
    }
}
