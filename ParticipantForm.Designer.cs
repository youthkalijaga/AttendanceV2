namespace AttendanceV2
{
    partial class ParticipantForm
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
            this.label_hello = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.label_currentEvent = new System.Windows.Forms.Label();
            this.label_activeEvent = new System.Windows.Forms.Label();
            this.btn_attend = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_hello
            // 
            this.label_hello.AutoSize = true;
            this.label_hello.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hello.Location = new System.Drawing.Point(30, 29);
            this.label_hello.Name = "label_hello";
            this.label_hello.Size = new System.Drawing.Size(61, 25);
            this.label_hello.TabIndex = 0;
            this.label_hello.Text = "Hello,";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_user.Location = new System.Drawing.Point(86, 29);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(53, 25);
            this.label_user.TabIndex = 1;
            this.label_user.Text = "User";
            // 
            // label_currentEvent
            // 
            this.label_currentEvent.AutoSize = true;
            this.label_currentEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentEvent.Location = new System.Drawing.Point(141, 89);
            this.label_currentEvent.Name = "label_currentEvent";
            this.label_currentEvent.Size = new System.Drawing.Size(143, 25);
            this.label_currentEvent.TabIndex = 2;
            this.label_currentEvent.Text = "Current Event :";
            // 
            // label_activeEvent
            // 
            this.label_activeEvent.AutoSize = true;
            this.label_activeEvent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_activeEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_activeEvent.Location = new System.Drawing.Point(293, 89);
            this.label_activeEvent.MinimumSize = new System.Drawing.Size(250, 0);
            this.label_activeEvent.Name = "label_activeEvent";
            this.label_activeEvent.Size = new System.Drawing.Size(250, 27);
            this.label_activeEvent.TabIndex = 3;
            this.label_activeEvent.Text = "Matematika Diskrit";
            // 
            // btn_attend
            // 
            this.btn_attend.Location = new System.Drawing.Point(549, 84);
            this.btn_attend.MinimumSize = new System.Drawing.Size(80, 36);
            this.btn_attend.Name = "btn_attend";
            this.btn_attend.Size = new System.Drawing.Size(80, 36);
            this.btn_attend.TabIndex = 4;
            this.btn_attend.Text = "Present";
            this.btn_attend.UseVisualStyleBackColor = true;
            this.btn_attend.Click += new System.EventHandler(this.btn_attend_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(694, 26);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(79, 33);
            this.btn_logout.TabIndex = 5;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // ParticipantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_attend);
            this.Controls.Add(this.label_activeEvent);
            this.Controls.Add(this.label_currentEvent);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.label_hello);
            this.Name = "ParticipantForm";
            this.Text = "ParticipantForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_hello;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_currentEvent;
        private System.Windows.Forms.Label label_activeEvent;
        private System.Windows.Forms.Button btn_attend;
        private System.Windows.Forms.Button btn_logout;
    }
}