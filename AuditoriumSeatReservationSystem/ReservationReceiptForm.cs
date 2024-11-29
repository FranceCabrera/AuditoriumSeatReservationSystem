using System;
using System.Windows.Forms;

public partial class ReservationReceiptForm : Form
{
    public ReservationReceiptForm(string username, string seat, string date, string time)
    {
        InitializeComponent();

        // Generate a random 5-digit booking ID (between 10000 and 99999)
        Random random = new Random();
        int bookingId = random.Next(10000, 100000); // Generates a random number between 10000 and 99999

        lblBookingID.Text = $"Booking ID: {bookingId}";
        lblName.Text = $"Name: {username}";
        lblSeatNumber.Text = $"Seat Number: {seat}";
        lblDate.Text = $"Date: {date}";
        lblTime.Text = $"Time: {time}";
    }
}
