using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RestaurantManagementOrderingSystem
{
    public partial class AdminPage : Form
    {
        string connStr = "server=localhost;user id=root;password=;database=restaurant";
        public AdminPage() 
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DashBoardForm dash = new DashBoardForm();
            dash.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            this.Hide();
            inventoryForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderAndMenuPageForm orderAndMenuPageForm = new OrderAndMenuPageForm();
            this.Hide();
            orderAndMenuPageForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory();
            this.Hide();
            orderHistory.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm();
            this.Hide();
            createAccountForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           LoginForm loginForm = new LoginForm();
           this.Close();
           loginForm.Show();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
        }
    }
}
