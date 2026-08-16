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
    public partial class OrderHistory : Form
    {
        string connStr = "server=localhost;user id=root;password=;database=restaurant";
        public OrderHistory()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Hide();
            adminPage.Show();
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
            SELECT
                o.order_id,
                c.customer_name,
                o.date,
                o.total_amount,
                o.status
            FROM orders o
            INNER JOIN customer c ON o.customer_id = c.customer_id
            WHERE o.status <> 'Pending'
            ORDER BY o.date DESC;
        ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
            SELECT
                o.order_id,
                c.customer_name,
                o.date,
                o.total_amount,
                o.status
            FROM orders o
            INNER JOIN customer c ON o.customer_id = c.customer_id
            WHERE o.status <> 'Pending'
            ORDER BY o.date DESC;
        ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            dataGridView2.DataSource = null;

            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int orderId = Convert.ToInt32(row.Cells["order_id"].Value);

                // SET LABELS
                label6.Text = row.Cells["order_id"].Value.ToString();
                label7.Text = row.Cells["customer_name"].Value.ToString();
                label8.Text = Convert.ToDateTime(row.Cells["date"].Value).ToString("yyyy-MM-dd");
                label9.Text = Convert.ToDecimal(row.Cells["total_amount"].Value).ToString("0.00");

                // LOAD ORDER DETAILS INTO SECOND GRID
                using (MySqlConnection con = new MySqlConnection(connStr))
                {
                    con.Open();

                    string query = @"
                SELECT
                    p.item_name AS product_name,
                    od.quantity,
                    od.price AS item_price
                FROM order_details od
                INNER JOIN products p ON od.product_id = p.product_id
                WHERE od.order_id = @order_id;
            ";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@order_id", orderId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
            }
        }
    }
}
