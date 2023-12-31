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
            timer1.Start();
            label_hello.Text = "Hello, " + participantName + "!";
            ShowCurrentEvent();
        }

        private void ShowCurrentEvent()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                string formattedCurrentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Console.WriteLine("\n Formatted Current Date and Time: " + formattedCurrentDate + "\n");

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = $"SELECT EventID, Name FROM Events WHERE StartDateTime <= '{formattedCurrentDate}' AND EndDateTime >= '{formattedCurrentDate}'";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label_currentEvent.Text = "Current Event: ";
                            label_activeEvent.Show();
                            label_activeEvent.Text = reader["Name"].ToString();
                            Btn_attend.Show();
                        }
                        else
                        {
                            label_currentEvent.Text = "Thank you, there is no ongoing event right now :)";
                            label_activeEvent.Hide();
                            Btn_attend.Hide();
                        }
                    }
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
