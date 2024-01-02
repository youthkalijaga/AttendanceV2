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
    public partial class AdminForm : Form
    {
        private string administratorName;

        private int administratorUserID;

        public AdminForm(string name, int userID)
        {
            InitializeComponent();
            administratorName = name;
            administratorUserID = userID;
            InitializeForm();
        }

        private void InitializeForm()
        {
            timer1.Start();
            label_hello.Text = "Hello, " + administratorName + "!";
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            List<string> userRoles = new List<string> { "Participant", "Instructor" };
            comboBoxUserRole.DataSource = userRoles;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_currentDate.Text = DateTime.Now.ToLongDateString();

            label_currentTime.Text = DateTime.Now.ToLongTimeString();
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

        private void Btn_createUser_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string email = textBoxName.Text;
            string password = textBoxPassword.Text;
            string userRole = comboBoxUserRole.SelectedItem?.ToString();

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Check if the email already exists
                    string checkExistingUserQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    MySqlCommand checkExistingUserCmd = new MySqlCommand(checkExistingUserQuery, connection);
                    checkExistingUserCmd.Parameters.AddWithValue("@Email", email);

                    int existingUserCount = Convert.ToInt32(checkExistingUserCmd.ExecuteScalar());
                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Insert user details into Users table
                    string insertUserQuery = "INSERT INTO Users (Email, Password, UserRole) VALUES (@Email, @Password, @UserRole)";
                    MySqlCommand insertUserCmd = new MySqlCommand(insertUserQuery, connection);
                    insertUserCmd.Parameters.AddWithValue("@Email", email);
                    insertUserCmd.Parameters.AddWithValue("@Password", password);
                    insertUserCmd.Parameters.AddWithValue("@UserRole", userRole);

                    insertUserCmd.ExecuteNonQuery();

                    // Get the UserID of the newly created user
                    string getUserIdQuery = "SELECT LAST_INSERT_ID()";
                    MySqlCommand getUserIdCmd = new MySqlCommand(getUserIdQuery, connection);
                    int userID = Convert.ToInt32(getUserIdCmd.ExecuteScalar());

                    // Insert details into Participants or Instructors table based on UserRole
                    if (userRole == "Participant")
                    {
                        string insertParticipantQuery = "INSERT INTO Participants (UserID, Name) VALUES (@UserID, @Name)";
                        MySqlCommand insertParticipantCmd = new MySqlCommand(insertParticipantQuery, connection);
                        insertParticipantCmd.Parameters.AddWithValue("@UserID", userID);
                        insertParticipantCmd.Parameters.AddWithValue("@Name", name);

                        insertParticipantCmd.ExecuteNonQuery();
                    }
                    else if (userRole == "Instructor")
                    {
                        string insertInstructorQuery = "INSERT INTO Instructors (UserID, Name) VALUES (@UserID, @Name)";
                        MySqlCommand insertInstructorCmd = new MySqlCommand(insertInstructorQuery, connection);
                        insertInstructorCmd.Parameters.AddWithValue("@UserID", userID);
                        insertInstructorCmd.Parameters.AddWithValue("@Name", name);

                        insertInstructorCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxEmail.Text = "";
                    textBoxPassword.Text = "";
                    comboBoxUserRole.SelectedItem = null;
                    textBoxName.Text = "";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
