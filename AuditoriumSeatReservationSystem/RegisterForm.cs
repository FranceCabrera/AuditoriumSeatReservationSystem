using System;
using System.Windows.Forms;

namespace AuditoriumSeatReservationSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registration Successful!");
            Form1 homeForm = new Form1();
            homeForm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
