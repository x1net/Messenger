namespace Messenger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ip = new TextBox();
            port = new TextBox();
            type = new ComboBox();
            message = new TextBox();
            send = new Button();
            StartServer = new Button();
            StopServer = new Button();
            history = new RichTextBox();
            clients = new CheckedListBox();
            SuspendLayout();
            // 
            // ip
            // 
            ip.Location = new Point(449, 11);
            ip.Margin = new Padding(3, 4, 3, 4);
            ip.Name = "ip";
            ip.Size = new Size(156, 27);
            ip.TabIndex = 0;
            ip.Text = "127.0.0.1";
            // 
            // port
            // 
            port.Location = new Point(449, 49);
            port.Margin = new Padding(3, 4, 3, 4);
            port.Name = "port";
            port.Size = new Size(156, 27);
            port.TabIndex = 1;
            port.Text = "8080";
            // 
            // type
            // 
            type.FormattingEnabled = true;
            type.Items.AddRange(new object[] { "Звичайне", "Термінове", "Інформаційне", "Новини" });
            type.Location = new Point(449, 85);
            type.Margin = new Padding(3, 4, 3, 4);
            type.Name = "type";
            type.Size = new Size(156, 28);
            type.TabIndex = 2;
            type.Text = "Тип повідомлення";
            // 
            // message
            // 
            message.Location = new Point(14, 128);
            message.Margin = new Padding(3, 4, 3, 4);
            message.Name = "message";
            message.Size = new Size(591, 27);
            message.TabIndex = 3;
            message.Text = "Введіть повідомлення";
            // 
            // send
            // 
            send.Location = new Point(14, 163);
            send.Margin = new Padding(3, 4, 3, 4);
            send.Name = "send";
            send.Size = new Size(112, 53);
            send.TabIndex = 4;
            send.Text = "Надіслати";
            send.UseVisualStyleBackColor = true;
            send.Click += send_Click;
            // 
            // StartServer
            // 
            StartServer.Location = new Point(618, 11);
            StartServer.Margin = new Padding(3, 4, 3, 4);
            StartServer.Name = "StartServer";
            StartServer.Size = new Size(94, 69);
            StartServer.TabIndex = 6;
            StartServer.Text = "Start Server";
            StartServer.UseVisualStyleBackColor = true;
            StartServer.Click += StartServer_Click;
            // 
            // StopServer
            // 
            StopServer.Location = new Point(618, 88);
            StopServer.Margin = new Padding(3, 4, 3, 4);
            StopServer.Name = "StopServer";
            StopServer.Size = new Size(94, 67);
            StopServer.TabIndex = 7;
            StopServer.Text = "Stop Server";
            StopServer.UseVisualStyleBackColor = true;
            StopServer.Click += StopServer_Click;
            // 
            // history
            // 
            history.Location = new Point(12, 223);
            history.Name = "history";
            history.Size = new Size(700, 365);
            history.TabIndex = 8;
            history.Text = "";
            // 
            // clients
            // 
            clients.FormattingEnabled = true;
            clients.Location = new Point(14, 11);
            clients.Name = "clients";
            clients.Size = new Size(312, 114);
            clients.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 600);
            Controls.Add(clients);
            Controls.Add(history);
            Controls.Add(StopServer);
            Controls.Add(StartServer);
            Controls.Add(send);
            Controls.Add(message);
            Controls.Add(type);
            Controls.Add(port);
            Controls.Add(ip);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ip;
        private TextBox port;
        private ComboBox type;
        private TextBox message;
        private Button send;
        private Button StartServer;
        private Button StopServer;
        private RichTextBox history;
        private CheckedListBox clients;
    }
}
