using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            instructorUserID = GetInstructorID(userID);
            InitializeForm();
            LoadDataToGrid_eventsList();
        }
        private void InstructorForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeForm()
        {
            timer1.Start();
            label_hello.Text = "Hello, " + instructorName + "!";
            label_instructor.Text = instructorName;
            Console.WriteLine("InstructorID: " + instructorUserID);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_currentDate.Text = DateTime.Now.ToLongDateString();

            label_currentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private int GetInstructorID(int userID)
        {
            int instructorID = -1;

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT InstructorID FROM Instructors WHERE UserID = @userID";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userID", userID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        instructorID = Convert.ToInt32(result);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return instructorID;
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

        private void Btn_create_Click(object sender, EventArgs e)
        {
            // Retrieve the event details from the form
            string eventName = Input_eventName.Text;
            DateTime startDateTime = TimePicker_start.Value;
            DateTime endDateTime = TimePicker_end.Value;

            if (string.IsNullOrEmpty(eventName))
            {
                MessageBox.Show("Please enter the event name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "INSERT INTO Events (InstructorID, Name, StartDateTime, EndDateTime, Completed) " +
                                   "VALUES (@instructorID, @eventName, @startDateTime, @endDateTime, 0)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@instructorID", instructorUserID);
                    command.Parameters.AddWithValue("@eventName", eventName);
                    command.Parameters.AddWithValue("@startDateTime", startDateTime);
                    command.Parameters.AddWithValue("@endDateTime", endDateTime);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Event created successfully!");
                            Input_eventName.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Failed to create the event.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataToGrid_eventsList()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT e.Name AS 'Event Name', e.StartDateTime AS 'Start Date', e.EndDateTime AS 'End Date' FROM Events e WHERE InstructorID = {instructorUserID}";

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    Grid_eventsList.DataSource = dataTable;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
