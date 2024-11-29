using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class AuditoriumSeats : Form
    {
        private string currentUser;
        private string selectedSeat; // Holds the selected seat

        public AuditoriumSeats(string username)
        {
            currentUser = username;
            InitializeComponent();
            GenerateAuditoriumLayout();
            LoadReservations();
        }

        private void GenerateAuditoriumLayout()
        {
            // Create seat sections
            CreateSection(5, 5, 50, 100, "LeftSection", 50, 50, Color.LightGray);
            CreateSection(5, 10, 400, 100, "MiddleSection", 50, 50, Color.LightGray);
            CreateSection(5, 5, 750, 100, "RightSection", 50, 50, Color.LightGray);

            AddLegend();
        }

        private void CreateSection(int rows, int cols, int startX, int startY, string sectionName, int buttonWidth, int buttonHeight, Color defaultColor)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Button seat = new Button
                    {
                        Name = $"{sectionName}_R{row}_C{col}",
                        Text = $"{sectionName[0]}{row + 1}{col + 1}",
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(startX + col * buttonWidth, startY + row * buttonHeight),
                        BackColor = defaultColor
                    };
                    seat.Click += Seat_Click;
                    this.Controls.Add(seat);
                }
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button clickedSeat = sender as Button;

            if (clickedSeat.BackColor == Color.LightGray) // Available
            {
                if (!string.IsNullOrEmpty(selectedSeat))
                {
                    // Reset previous selection
                    foreach (Control control in this.Controls)
                    {
                        if (control is Button btn && btn.Text == selectedSeat)
                        {
                            btn.BackColor = Color.LightGray;
                        }
                    }
                }

                clickedSeat.BackColor = Color.Red;
                selectedSeat = clickedSeat.Text; // Store the selected seat
            }
            else if (clickedSeat.BackColor == Color.Red) // Already selected
            {
                clickedSeat.BackColor = Color.LightGray;
                selectedSeat = null; // Deselect
            }
            else if (clickedSeat.BackColor == Color.Green) // Reserved for disabled
            {
                MessageBox.Show("This seat is reserved for disabled users!");
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSeat))
            {
                MessageBox.Show("Please select a seat to reserve.", "No Seat Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmForm = new ConfirmSelectionForm(selectedSeat, currentUser);
            confirmForm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void AddLegend()
        {
            Label lblAvailable = new Label
            {
                Text = "Available Seats",
                BackColor = Color.LightGray,
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

            Label lblDisabled = new Label
            {
                Text = "Disabled Seats",
                BackColor = Color.Green,
                Width = 150,
                Height = 30,
                Location = new Point(450, 450)
            };

            this.Controls.Add(lblAvailable);
            this.Controls.Add(lblReserved);
            this.Controls.Add(lblDisabled);
        }

        private void LoadReservations()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Seat FROM Reservations WHERE Name = @Name";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", currentUser);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string reservedSeatName = reader.GetString(0);
                        foreach (Control control in this.Controls)
                        {
                            if (control is Button seat && seat.Name == reservedSeatName)
                            {
                                seat.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }
    }
}
