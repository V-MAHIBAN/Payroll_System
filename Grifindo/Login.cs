using Grifindo.UniversalClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=MAHIBAN\\SQLEXPRESS;Initial Catalog=Grifindo;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            string username = UserName_txt.Text;
            string password = Password_txt.Text;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login successful!");
                // Navigate to your main application form
                // e.g., MainAppForm mainForm = new MainAppForm();
                // mainForm.Show();
                // Open the main application form
                Grifindo_DashBoard mainForm = new Grifindo_DashBoard();
                mainForm.Show();

                // Optionally, you can hide the login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid UserName & Password. Please try again.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT COUNT(*) FROM Administration WHERE Admin_UserName = @username AND Admin_Password = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int result = (int)command.ExecuteScalar();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the login form when cancel button is clicked
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
    
}
