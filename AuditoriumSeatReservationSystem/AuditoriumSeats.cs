using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class AuditoriumSeats : Form
    {
        private string currentUser;
        private string selectedSeat;
        private Dictionary<Button, bool> seatAvailability; 

        public AuditoriumSeats(string username)
        {
            currentUser = username;
            InitializeComponent();
            InitializeSeats(); 
            LoadReservations(); 
        }

        private void InitializeSeats()
        {
            seatAvailability = new Dictionary<Button, bool>();

            // Define seat dimensions and spacing
            int seatSize = 40;
            int padding = 10;
            int aisleSpacing = 80; 

            // --- Left Section ---
            int[] leftCols = { 5, 6, 7, 8, 9 };
            int leftOffsetX = 20;
            int leftOffsetY = 20;

            for (int row = 0; row < leftCols.Length; row++)
            {
                for (int col = 0; col < leftCols[row]; col++)
                {
                    Button seatButton = new Button
                    {
                        Name = $"btnSeat_Left_{row}_{col}",
                        Size = new Size(seatSize, seatSize),
                        Location = new Point(leftOffsetX + (col * (seatSize + padding)), leftOffsetY + (row * (seatSize + padding))),
                        BackColor = Color.Green,
                        Text = $"L {row + 1}-{col + 1}" // Add "L" prefix for Left section
                    };

                    seatButton.Click += SeatButton_Click;
                    seatAvailability[seatButton] = true; // Seat is available
                    this.Controls.Add(seatButton);
                }
            }

            // --- Middle Section ---
            int middleRows = 6;
            int middleCols = 14;
            int middleOffsetX = leftOffsetX + (leftCols.Max() * (seatSize + padding)) + aisleSpacing;
            int middleOffsetY = 20;

            for (int row = 0; row < middleRows; row++)
            {
                for (int col = 0; col < middleCols; col++)
                {
                    Button seatButton = new Button
                    {
                        Name = $"btnSeat_Middle_{row}_{col}",
                        Size = new Size(seatSize, seatSize),
                        Location = new Point(middleOffsetX + (col * (seatSize + padding)), middleOffsetY + (row * (seatSize + padding))),
                        BackColor = Color.Green,
                        Text = $"M {row + 1}-{col + 1}" // "M" prefix for Middle section
                    };

                    seatButton.Click += SeatButton_Click;
                    seatAvailability[seatButton] = true;
                    this.Controls.Add(seatButton);
                }
            }

            // --- Right Section ---
            int[] rightCols = { 5, 6, 7, 8, 9 };
            int rightOffsetX = middleOffsetX + (middleCols * (seatSize + padding)) + aisleSpacing;
            int rightOffsetY = 20;

            for (int row = 0; row < rightCols.Length; row++)
            {
                for (int col = 0; col < rightCols[row]; col++)
                {
                    Button seatButton = new Button
                    {
                        Name = $"btnSeat_Right_{row}_{col}",
                        Size = new Size(seatSize, seatSize),
                        Location = new Point(rightOffsetX + (col * (seatSize + padding)), rightOffsetY + (row * (seatSize + padding))),
                        BackColor = Color.Green,
                        Text = $"R {row + 1}-{col + 1}" // "R" prefix for Right section
                    };

                    seatButton.Click += SeatButton_Click;
                    seatAvailability[seatButton] = true;
                    this.Controls.Add(seatButton);
                }
            }

            AddLegend();
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button clickedSeat = sender as Button;

            if (seatAvailability[clickedSeat]) 
            {
                // Reset previously selected seat
                if (!string.IsNullOrEmpty(selectedSeat))
                {
                    List<Button> seatsToUpdate = new List<Button>(); // Temporary list to hold seats to update

                    foreach (var seat in seatAvailability.Keys)
                    {
                        if (seat.Text == selectedSeat)
                        {
                            seatsToUpdate.Add(seat); // Add seats that need updating to the list
                        }
                    }

                    // Apply the color update after the loop completes
                    foreach (var seat in seatsToUpdate)
                    {
                        seat.BackColor = Color.Green; // Reset the previously selected seat to available
                    }
                }

                clickedSeat.BackColor = Color.Yellow;
                selectedSeat = clickedSeat.Text;
            }
            else
            {
                MessageBox.Show("This seat is already reserved or unavailable.", "Seat Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnReserve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSeat))
            {
                MessageBox.Show("Please select a seat to reserve.", "No Seat Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsSeatReserved(selectedSeat))
            {
                MessageBox.Show("This seat has already been reserved.", "Seat Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmForm = new ConfirmSelectionForm(selectedSeat, currentUser);
            confirmForm.ShowDialog();
            LoadReservations();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            HomeUserForm homeUserForm = new HomeUserForm(currentUser); 
            homeUserForm.Show();
            this.Hide();
        }

        private void AddLegend()
        {
            Label lblAvailable = new Label
            {
                Text = "Available Seats",
                BackColor = Color.Green,
                Width = 150,
                Height = 30,
                Location = new Point(50, 450)
            };

            Label lblReserved = new Label
            {
                Text = "Reserved Seats",
                BackColor = Color.Red,
                Width = 150,
                Height = 30,
                Location = new Point(250, 450)
            };

            Label lblSelected = new Label
            {
                Text = "Selected Seat",
                BackColor = Color.Yellow,
                Width = 150,
                Height = 30,
                Location = new Point(450, 450)
            };

            this.Controls.Add(lblAvailable);
            this.Controls.Add(lblReserved);
            this.Controls.Add(lblSelected);
        }

        private void LoadReservations()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Seat, Name FROM Reservations";
                using (var cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string reservedSeatName = reader.GetString(0); 
                        string reservedByName = reader.GetString(1);  

                        List<Button> seatsToUpdate = new List<Button>(); // Temporary list to hold seats to update

                        foreach (var seat in seatAvailability.Keys)
                        {
                            if (seat.Text == reservedSeatName)
                            {
                                seatsToUpdate.Add(seat); 
                            }
                        }

                        // Now apply the updates for the reserved seats after the loop
                        foreach (var seat in seatsToUpdate)
                        {
                            seat.Text = $"{reservedSeatName}\n({reservedByName})";
                            seat.BackColor = Color.Red;
                            seat.Enabled = false;
                            seatAvailability[seat] = false; 
                        }
                    }
                }
            }
        }

        private bool IsSeatReserved(string seat)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Reservations WHERE Seat = @Seat";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Seat", seat);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; 
                }
            }
        }

        private void AuditoriumSeats_Load(object sender, EventArgs e)
        {

        }
    }
}
