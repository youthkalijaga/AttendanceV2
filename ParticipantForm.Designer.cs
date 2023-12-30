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
            this.components = new System.ComponentModel.Container();
            this.label_hello = new System.Windows.Forms.Label();
            this.label_currentEvent = new System.Windows.Forms.Label();
            this.label_activeEvent = new System.Windows.Forms.Label();
            this.Btn_attend = new System.Windows.Forms.Button();
            this.Btn_logout = new System.Windows.Forms.Button();
            this.label_currentDate = new System.Windows.Forms.Label();
            this.label_currentTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_hello
            // 
            this.label_hello.AutoSize = true;
            this.label_hello.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hello.Location = new System.Drawing.Point(27, 29);
            this.label_hello.Name = "label_hello";
            this.label_hello.Size = new System.Drawing.Size(113, 25);
            this.label_hello.TabIndex = 0;
            this.label_hello.Text = "Hello, User!";
            // 
            // label_currentEvent
            // 
            this.label_currentEvent.AutoSize = true;
            this.label_currentEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentEvent.Location = new System.Drawing.Point(141, 126);
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
            this.label_activeEvent.Location = new System.Drawing.Point(293, 126);
            this.label_activeEvent.MinimumSize = new System.Drawing.Size(250, 0);
            this.label_activeEvent.Name = "label_activeEvent";
            this.label_activeEvent.Size = new System.Drawing.Size(250, 27);
            this.label_activeEvent.TabIndex = 3;
            this.label_activeEvent.Text = "Matematika Diskrit";
            // 
            // Btn_attend
            // 
            this.Btn_attend.Location = new System.Drawing.Point(549, 121);
            this.Btn_attend.MinimumSize = new System.Drawing.Size(80, 36);
            this.Btn_attend.Name = "Btn_attend";
            this.Btn_attend.Size = new System.Drawing.Size(80, 36);
            this.Btn_attend.TabIndex = 4;
            this.Btn_attend.Text = "Present";
            this.Btn_attend.UseVisualStyleBackColor = true;
            this.Btn_attend.Click += new System.EventHandler(this.Btn_attend_Click);
            // 
            // Btn_logout
            // 
            this.Btn_logout.Location = new System.Drawing.Point(694, 26);
            this.Btn_logout.Name = "Btn_logout";
            this.Btn_logout.Size = new System.Drawing.Size(79, 33);
            this.Btn_logout.TabIndex = 5;
            this.Btn_logout.Text = "Logout";
            this.Btn_logout.UseVisualStyleBackColor = true;
            this.Btn_logout.Click += new System.EventHandler(this.Btn_logout_Click);
            // 
            // label_currentDate
            // 
            this.label_currentDate.AutoSize = true;
            this.label_currentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentDate.Location = new System.Drawing.Point(288, 26);
            this.label_currentDate.Name = "label_currentDate";
            this.label_currentDate.Size = new System.Drawing.Size(229, 25);
            this.label_currentDate.TabIndex = 6;
            this.label_currentDate.Text = "Monday, 1 January 2024";
            // 
            // label_currentTime
            // 
            this.label_currentTime.AutoSize = true;
            this.label_currentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentTime.Location = new System.Drawing.Point(336, 59);
            this.label_currentTime.Name = "label_currentTime";
            this.label_currentTime.Size = new System.Drawing.Size(126, 25);
            this.label_currentTime.TabIndex = 7;
            this.label_currentTime.Text = "09:45:00 AM";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ParticipantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_currentTime);
            this.Controls.Add(this.label_currentDate);
            this.Controls.Add(this.Btn_logout);
            this.Controls.Add(this.Btn_attend);
            this.Controls.Add(this.label_activeEvent);
            this.Controls.Add(this.label_currentEvent);
            this.Controls.Add(this.label_hello);
            this.Name = "ParticipantForm";
            this.Text = "ParticipantForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_hello;
        private System.Windows.Forms.Label label_currentEvent;
        private System.Windows.Forms.Label label_activeEvent;
        private System.Windows.Forms.Button Btn_attend;
        private System.Windows.Forms.Button Btn_logout;
        private System.Windows.Forms.Label label_currentDate;
        private System.Windows.Forms.Label label_currentTime;
        private System.Windows.Forms.Timer timer1;
    }
}