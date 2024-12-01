using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class MyReservationForm : Form
    {
        private string userEmail;

        public MyReservationForm(string email)
        {
            InitializeComponent();
            userEmail = email;
            LoadReservations();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to the HomeUserForm
            var homeUserForm = new HomeUserForm(userEmail); 
            homeUserForm.Show();
            this.Close();
        }

        private void LoadReservations()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Seat, Name, Date, Time FROM Reservations WHERE Name = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", userEmail);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewReservations.DataSource = dataTable; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
