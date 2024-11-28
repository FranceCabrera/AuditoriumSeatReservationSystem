using System;
using System.Drawing;
using System.Windows.Forms;

public class AuditoriumSeatsDesign : Form
{
    public AuditoriumSeatsDesign()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Form settings
        this.Text = "Auditorium Seats Layout";
        this.Size = new Size(900, 600); // Set the window size
        this.StartPosition = FormStartPosition.CenterScreen;

        // Add Stage Label
        Label lblStage = new Label
        {
            Text = "STAGE",
            Font = new Font("Arial", 18, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Color.LightGray
        };
        this.Controls.Add(lblStage);

        // Create sections
        CreateSection(5, 5, 50, 100, "LeftSection", 50, 50, Color.Green);    // Left Section (Disabled Seats)
        CreateSection(5, 10, 300, 100, "MiddleSection", 50, 50, Color.LightGray); // Middle Section (Available Seats)
        CreateSection(5, 5, 700, 100, "RightSection", 50, 50, Color.LightGreen);  // Right Section (Special Disabled Seats)

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
                    BackColor = defaultColor,
                    FlatStyle = FlatStyle.Flat
                };
                seat.Click += Seat_Click; // Add click event to handle future seat interactions
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
        else if (clickedSeat.BackColor == Color.Green || clickedSeat.BackColor == Color.LightGreen) // Disabled Reserved
        {
            MessageBox.Show("This seat is reserved for disabled users!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void AddLegend()
    {
        // Create Legend Section
        Label lblAvailable = new Label
        {
            Text = "Available Seats",
            BackColor = Color.LightGray,
            Width = 150,
            Height = 30,
            Location = new Point(50, 450),
            BorderStyle = BorderStyle.FixedSingle
        };

        Label lblReserved = new Label
        {
            Text = "Reserved Seats",
            BackColor = Color.Red,
            Width = 150,
            Height = 30,
            Location = new Point(250, 450),
            BorderStyle = BorderStyle.FixedSingle
        };

        Label lblDisabled = new Label
        {
            Text = "Disabled Seats",
            BackColor = Color.Green,
            Width = 150,
            Height = 30,
            Location = new Point(450, 450),
            BorderStyle = BorderStyle.FixedSingle
        };

        Label lblSpecialDisabled = new Label
        {
            Text = "Special Disabled Seats",
            BackColor = Color.LightGreen,
            Width = 150,
            Height = 30,
            Location = new Point(650, 450),
            BorderStyle = BorderStyle.FixedSingle
        };

        // Add Legend to Form
        this.Controls.Add(lblAvailable);
        this.Controls.Add(lblReserved);
        this.Controls.Add(lblDisabled);
        this.Controls.Add(lblSpecialDisabled);
    }

}