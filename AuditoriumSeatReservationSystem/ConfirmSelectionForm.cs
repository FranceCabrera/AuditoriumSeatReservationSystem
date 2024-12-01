using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class ConfirmSelectionForm : Form
    {
        // Properties for the selected seat and current user
        public string SeatNumber { get; set; }
        public string UserName { get; set; }

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30;";

        public ConfirmSelectionForm(string seatNumber, string currentUserName)
        {
            InitializeComponent();
            SeatNumber = seatNumber;
            UserName = currentUserName;
        }

        private void ConfirmSelectionForm_Load(object sender, EventArgs e)
        {
            // Display seat number and username in the labels
            lblSeatNumber.Text = $"Seat Number: {SeatNumber}";
            lblCurrentUser.Text = $"Reserved by: {UserName}";
        }

        private void BtnReserveSeat_Click(object sender, EventArgs e)
        {
            string date = txtDate.Text;
            string time = txtTime.Text;

            // Validate the date and time inputs
            if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(time))
            {
                MessageBox.Show("Please enter valid date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsSeatStillAvailable(SeatNumber))
            {
                MessageBox.Show("This seat has already been reserved by another user.", "Seat Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save the reservation in the database
            SaveReservationToDatabase(UserName, SeatNumber, date, time);

            MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Pass the data to ReservationReceiptForm and show it
            ReservationReceiptForm receiptForm = new ReservationReceiptForm(UserName, SeatNumber, date, time);
            receiptForm.ShowDialog();

            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private bool IsSeatStillAvailable(string seat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Reservations WHERE Seat = @Seat";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Seat", seat);
                    int count = (int)command.ExecuteScalar();
                    return count == 0; 
                }
            }
        }

        private void SaveReservationToDatabase(string username, string seat, string date, string time)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Reservations (Seat, Name, Date, Time)
                        VALUES (@Seat, @Name, @Date, @Time)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Seat", seat);
                        command.Parameters.AddWithValue("@Name", username);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Time", time);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Placeholder text handlers for Date and Time fields
        private void TxtDate_Enter(object sender, EventArgs e)
        {
            if (txtDate.Text == "Enter Date (YYYY-MM-DD)")
            {
                txtDate.Text = ""; 
                txtDate.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TxtTime_Enter(object sender, EventArgs e)
        {
            if (txtTime.Text == "Enter Time (HH:MM)")
            {
                txtTime.Text = "";
                txtTime.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}
