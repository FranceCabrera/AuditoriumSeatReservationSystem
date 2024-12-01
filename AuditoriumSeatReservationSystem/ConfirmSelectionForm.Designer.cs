namespace AuditoriumSeatReservationSystem
{
    partial class ConfirmSelectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSeatNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCurrentUser;
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
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnReserveSeat = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSeatNumber
            // 
            this.lblSeatNumber.AutoSize = true;
            this.lblSeatNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeatNumber.ForeColor = System.Drawing.Color.White;
            this.lblSeatNumber.Location = new System.Drawing.Point(27, 32);
            this.lblSeatNumber.Name = "lblSeatNumber";
            this.lblSeatNumber.Size = new System.Drawing.Size(146, 30);
            this.lblSeatNumber.TabIndex = 0;
            this.lblSeatNumber.Text = "Seat Number: ";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Location = new System.Drawing.Point(263, 32);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(135, 30);
            this.lblCurrentUser.TabIndex = 1;
            this.lblCurrentUser.Text = "Reserved by: ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(27, 93);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(69, 32);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(268, 93);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(72, 32);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time:";
            // 
            // txtDate
            // 
            this.txtDate.ForeColor = System.Drawing.Color.Gray;
            this.txtDate.Location = new System.Drawing.Point(102, 105);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(150, 20);
            this.txtDate.TabIndex = 4;
            this.txtDate.Text = "Enter Date (YYYY-MM-DD)";
            this.txtDate.Enter += new System.EventHandler(this.TxtDate_Enter);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(335, 103);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 5;
            // 
            // btnReserveSeat
            // 
            this.btnReserveSeat.BackColor = System.Drawing.Color.Green;
            this.btnReserveSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserveSeat.ForeColor = System.Drawing.Color.White;
            this.btnReserveSeat.Location = new System.Drawing.Point(296, 167);
            this.btnReserveSeat.Name = "btnReserveSeat";
            this.btnReserveSeat.Size = new System.Drawing.Size(102, 48);
            this.btnReserveSeat.TabIndex = 6;
            this.btnReserveSeat.Text = "Reserve";
            this.btnReserveSeat.UseVisualStyleBackColor = false;
            this.btnReserveSeat.Click += new System.EventHandler(this.BtnReserveSeat_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(152, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 48);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ConfirmSelectionForm
            // 
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(535, 230);
            this.Controls.Add(this.lblSeatNumber);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnReserveSeat);
            this.Controls.Add(this.btnCancel);
            this.Name = "ConfirmSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm Seat Selection";
            this.Load += new System.EventHandler(this.ConfirmSelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
