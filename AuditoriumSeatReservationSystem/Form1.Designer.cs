using System;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    partial class Form1
    {
        private Button btnLogin;
        private Button btnRegister;

        private void InitializeComponent()
        {
            this.btnLogin = new Button();
            this.btnRegister = new Button();

            // Login Button
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new System.Drawing.Point(150, 100);
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Register Button
            this.btnRegister.Text = "Sign Up";
            this.btnRegister.Location = new System.Drawing.Point(150, 150);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // Home Form
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);
            this.Text = "Home";
            this.Size = new System.Drawing.Size(400, 300);
        }
    }
}