namespace AuditoriumSeatReservationSystem
{
    partial class ConfirmSelectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSeatNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCurrentUser;  // Add this label for displaying the current user's name
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnReserveSeat;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSeatNumber = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();  // Initialize the label
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnReserveSeat = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // lblSeatNumber
            this.lblSeatNumber.AutoSize = true;
            this.lblSeatNumber.Location = new System.Drawing.Point(30, 20);
            this.lblSeatNumber.Name = "lblSeatNumber";
            this.lblSeatNumber.Size = new System.Drawing.Size(90, 13);
            this.lblSeatNumber.TabIndex = 0;
            this.lblSeatNumber.Text = "Seat Number: ";

            // lblCurrentUser
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(30, 40); // Position the label below the seat number
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(90, 13);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "Reserved by: ";

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(30, 80);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date:";

            // lblTime
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(30, 120);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time:";

            // txtDate
            this.txtDate.Location = new System.Drawing.Point(100, 80);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(150, 20);
            this.txtDate.TabIndex = 4;
            this.txtDate.Text = "Enter Date (YYYY-MM-DD)";
            this.txtDate.ForeColor = System.Drawing.Color.Gray;
            this.txtDate.Enter += new System.EventHandler(this.TxtDate_Enter);
            this.txtDate.Leave += new System.EventHandler(this.TxtDate_Leave);

            // txtTime
            this.txtTime.Location = new System.Drawing.Point(100, 120);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(150, 20);
            this.txtTime.TabIndex = 5;
            this.txtTime.Text = "Enter Time (HH:MM)";
            this.txtTime.ForeColor = System.Drawing.Color.Gray;
            this.txtTime.Enter += new System.EventHandler(this.TxtTime_Enter);
            this.txtTime.Leave += new System.EventHandler(this.TxtTime_Leave);

            // btnReserveSeat
            this.btnReserveSeat.Location = new System.Drawing.Point(30, 160);
            this.btnReserveSeat.Name = "btnReserveSeat";
            this.btnReserveSeat.Size = new System.Drawing.Size(90, 30);
            this.btnReserveSeat.TabIndex = 6;
            this.btnReserveSeat.Text = "Reserve";
            this.btnReserveSeat.UseVisualStyleBackColor = true;
            this.btnReserveSeat.Click += new System.EventHandler(this.BtnReserveSeat_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(160, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // ConfirmSelectionForm
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblSeatNumber);
            this.Controls.Add(this.lblCurrentUser);  // Add the label to the form
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnReserveSeat);
            this.Controls.Add(this.btnCancel);
            this.Name = "ConfirmSelectionForm";
            this.Text = "Confirm Seat Selection";
            this.Load += new System.EventHandler(this.ConfirmSelectionForm_Load);
        }
    }
}
