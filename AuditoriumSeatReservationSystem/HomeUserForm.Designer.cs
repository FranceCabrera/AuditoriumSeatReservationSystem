using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    partial class HomeUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnReserveNow;
        private Button btnMyReservation;
        private Button btnLogout;
        private System.Windows.Forms.Label lblWelcome; // Declare the welcome label

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeUserForm));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnReserveNow = new System.Windows.Forms.Button();
            this.btnMyReservation = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(95, 46);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(350, 30);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "Welcome, [User]!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReserveNow
            // 
            this.btnReserveNow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReserveNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnReserveNow.Location = new System.Drawing.Point(171, 144);
            this.btnReserveNow.Name = "btnReserveNow";
            this.btnReserveNow.Size = new System.Drawing.Size(200, 50);
            this.btnReserveNow.TabIndex = 0;
            this.btnReserveNow.Text = "Reserve Now";
            this.btnReserveNow.UseVisualStyleBackColor = true;
            this.btnReserveNow.Click += new System.EventHandler(this.btnReserveNow_Click);
            // 
            // btnMyReservation
            // 
            this.btnMyReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnMyReservation.Location = new System.Drawing.Point(171, 236);
            this.btnMyReservation.Name = "btnMyReservation";
            this.btnMyReservation.Size = new System.Drawing.Size(200, 50);
            this.btnMyReservation.TabIndex = 1;
            this.btnMyReservation.Text = "My Reservation";
            this.btnMyReservation.UseVisualStyleBackColor = true;
            this.btnMyReservation.Click += new System.EventHandler(this.btnMyReservation_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLogout.Location = new System.Drawing.Point(171, 333);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 50);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // HomeUserForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(571, 498);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnReserveNow);
            this.Controls.Add(this.btnMyReservation);
            this.Controls.Add(this.btnLogout);
            this.Name = "HomeUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Home";
            this.ResumeLayout(false);

        }
    }
}