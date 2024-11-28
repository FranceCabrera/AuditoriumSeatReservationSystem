using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

public partial class AuditoriumSeats : Form
{
    private string currentUser;

    // Updated constructor that accepts the username
    public AuditoriumSeats(string username)
    {
        InitializeComponent();
        currentUser = username;  // Store the username for later use
        GenerateAuditoriumLayout();
        LoadReservations(); // Load existing reservations when the form is loaded
    }

    private void GenerateAuditoriumLayout()
    {
        this.Controls.Clear();

        // Add Stage Label
        Label lblStage = new Label
        {
            Text = "STAGE",
            Font = new Font("Arial", 16, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50
        };
        this.Controls.Add(lblStage);

        // Create seat sections
        CreateSection(5, 5, 50, 100, "LeftSection", 50, 50, Color.LightGray);
        CreateSection(5, 10, 400, 100, "MiddleSection", 50, 50, Color.LightGray);
        CreateSection(5, 5, 750, 100, "RightSection", 50, 50, Color.LightGray);

        // Add Save Button
        AddSaveButton();

        // Add Legend
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
            clickedSeat.BackColor = Color.Red; // Reserved
        }
        else if (clickedSeat.BackColor == Color.Red) // Reserved
        {
            clickedSeat.BackColor = Color.LightGray; // Available
        }
        else if (clickedSeat.BackColor == Color.Green) // Disabled Reserved
        {
            MessageBox.Show("This seat is reserved for disabled users!");
        }
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

    private void AddSaveButton()
    {
        Button btnSaveReservations = new Button
        {
            Text = "Save Reservations",
            Location = new Point(650, 450),
            Size = new Size(150, 40)
        };
        btnSaveReservations.Click += btnSaveReservations_Click;
        this.Controls.Add(btnSaveReservations);
    }

    private void btnSaveReservations_Click(object sender, EventArgs e)
    {
        SaveReservations();
    }

    private void SaveReservations()
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Delete previous reservations for the current user
            string deleteQuery = "DELETE FROM Reservations WHERE Username = @Username";
            using (var deleteCmd = new SqlCommand(deleteQuery, conn))
            {
                deleteCmd.Parameters.AddWithValue("@Username", currentUser);
                deleteCmd.ExecuteNonQuery();
            }

            // Insert current reservations
            foreach (Control control in this.Controls)
            {
                if (control is Button seat && seat.BackColor == Color.Red) // Only save reserved seats
                {
                    string insertQuery = "INSERT INTO Reservations (Seat, Username) VALUES (@Seat, @Username)";
                    using (var insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Seat", seat.Name);
                        insertCmd.Parameters.AddWithValue("@Username", currentUser);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Reservations saved successfully!");
        }
    }

    private void LoadReservations()
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT Seat FROM Reservations WHERE Username = @Username";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", currentUser);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string reservedSeatName = reader.GetString(0);
                    foreach (Control control in this.Controls)
                    {
                        if (control is Button seat && seat.Name == reservedSeatName)
                        {
                            seat.BackColor = Color.Red; // Mark as reserved
                        }
                    }
                }
            }
        }
    }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // AuditoriumSeats
        // 
        this.ClientSize = new System.Drawing.Size(985, 575);
        this.Name = "AuditoriumSeats";
        this.Load += new System.EventHandler(this.AuditoriumSeats_Load);
        this.ResumeLayout(false);

    }

    private void AuditoriumSeats_Load(object sender, EventArgs e)
    {

    }
}
