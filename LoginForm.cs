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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            input_password.PasswordChar = '*';
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            string inputEmail = input_email.Text.Trim();
            string inputPassword = input_password.Text.Trim();


            if (string.IsNullOrEmpty(inputEmail) || string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Please enter email and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Retrieve user details including user_role and UserID
                    string query = $"SELECT COUNT(*), UserID FROM users WHERE email = '{input_email.Text}' AND password = '{input_password.Text}'";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int count = 0;
                    int userID = 0;

                    while (reader.Read())
                    {
                        count = Convert.ToInt32(reader[0]);
                        userID = Convert.ToInt32(reader[1]);
                    }

                    reader.Close();

                    if (count > 0)
                    {
                        // Retrieve participant's name based on UserID
                        string participantNameQuery = $"SELECT Name FROM Participants WHERE UserID = '{userID}'";
                        MySqlCommand participantNameCmd = new MySqlCommand(participantNameQuery, connection);
                        string participantName = participantNameCmd.ExecuteScalar()?.ToString();

                        // Retrieve instructor's name based on UserID
                        string instructorNameQuery = $"SELECT Name FROM Instructors WHERE UserID = '{userID}'";
                        MySqlCommand instructorNameCmd = new MySqlCommand(instructorNameQuery, connection);
                        string instructorName = instructorNameCmd.ExecuteScalar()?.ToString();

                        // Query user_role after successful login
                        string roleQuery = $"SELECT UserRole FROM users WHERE email = '{input_email.Text}'";
                        MySqlCommand roleCmd = new MySqlCommand(roleQuery, connection);
                        string userRole = roleCmd.ExecuteScalar()?.ToString();

                        connection.Close();

                        if (userRole != null)
                        {
                            switch (userRole)
                            {
                                case "Admin":
                                    AdminForm adminForm = new AdminForm(instructorName, userID);
                                    adminForm.Show();
                                    break;
                                case "Instructor":
                                    InstructorForm instructorForm = new InstructorForm();
                                    instructorForm.Show();
                                    break;
                                case "Participant":
                                    ParticipantForm participantForm = new ParticipantForm(participantName, userID);
                                    this.Hide();
                                    participantForm.Show();
                                    break;
                                default:
                                    MessageBox.Show("Unknown user role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("User role not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Check_showPass_CheckedChanged_1(object sender, EventArgs e)
        {
            input_password.PasswordChar = Check_showPass.Checked ? '\0' : '*';
        }
    }
    public static class DatabaseConnection
    {
        public static MySqlConnection GetConnection()
        {
            string server = "127.0.0.1";
            string database = "attendancev2";
            string uid = "root";
            string password = "";

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            return new MySqlConnection(connectionString);
        }
    }
}




