using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceV2
{
    public partial class ParticipantForm : Form
    {
        private string participantName;
        private int participantUserID;

        public ParticipantForm(string name, int userID)
        {
            InitializeComponent();
            participantName = name;
            participantUserID = userID;
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Timer to update current date and time
            timer1.Start();

            // Display participant's name
            label_hello.Text = "Hello, " + participantName + "!";

            // Show current event (if any)
            ShowCurrentEvent();
        }

        private void ShowCurrentEvent()
        {
            try
            {
                // Connect to the database
                using (MySqlConnection connection = new MySqlConnection("ConnectionString"))
                {
                    connection.Open();

                    // Query to get the current event based on date and time
                    string query = $"SELECT Name FROM Events WHERE StartDateTime <= NOW() AND EndDateTime >= NOW()";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Execute the query and get the event name
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        label_currentEvent.Text = "Current Event: " + result.ToString();
                    }
                    else
                    {
                        label_currentEvent.Text = "No ongoing events.";
                    }

                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_attend_Click(object sender, EventArgs e)
        {

        }

        private void Btn_logout_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_currentDate.Text = DateTime.Now.ToLongDateString();
            label_currentTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
