using System.Threading;

namespace DeStoofBot.Irc
{
    public class PingSender
    {
        private IrcClient _irc;
        private Thread pingSender;

        public PingSender(IrcClient irc)
        {
            _irc = irc;
            pingSender = new Thread(new ThreadStart(this.Run));
        }

        public void Start()
        {
            pingSender.IsBackground = true;
            pingSender.Start();
        }

        public void Run()
        {
            while (true)
            {
                _irc.SendIrcMessage("PING irc.twitch.tv");
                Thread.Sleep(300000); // 5 minutes
            }
        }
    }
}

