namespace client
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
            type = new ComboBox();
            port = new TextBox();
            ip = new TextBox();
            text = new TextBox();
            send = new Button();
            history = new RichTextBox();
            connect = new Button();
            SuspendLayout();
            // 
            // type
            // 
            type.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            type.FormattingEnabled = true;
            type.Location = new Point(399, 52);
            type.Margin = new Padding(3, 4, 3, 4);
            type.Name = "type";
            type.Size = new Size(156, 28);
            type.TabIndex = 5;
            type.Items.AddRange(new string[] { "Звичайне", "Термінове", "Інформаційне", "Новини" });
            type.Text = "Тип повідомлення";
            // 
            // port
            // 
            port.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            port.Location = new Point(561, 52);
            port.Margin = new Padding(3, 4, 3, 4);
            port.Name = "port";
            port.Size = new Size(156, 27);
            port.TabIndex = 4;
            port.Text = "8080";
            // 
            // ip
            // 
            ip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ip.Location = new Point(561, 13);
            ip.Margin = new Padding(3, 4, 3, 4);
            ip.Name = "ip";
            ip.Size = new Size(156, 27);
            ip.TabIndex = 3;
            ip.Text = "127.0.0.1";
            // 
            // text
            // 
            text.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            text.Location = new Point(12, 13);
            text.Margin = new Padding(3, 4, 3, 4);
            text.Name = "text";
            text.Size = new Size(543, 27);
            text.TabIndex = 9;
            text.Text = "Введіть повідомлення";
            // 
            // send
            // 
            send.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            send.AutoSize = true;
            send.Location = new Point(12, 48);
            send.Margin = new Padding(3, 4, 3, 4);
            send.Name = "send";
            send.Size = new Size(123, 67);
            send.TabIndex = 10;
            send.Text = "Надіслати";
            send.UseVisualStyleBackColor = true;
            send.Click += send_Click;
            // 
            // history
            // 
            history.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            history.Location = new Point(12, 123);
            history.Margin = new Padding(3, 4, 3, 4);
            history.Name = "history";
            history.Size = new Size(705, 304);
            history.TabIndex = 12;
            history.ReadOnly = true;
            // 
            // connect
            // 
            connect.Location = new Point(561, 86);
            connect.Name = "connect";
            connect.Size = new Size(156, 29);
            connect.TabIndex = 13;
            connect.Text = "connect server";
            connect.UseVisualStyleBackColor = true;
            connect.Click += connect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 440);
            Controls.Add(connect);
            Controls.Add(history);
            Controls.Add(send);
            Controls.Add(text);
            Controls.Add(type);
            Controls.Add(port);
            Controls.Add(ip);
            Name = "Form1";
            Text = "Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox type;
        private TextBox port;
        private TextBox ip;
        private TextBox text;
        private Button send;
        private RichTextBox history;
        private Button connect;
    }
}
