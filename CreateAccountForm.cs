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
    public partial class CreateAccountForm : Form
    {
        string connStr = "server=localhost;user id=root;password=;database=restaurant";
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
        }
    }
}
