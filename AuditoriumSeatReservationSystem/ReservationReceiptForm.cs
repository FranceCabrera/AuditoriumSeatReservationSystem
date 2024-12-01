using System;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class ReservationReceiptForm : Form
    {
        public ReservationReceiptForm(string username, string seat, string date, string time)
        {
            InitializeComponent();

            Random random = new Random();
            int bookingId = random.Next(10000, 100000);

            lblBookingID.Text = $"Booking ID: {bookingId}";
            lblName.Text = $"Name: {username}";
            lblSeatNumber.Text = $"Seat Number: {seat}";
            lblDate.Text = $"Date: {date}";
            lblTime.Text = $"Time: {time}";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
