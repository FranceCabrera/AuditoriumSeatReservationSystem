using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    partial class AuditoriumSeats
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnBack;
        private Button btnReserve;

        /// <summary>
        /// Dispose resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize components.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(266, 551);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 39);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(654, 551);
            this.btnReserve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(123, 39);
            this.btnReserve.TabIndex = 1;
            this.btnReserve.Text = "Confirm";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.BtnReserve_Click);
            // 
            // AuditoriumSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1056, 694);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReserve);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AuditoriumSeats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditorium Seat Reservation";
            this.Load += new System.EventHandler(this.AuditoriumSeats_Load);
            this.ResumeLayout(false);

        }
    }
}
