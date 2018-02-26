namespace DeStoofBot.UserForm
{
    partial class FrontForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Chat = new System.Windows.Forms.RichTextBox();
            this.StartBackend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BroadcasterNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.Black;
            this.Chat.ForeColor = System.Drawing.Color.Blue;
            this.Chat.HideSelection = false;
            this.Chat.Location = new System.Drawing.Point(13, 13);
            this.Chat.Name = "Chat";
            this.Chat.ReadOnly = true;
            this.Chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Chat.Size = new System.Drawing.Size(355, 373);
            this.Chat.TabIndex = 0;
            this.Chat.Text = "";
            // 
            // StartBackend
            // 
            this.StartBackend.Location = new System.Drawing.Point(374, 39);
            this.StartBackend.Name = "StartBackend";
            this.StartBackend.Size = new System.Drawing.Size(162, 23);
            this.StartBackend.TabIndex = 1;
            this.StartBackend.Text = "Connect";
            this.StartBackend.UseVisualStyleBackColor = true;
            this.StartBackend.Click += new System.EventHandler(this.StartBackend_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(13, 393);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 20);
            this.textBox1.TabIndex = 2;
            // 
            // BroadcasterNameBox
            // 
            this.BroadcasterNameBox.BackColor = System.Drawing.Color.Black;
            this.BroadcasterNameBox.ForeColor = System.Drawing.Color.White;
            this.BroadcasterNameBox.Location = new System.Drawing.Point(375, 13);
            this.BroadcasterNameBox.Name = "BroadcasterNameBox";
            this.BroadcasterNameBox.Size = new System.Drawing.Size(161, 20);
            this.BroadcasterNameBox.TabIndex = 3;
            this.BroadcasterNameBox.TextChanged += new System.EventHandler(this.BroadcasterNameBox_TextChanged);
            // 
            // FrontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 445);
            this.Controls.Add(this.BroadcasterNameBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StartBackend);
            this.Controls.Add(this.Chat);
            this.Name = "FrontForm";
            this.Text = "FrontForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Chat;
        private System.Windows.Forms.Button StartBackend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox BroadcasterNameBox;
    }
}