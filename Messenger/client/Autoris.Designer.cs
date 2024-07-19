namespace client
{
    partial class Autoris
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
            Login = new TextBox();
            Pass = new TextBox();
            Log = new Button();
            Reg = new Button();
            SuspendLayout();
            // 
            // Login
            // 
            Login.Location = new Point(12, 12);
            Login.Name = "Login";
            Login.Size = new Size(206, 27);
            Login.TabIndex = 0;
            Login.Text = "Login";
            // 
            // Pass
            // 
            Pass.Location = new Point(12, 45);
            Pass.Name = "Pass";
            Pass.Size = new Size(206, 27);
            Pass.TabIndex = 1;
            Pass.Text = "Pass";
            // 
            // Log
            // 
            Log.Location = new Point(12, 78);
            Log.Name = "Log";
            Log.Size = new Size(94, 62);
            Log.TabIndex = 2;
            Log.Text = "Login";
            Log.UseVisualStyleBackColor = true;
            Log.Click += Log_Click;
            // 
            // Reg
            // 
            Reg.Location = new Point(112, 78);
            Reg.Name = "Reg";
            Reg.Size = new Size(106, 62);
            Reg.TabIndex = 3;
            Reg.Text = "Registration";
            Reg.UseVisualStyleBackColor = true;
            Reg.Click += Reg_Click;
            // 
            // Autoris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(240, 163);
            Controls.Add(Reg);
            Controls.Add(Log);
            Controls.Add(Pass);
            Controls.Add(Login);
            Name = "Autoris";
            Text = "Autoris";
            Load += Autoris_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Login;
        private TextBox Pass;
        private Button Log;
        private Button Reg;
    }
}