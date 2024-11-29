using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class ConfirmSelectionForm : Form
    {
        // Properties to hold the seat number and current user's name
        public string SeatNumber { get; set; }
        public string CurrentUserName { get; set; }

        // Database connection string (without encryption)
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30;";

        public ConfirmSelectionForm(string seatNumber, string currentUserName)
        {
            InitializeComponent();
            SeatNumber = seatNumber;
            CurrentUserName = currentUserName;
        }

        // Form Load event to update the label with the seat number and user name
        private void ConfirmSelectionForm_Load(object sender, EventArgs e)
        {
            lblSeatNumber.Text = $"Seat Number: {SeatNumber}";
            lblCurrentUser.Text = $"Reserved by: {CurrentUserName}";
        }

        // Event handler for the Reserve Seat button click
        private void BtnReserveSeat_Click(object sender, EventArgs e)
        {
            string date = txtDate.Text;
            string time = txtTime.Text;

            // Validate the date and time fields
            if (date == "Enter Date (YYYY-MM-DD)" || string.IsNullOrWhiteSpace(date) ||
                time == "Enter Time (HH:MM)" || string.IsNullOrWhiteSpace(time))
            {
                MessageBox.Show("Please enter valid date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save reservation data to the database
            SaveReservationToDatabase(CurrentUserName, SeatNumber, date, time);

            // Open the ReservationReceiptForm with the necessary data
            ReservationReceiptForm receiptForm = new ReservationReceiptForm(CurrentUserName, SeatNumber, date, time);
            receiptForm.ShowDialog();

            // Close the confirmation form
            this.Close();
        }

        // Event handler for the Cancel button click
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        // Method to save reservation data to the database
        private void SaveReservationToDatabase(string username, string seat, string date, string time)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    connection.Open();

                    // Updated SQL query to use the correct column name for username
                    string query = "INSERT INTO [dbo].[Reservations] (Seat, Name, Date, Time) " +
                                   "VALUES (@seat, @name, @date, @time)";

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the parameters to the query to prevent SQL injection
                        command.Parameters.AddWithValue("@seat", seat);
                        command.Parameters.AddWithValue("@name", username);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@time", time);

                        // Execute the query to save the reservation
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Event handlers for the TextBox controls to manage placeholder text behavior
        private void TxtDate_Enter(object sender, EventArgs e)
        {
            if (txtDate.Text == "Enter Date (YYYY-MM-DD)")
            {
                txtDate.Text = ""; // Clear placeholder text
                txtDate.ForeColor = System.Drawing.Color.Black; // Change text color to black
            }
        }

        private void TxtDate_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDate.Text))
            {
                txtDate.Text = "Enter Date (YYYY-MM-DD)"; // Reset placeholder text if empty
                txtDate.ForeColor = System.Drawing.Color.Gray; // Change text color back to gray
            }
        }

        private void TxtTime_Enter(object sender, EventArgs e)
        {
            if (txtTime.Text == "Enter Time (HH:MM)")
            {
                txtTime.Text = ""; // Clear placeholder text
                txtTime.ForeColor = System.Drawing.Color.Black; // Change text color to black
            }
        }

        private void TxtTime_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTime.Text))
            {
                txtTime.Text = "Enter Time (HH:MM)"; // Reset placeholder text if empty
                txtTime.ForeColor = System.Drawing.Color.Gray; // Change text color back to gray
            }
        }
    }
}
