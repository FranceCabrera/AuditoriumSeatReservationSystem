using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Simple validation for email and password
            if (IsValidUser(email, password))
            {
                MessageBox.Show("Login Successful!");

                // Pass the email (or username) to the AuditoriumSeats form
                AuditoriumSeats auditoriumSeats = new AuditoriumSeats(email); // Pass email as the username
                auditoriumSeats.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidUser(string email, string password)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";
            bool isValid = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int count = (int)cmd.ExecuteScalar();
                    isValid = count > 0;
                }
            }

            return isValid;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Add any functionality you wish when label2 is clicked
        }
    }
}
