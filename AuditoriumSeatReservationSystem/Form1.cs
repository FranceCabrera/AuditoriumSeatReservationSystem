﻿using System;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // Open the Login Form
            this.Hide(); // Hide the Home Form
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show(); // Open the Register Form
            this.Hide(); // Hide the Home Form
        }
    }
}
