using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AuditoriumSeatReservationSystem
{
    public partial class AdminPanel : Form
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Frank\Documents\AuditoriumSeatSystem.mdf;Integrated Security=True;Connect Timeout=30";

        public AdminPanel()
        {
            InitializeComponent();
            LoadReservations();
        }

        private void LoadReservations()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, Name, Seat, Date, Time FROM Reservations";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvReservations.DataSource = table;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Reservations (Name, Seat, Date, Time) VALUES (@Name, @Seat, @Date, @Time)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Seat", txtSeat.Text);
                        cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                        cmd.Parameters.AddWithValue("@Time", txtTime.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Reservation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations();
                ClearFields();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0 && ValidateInputs())
            {
                int id = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["Id"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Reservations SET Name = @Name, Seat = @Seat, Date = @Date, Time = @Time WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Seat", txtSeat.Text);
                        cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                        cmd.Parameters.AddWithValue("@Time", txtTime.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a reservation to edit and ensure all fields are filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["Id"].Value);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Reservations WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Reservation deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations();
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void DgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReservations.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSeat.Text = row.Cells["Seat"].Value.ToString();
                txtDate.Text = row.Cells["Date"].Value.ToString();
                txtTime.Text = row.Cells["Time"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtSeat.Clear();
            txtDate.Clear();
            txtTime.Clear();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSeat.Text) ||
                string.IsNullOrWhiteSpace(txtDate.Text) || string.IsNullOrWhiteSpace(txtTime.Text))
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
