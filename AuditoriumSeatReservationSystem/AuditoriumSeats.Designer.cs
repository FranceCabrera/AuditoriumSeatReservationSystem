using System.Drawing;
using System.Windows.Forms;
using System;

namespace AuditoriumSeatReservationSystem
{
    partial class AuditoriumSeats
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnBack;
        private Button btnReserve;
        private Label lblStage;

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStage = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStage
            // 
            this.lblStage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStage.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblStage.Location = new System.Drawing.Point(0, 0);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(1052, 50);
            this.lblStage.TabIndex = 0;
            this.lblStage.Text = "STAGE";
            this.lblStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(50, 500);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 40);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(800, 500);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(100, 40);
            this.btnReserve.TabIndex = 2;
            this.btnReserve.Text = "Reserve";
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // AuditoriumSeats
            // 
            this.ClientSize = new System.Drawing.Size(1052, 582);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReserve);
            this.Name = "AuditoriumSeats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditorium Seats";
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Clean up any resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
