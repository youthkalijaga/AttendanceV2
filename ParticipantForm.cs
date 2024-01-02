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

        private string GetFormattedCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public ParticipantForm(string name, int userID)
        {
            InitializeComponent();
            participantName = name;
            participantUserID = userID;
            InitializeForm();
            LoadDataToDataGridView();
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
                string formattedCurrentDate = GetFormattedCurrentDate();
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

        private void LoadDataToDataGridView()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT e.Name AS 'Event Name', e.StartDateTime AS 'Start Date', e.EndDateTime AS 'End Date', a.AttendStatus AS 'Kehadiran' FROM Events e INNER JOIN Attend a ON e.EventID = a.EventID INNER JOIN Participants p ON a.ParticipantID = p.ParticipantID WHERE p.UserID = {participantUserID}";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    DataGridView_events.DataSource = dataTable;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_attend_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string formattedCurrentDate = GetFormattedCurrentDate();

                    string query = $"SELECT EventID FROM Events WHERE StartDateTime <= '{formattedCurrentDate}' AND EndDateTime >= '{formattedCurrentDate}'";

                    MySqlCommand eventCmd = new MySqlCommand(query, connection);

                    object eventID = eventCmd.ExecuteScalar();

                    // If there is any ongoing event.
                    if (eventID != null)
                    {
                        int currentEventID = Convert.ToInt32(eventID);

                        // Check if the user has already attended the current active event
                        string attendQuery = $"SELECT COUNT(*) FROM Attend WHERE ParticipantID = {participantUserID} AND EventID = {currentEventID}";

                        MySqlCommand attendCmd = new MySqlCommand(attendQuery, connection);

                        int attendCount = Convert.ToInt32(attendCmd.ExecuteScalar());


                        if (attendCount > 0)
                        {
                            MessageBox.Show("You've already attended this event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Check if the event has been held
                            string eventCompletionQuery = $"SELECT Completed FROM Events WHERE EventID = {currentEventID}";

                            MySqlCommand eventCompletionCmd = new MySqlCommand(eventCompletionQuery, connection);

                            object eventCompletion = eventCompletionCmd.ExecuteScalar();

                            if (eventCompletion != null && Convert.ToBoolean(eventCompletion))
                            {
                                InsertAttendRecord(currentEventID, "Tidak hadir");
                            }
                            else
                            {
                                InsertAttendRecord(currentEventID, "Hadir");
                                LoadDataToDataGridView();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no ongoing event to attend.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertAttendRecord(int eventID, string attendStatus)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string insertQuery = $"INSERT INTO Attend (ParticipantID, EventID, AttendStatus) VALUES ({participantUserID}, {eventID}, '{attendStatus}')";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Attendance recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to record attendance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_currentDate.Text = DateTime.Now.ToLongDateString();

            label_currentTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
