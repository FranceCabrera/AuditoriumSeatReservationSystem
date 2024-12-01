using System;
using System.Data.SqlClient;
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
            string studentID = txtStudentNo.Text.Trim();  
            string name = txtName.Text.Trim();           
            string username = txtUsername.Text.Trim();   
            string password = txtPassword.Text.Trim();   
            string email = txtEmail.Text.Trim();         
            string course = txtCourse.Text.Trim();       
            string year = txtYear.Text.Trim();           
            string section = txtSection.Text.Trim();     

            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(course) ||
                string.IsNullOrEmpty(year) || string.IsNullOrEmpty(section))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                if (!IsValidEmail(email))
                {
                    throw new Exception("Email must end with @umak.edu.ph.");
                }

                if (CheckIfUserExists(username))
                {
                    throw new Exception("Username already exists. Please choose another one.");
                }
                RegisterUser(studentID, name, username, password, email, course, year, section);

               
                MessageBox.Show("Registration Successful!");
                Form1 homeForm = new Form1();
                homeForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            // Check if the email ends with @umak.edu.ph
            return email.EndsWith("@umak.edu.ph", StringComparison.OrdinalIgnoreCase);
        }

        private bool CheckIfUserExists(string username)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";
            bool userExists = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = (int)cmd.ExecuteScalar();
                    userExists = count > 0;
                }
            }

            return userExists;
        }

        private void RegisterUser(string studentID, string name, string username, string password, string email, string course, string year, string section)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string insertQuery = "INSERT INTO Users (StudentID, Name, Username, Password, Email, Course, Year, Section) " +
                                     "VALUES (@StudentID, @Name, @Username, @Password, @Email, @Course, @Year, @Section)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Course", course);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
