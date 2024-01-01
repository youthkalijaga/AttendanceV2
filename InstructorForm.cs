﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AttendanceV2
{
    public partial class InstructorForm : Form
    {
        private string instructorName;

        private int instructorUserID;

        public InstructorForm(string name, int userID)
        {
            InitializeComponent();
            instructorName = name;
            instructorUserID = userID;
            InitializeForm();
        }
        private void InstructorForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeForm()
        {
            timer1.Start();
            label_hello.Text = "Hello, " + instructorName + "!";
            label_instructor.Text = instructorName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_currentDate.Text = DateTime.Now.ToLongDateString();

            label_currentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void Btn_create_Click(object sender, EventArgs e)
        {

        }

    }
}
