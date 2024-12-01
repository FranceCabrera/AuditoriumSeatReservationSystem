using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    partial class ReservationReceiptForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblBookingID;
        private Label lblName;
        private Label lblSeatNumber;
        private Label lblDate;
        private Label lblTime;
        private Button btnClose;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize the layout components.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSeatNumber = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reservation Receipt";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBookingID
            // 
            this.lblBookingID.Font = new System.Drawing.Font("Arial", 10F);
            this.lblBookingID.Location = new System.Drawing.Point(12, 50);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(360, 25);
            this.lblBookingID.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblName.Location = new System.Drawing.Point(12, 85);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(360, 25);
            this.lblName.TabIndex = 2;
            // 
            // lblSeatNumber
            // 
            this.lblSeatNumber.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSeatNumber.Location = new System.Drawing.Point(12, 120);
            this.lblSeatNumber.Name = "lblSeatNumber";
            this.lblSeatNumber.Size = new System.Drawing.Size(360, 25);
            this.lblSeatNumber.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDate.Location = new System.Drawing.Point(12, 155);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(360, 25);
            this.lblDate.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTime.Location = new System.Drawing.Point(12, 190);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(360, 25);
            this.lblTime.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F);
            this.btnClose.Location = new System.Drawing.Point(140, 230);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ReservationReceiptForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSeatNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblBookingID);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReservationReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation Receipt";
            this.ResumeLayout(false);

        }
    }
}
