using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using DeStoofBot.EventArguments;

namespace DeStoofBot.UserForm
{
    public partial class FrontForm : Form
    {
        public delegate void StartConnectionHandler(object sender, IrcConnectionStartEventArgs args);
        public event StartConnectionHandler StartConnection;

        private static string broadcasterName = "destoofpot";

        public FrontForm()
        {
            InitializeComponent();
            Chat.ForeColor = Color.Empty;
            StartBackend.Text = "Connect to " + broadcasterName;
        }

        public void ShowForm()
        {
            ShowDialog();
        }

        public void AddText(string text, bool newLine, Color color)
        {
            if (Chat.Text.Length > 2)
            {
                Chat.Select(Chat.Text.Length - 2, 2);
                Chat.SelectedText = " ";
            }
                
            int start = Chat.TextLength;
            Chat.AppendText(newLine? "\n" + text + "\n\n" : text + "\n\n");
            int end = Chat.TextLength;
            Chat.Select(start, end - start);
            Chat.SelectionColor = color;
            Chat.DeselectAll();

            Chat.ScrollToCaret();
        }

        private void StartBackend_Click(object sender, EventArgs e)
        {
            StartConnection(this, new IrcConnectionStartEventArgs(broadcasterName));
        }

        private void BroadcasterNameBox_TextChanged(object sender, EventArgs e)
        {
            broadcasterName = BroadcasterNameBox.Text;
            StartBackend.Text = "Connect to " + broadcasterName;
        }
    }
}
