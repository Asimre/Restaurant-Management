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
    public partial class OrderAndMenuPageForm : Form
    {
        string connStr = "server=localhost;user id=root;password=;database=restaurant";

        int selectedProductId;
        int currentOrderId;

        int selectedOrderDetailId = 0;

        public OrderAndMenuPageForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Hide();
            adminPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void OrderAndMenuPageForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
                    SELECT product_id, item_name 
                    FROM products 
                    ORDER BY product_id DESC 
                    LIMIT 20
                    ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                // Put buttons in an array for easy looping
                Button[] buttons = {
                    button1, button9, button11, button10, button15,
                    button20, button19, button17, button18, button16,
                    button12, button13, button14, button27, button26,
                    button23, button22, button21, button25, button24
                    };

                int i = 0;

                while (reader.Read() && i < buttons.Length)
                {
                    buttons[i].Text = reader["item_name"].ToString();

                    buttons[i].Tag = reader["product_id"];
                    i++;
                }

                // Optional: clear remaining buttons if fewer than 10 items
                for (; i < buttons.Length; i++)
                {
                    buttons[i].Text = "---";
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblitem_name.Text = btn.Text;

            if (btn.Tag != null)
            {
                selectedProductId = Convert.ToInt32(btn.Tag);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                int customerId;

                // 1. CHECK IF CUSTOMER EXISTS
                string getCustomer = @"
        SELECT customer_id 
        FROM customer 
        WHERE customer_name = @name;
    ";

                MySqlCommand cmdCustomer = new MySqlCommand(getCustomer, con);
                cmdCustomer.Parameters.AddWithValue("@name", textBox1.Text.Trim());

                object result = cmdCustomer.ExecuteScalar();

                if (result == null)
                {
                    string insertCustomer = @"
            INSERT INTO customer (customer_name)
            VALUES (@name);
        ";

                    MySqlCommand cmdInsert = new MySqlCommand(insertCustomer, con);
                    cmdInsert.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                    cmdInsert.ExecuteNonQuery();

                    customerId = (int)cmdInsert.LastInsertedId;
                }
                else
                {
                    customerId = Convert.ToInt32(result);
                }

                // 2. CREATE ORDER ONLY IF NOT EXISTS
                if (currentOrderId == 0)
                {
                    string createOrder = @"
            INSERT INTO orders (customer_id, date, total_amount, status)
            VALUES (@cid, @date, 0, 'Pending');
        ";

                    MySqlCommand cmd1 = new MySqlCommand(createOrder, con);
                    cmd1.Parameters.AddWithValue("@cid", customerId);
                    cmd1.Parameters.AddWithValue("@date", dateTimePicker1.Value);

                    cmd1.ExecuteNonQuery();

                    currentOrderId = (int)cmd1.LastInsertedId;
                }

                // 3. ADD ITEM (ALWAYS SAME ORDER)
                string query2 = @"
        INSERT INTO order_details (order_id, product_id, quantity, price)
        VALUES (@oid, @pid, @qty, @price);
    ";

                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@oid", currentOrderId);
                cmd2.Parameters.AddWithValue("@pid", selectedProductId);
                cmd2.Parameters.AddWithValue("@qty", (int)numericUpDown1.Value);
                cmd2.Parameters.AddWithValue("@price", GetProductPrice(selectedProductId));

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Item added to order!");
            }

            // 4. LOAD GRID
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
        SELECT
    od.order_detail_id,
    p.item_name,
    od.quantity,
    od.price AS unit_price,
    (od.quantity * od.price) AS total_amount
FROM order_details od
INNER JOIN products p ON od.product_id = p.product_id
WHERE od.order_id = @order_id;
    ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@order_id", currentOrderId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            // 5. UPDATE TOTAL
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
        SELECT SUM(quantity * price)
        FROM order_details
        WHERE order_id = @order_id;
    ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@order_id", currentOrderId);

                object result = cmd.ExecuteScalar();

                decimal total = result == DBNull.Value || result == null
                    ? 0
                    : Convert.ToDecimal(result);

                lbltotal_amount.Text = total.ToString("0.00");
            }
        }

        private decimal GetProductPrice(int productId)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = "SELECT item_price FROM products WHERE product_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", productId);

                object result = cmd.ExecuteScalar();

                return result == null ? 0 : Convert.ToDecimal(result);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedOrderDetailId = Convert.ToInt32(row.Cells["order_detail_id"].Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedOrderDetailId == 0)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
            DELETE FROM order_details
            WHERE order_detail_id = @id;
        ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", selectedOrderDetailId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Item removed!");

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
            SELECT
                od.order_detail_id,
                p.item_name,
                od.quantity,
                od.price AS unit_price,
                (od.quantity * od.price) AS total_amount
            FROM order_details od
            INNER JOIN products p ON od.product_id = p.product_id
            WHERE od.order_id = @order_id;
        ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@order_id", currentOrderId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            // update total
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
            SELECT SUM(quantity * price)
            FROM order_details
            WHERE order_id = @order_id;
        ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@order_id", currentOrderId);

                object result = cmd.ExecuteScalar();

                decimal total = result == DBNull.Value || result == null
                    ? 0
                    : Convert.ToDecimal(result);

                lbltotal_amount.Text = total.ToString("0.00");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentOrderId == 0)
            {
                MessageBox.Show("No active order.");
                return;
            }

            decimal total = 0;

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                // 1. GET TOTAL
                string totalQuery = @"
            SELECT SUM(quantity * price)
            FROM order_details
            WHERE order_id = @order_id;
        ";

                MySqlCommand cmdTotal = new MySqlCommand(totalQuery, con);
                cmdTotal.Parameters.AddWithValue("@order_id", currentOrderId);

                object result = cmdTotal.ExecuteScalar();

                total = result == DBNull.Value || result == null
                    ? 0
                    : Convert.ToDecimal(result);

                // 2. UPDATE ORDER
                string updateOrder = @"
            UPDATE orders
            SET status = 'Dine-In',
                total_amount = @total
            WHERE order_id = @order_id;
        ";

                MySqlCommand cmdUpdate = new MySqlCommand(updateOrder, con);
                cmdUpdate.Parameters.AddWithValue("@total", total);
                cmdUpdate.Parameters.AddWithValue("@order_id", currentOrderId);

                cmdUpdate.ExecuteNonQuery();
            }

            MessageBox.Show("Order set to Dine-In!");

            // 3. CLEAR UI
            dataGridView1.DataSource = null;
            lbltotal_amount.Text = "0.00";
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            numericUpDown1.Value = 0;

            // 4. RESET ORDER
            currentOrderId = 0;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (currentOrderId == 0)
            {
                MessageBox.Show("No active order.");
                return;
            }

            decimal total = 0;

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                // 1. GET TOTAL
                string totalQuery = @"
            SELECT SUM(quantity * price)
            FROM order_details
            WHERE order_id = @order_id;
        ";

                MySqlCommand cmdTotal = new MySqlCommand(totalQuery, con);
                cmdTotal.Parameters.AddWithValue("@order_id", currentOrderId);

                object result = cmdTotal.ExecuteScalar();

                total = result == DBNull.Value || result == null
                    ? 0
                    : Convert.ToDecimal(result);

                // 2. UPDATE ORDER (ONLY CHANGE IS HERE)
                string updateOrder = @"
            UPDATE orders
            SET status = 'Take-Out',
                total_amount = @total
            WHERE order_id = @order_id;
        ";

                MySqlCommand cmdUpdate = new MySqlCommand(updateOrder, con);
                cmdUpdate.Parameters.AddWithValue("@total", total);
                cmdUpdate.Parameters.AddWithValue("@order_id", currentOrderId);

                cmdUpdate.ExecuteNonQuery();
            }

            MessageBox.Show("Order set to Take-Out!");

            // 3. CLEAR UI
            dataGridView1.DataSource = null;
            lbltotal_amount.Text = "0.00";
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            numericUpDown1.Value = 0;

            // 4. RESET ORDER
            currentOrderId = 0;

        }
    }
}
