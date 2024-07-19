namespace client
{
    partial class Registr
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
            Pass1 = new TextBox();
            Pass2 = new TextBox();
            Info = new TextBox();
            Registration = new Button();
            SuspendLayout();
            // 
            // Login
            // 
            Login.Location = new Point(12, 12);
            Login.Name = "Login";
            Login.Size = new Size(229, 27);
            Login.TabIndex = 0;
            Login.Text = "Login";
            // 
            // Pass1
            // 
            Pass1.Location = new Point(12, 45);
            Pass1.Name = "Pass1";
            Pass1.Size = new Size(229, 27);
            Pass1.TabIndex = 1;
            Pass1.Text = "Pass1";
            // 
            // Pass2
            // 
            Pass2.Location = new Point(12, 78);
            Pass2.Name = "Pass2";
            Pass2.Size = new Size(229, 27);
            Pass2.TabIndex = 2;
            Pass2.Text = "Pass2";
            // 
            // Info
            // 
            Info.Location = new Point(12, 111);
            Info.Name = "Info";
            Info.Size = new Size(229, 27);
            Info.TabIndex = 3;
            Info.Text = "Info";
            // 
            // Registration
            // 
            Registration.Location = new Point(71, 146);
            Registration.Name = "Registration";
            Registration.Size = new Size(102, 67);
            Registration.TabIndex = 4;
            Registration.Text = "Registration";
            Registration.UseVisualStyleBackColor = true;
            Registration.Click += Registration_Click;
            // 
            // Registr
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 225);
            Controls.Add(Registration);
            Controls.Add(Info);
            Controls.Add(Pass2);
            Controls.Add(Pass1);
            Controls.Add(Login);
            Name = "Registr";
            Text = "Registr";
            Load += Registr_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Login;
        private TextBox Pass1;
        private TextBox Pass2;
        private TextBox Info;
        private Button Registration;
    }
}