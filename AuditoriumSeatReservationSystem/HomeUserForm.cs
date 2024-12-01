using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class HomeUserForm : Form
    {
        private string userEmail;
        private string userName; 

        public HomeUserForm(string email)
        {
            InitializeComponent();
            userEmail = email; 
            userName = GetUserNameFromDatabase(userEmail);

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User data could not be retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblWelcome.Text = $"Welcome, {userName}!"; 
        }

        // Method to get user's name from the database based on their email
        private string GetUserNameFromDatabase(string email)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";
            string name = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Name FROM Users WHERE Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        var result = cmd.ExecuteScalar(); 
                        if (result != null)
                        {
                            name = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return name;
        }


        private void btnReserveNow_Click(object sender, EventArgs e)
        {
            AuditoriumSeats auditoriumSeats = new AuditoriumSeats(userEmail);
            auditoriumSeats.Show();
            this.Hide();
        }

        private void btnMyReservation_Click(object sender, EventArgs e)
        {
            MyReservationForm myReservationForm = new MyReservationForm(userEmail);
            myReservationForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }
    }
}
