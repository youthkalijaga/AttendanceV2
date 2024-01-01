namespace AttendanceV2
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_login = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.input_email = new System.Windows.Forms.TextBox();
            this.input_password = new System.Windows.Forms.TextBox();
            this.Btn_login = new System.Windows.Forms.Button();
            this.Check_showPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 509);
            this.panel1.TabIndex = 0;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login.Location = new System.Drawing.Point(469, 56);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(85, 32);
            this.label_login.TabIndex = 1;
            this.label_login.Text = "Login";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.Location = new System.Drawing.Point(376, 130);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(60, 25);
            this.label_email.TabIndex = 2;
            this.label_email.Text = "Email";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(376, 212);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(98, 25);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "Password";
            // 
            // input_email
            // 
            this.input_email.Location = new System.Drawing.Point(381, 167);
            this.input_email.Name = "input_email";
            this.input_email.Size = new System.Drawing.Size(261, 26);
            this.input_email.TabIndex = 1;
            // 
            // input_password
            // 
            this.input_password.Location = new System.Drawing.Point(381, 249);
            this.input_password.Name = "input_password";
            this.input_password.Size = new System.Drawing.Size(261, 26);
            this.input_password.TabIndex = 2;
            // 
            // Btn_login
            // 
            this.Btn_login.Location = new System.Drawing.Point(460, 366);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(105, 36);
            this.Btn_login.TabIndex = 4;
            this.Btn_login.Text = "Login";
            this.Btn_login.UseVisualStyleBackColor = true;
            this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // Check_showPass
            // 
            this.Check_showPass.AutoSize = true;
            this.Check_showPass.Location = new System.Drawing.Point(381, 287);
            this.Check_showPass.Name = "Check_showPass";
            this.Check_showPass.Size = new System.Drawing.Size(148, 24);
            this.Check_showPass.TabIndex = 3;
            this.Check_showPass.Text = "Show Password";
            this.Check_showPass.UseVisualStyleBackColor = true;
            this.Check_showPass.CheckedChanged += new System.EventHandler(this.Check_showPass_CheckedChanged_1);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(714, 509);
            this.Controls.Add(this.Check_showPass);
            this.Controls.Add(this.Btn_login);
            this.Controls.Add(this.input_password);
            this.Controls.Add(this.input_email);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Attendance Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox input_email;
        private System.Windows.Forms.TextBox input_password;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Button Btn_login;
        private System.Windows.Forms.CheckBox Check_showPass;
    }
}

