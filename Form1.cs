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
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();

            input_password.PasswordChar = '*';
        }

        private void InitializeDatabase()
        {
            server = "127.0.0.1";
            database = "employee_ms";
            uid = "root";
            password = "";

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            input_password.PasswordChar = check_showPass.Checked ? '\0' : '*';
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (input_email.Text == "" || input_password.Text == "")
            {
                MessageBox.Show("Harap masukkan email dan password Anda!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT COUNT(*) FROM users WHERE email = '{input_email.Text}' AND password = '{input_password.Text}'";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();

                    if (count > 0)
                    {
                        MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}



        
