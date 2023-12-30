﻿using MySql.Data.MySqlClient;
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
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public LoginForm()
        {
            InitializeComponent();
            InitializeDatabase();

            input_password.PasswordChar = '*';
        }

        private void InitializeDatabase()
        {
            server = "127.0.0.1";
            database = "attendancev2";
            uid = "root";
            password = "";

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (input_email.Text == "" || input_password.Text == "")
            {
                MessageBox.Show("Please enter email and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
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
                        string nameQuery = $"SELECT Name FROM Participants WHERE UserID = '{userID}'";
                        MySqlCommand nameCmd = new MySqlCommand(nameQuery, connection);
                        string participantName = nameCmd.ExecuteScalar()?.ToString();

                        // Query user_role after successful login
                        string roleQuery = $"SELECT UserRole FROM users WHERE email = '{input_email.Text}'";
                        MySqlCommand roleCmd = new MySqlCommand(roleQuery, connection);
                        string userRole = roleCmd.ExecuteScalar()?.ToString();

                        // Close the connection
                        connection.Close();

                        if (userRole != null)
                        {
                            // Redirect based on user_role using switch-case
                            switch (userRole)
                            {
                                case "Admin":
                                    // Redirect to admin-specific functionality or form
                                    AdminForm adminForm = new AdminForm();
                                    adminForm.Show();
                                    break;
                                case "Instructor":
                                    // Redirect to instructor-specific functionality or form
                                    InstructorForm instructorForm = new InstructorForm();
                                    instructorForm.Show();
                                    break;
                                case "Participant":
                                    // Redirect to participant-specific functionality or form
                                    ParticipantForm participantForm = new ParticipantForm(participantName, userID);
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
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Check_showPass_CheckedChanged_1(object sender, EventArgs e)
        {
            input_password.PasswordChar = Check_showPass.Checked ? '\0' : '*';
        }
    }
}



        
