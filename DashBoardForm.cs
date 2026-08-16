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
    public partial class DashBoardForm : Form
    {
        string connStr = "server=localhost;user id=root;password=;database=restaurant";
        public DashBoardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPage page = new AdminPage();
            this.Hide();
            page.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DashBoardForm_Load(object sender, EventArgs e)
        {
            string query = @"SELECT 
                c.customer_name,
                o.order_id,
                p.item_name,
                od.quantity,
                o.status
            FROM orders o
            JOIN customer c ON o.customer_id = c.customer_id
            JOIN order_details od ON o.order_id = od.order_id
            JOIN products p ON od.product_id = p.product_id;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt;
            }   
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }
    }
}
