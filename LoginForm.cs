using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RestaurantManagementOrderingSystem
{
    public partial class LoginForm : Form
    {
        string connStr = "server=localhost;user id=root;password=;database=restaurant";
        private string username;
        private string password;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            username = textBox1.Text.Trim();
            password = textBox2.Text.Trim();

            if (username == "Admin" && password == "1234")
            {
                AdminPage adminPage = new AdminPage();
                adminPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
