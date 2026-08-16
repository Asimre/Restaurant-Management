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
    public partial class InventoryForm : Form
    {
        string connStr = "server=localhost;user id=root;password=;database=restaurant";

        int selectedProductId;
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Hide();
            adminPage.Show();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
                    SELECT 
                        p.product_id AS item_id,
                        p.item_name,
                        p.category,
                        p.unit,
                        p.item_price,
                        i.quantity,
                        s.suppliers_name AS supplier,
                        i.expiration
                    FROM inventory i
                    INNER JOIN products p ON i.product_id = p.product_id
                    INNER JOIN supplier s ON i.supplier_id = s.suppliers_id;
                    ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Trim() == "")
            {
                MessageBox.Show("Please enter search information.");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
        SELECT
            p.product_id AS item_id,
            p.item_name,
            i.quantity,
            s.suppliers_name AS supplier,
            p.category,
            p.unit,
            p.item_price,
            i.expiration
        FROM inventory i
        INNER JOIN products p ON i.product_id = p.product_id
        INNER JOIN supplier s ON i.supplier_id = s.suppliers_id
        WHERE 
            p.item_name LIKE @search OR
            p.category LIKE @search OR
            s.suppliers_name LIKE @search;
    ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBox9.Text.Trim() + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                // 1. INSERT PRODUCT
                string insertProduct = @"
            INSERT INTO products (item_name, category, unit, item_price)
            VALUES (@name, @category, @unit, @price);
        ";

                MySqlCommand cmdProduct = new MySqlCommand(insertProduct, con);
                cmdProduct.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                cmdProduct.Parameters.AddWithValue("@category", textBox7.Text.Trim());
                cmdProduct.Parameters.AddWithValue("@unit", textBox6.Text.Trim());
                cmdProduct.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox8.Text));

                cmdProduct.ExecuteNonQuery();

                int productId = (int)cmdProduct.LastInsertedId;

                // 2. CHECK OR INSERT SUPPLIER
                string getSupplier = @"
            SELECT suppliers_id 
            FROM supplier 
            WHERE suppliers_name = @name;
        ";

                MySqlCommand cmdGetSupplier = new MySqlCommand(getSupplier, con);
                cmdGetSupplier.Parameters.AddWithValue("@name", textBox3.Text.Trim());

                object result = cmdGetSupplier.ExecuteScalar();

                int supplierId;

                if (result == null)
                {
                    string insertSupplier = @"
                INSERT INTO supplier (suppliers_name)
                VALUES (@name);
            ";

                    MySqlCommand cmdInsertSupplier = new MySqlCommand(insertSupplier, con);
                    cmdInsertSupplier.Parameters.AddWithValue("@name", textBox3.Text.Trim());
                    cmdInsertSupplier.ExecuteNonQuery();

                    supplierId = (int)cmdInsertSupplier.LastInsertedId;
                }
                else
                {
                    supplierId = Convert.ToInt32(result);
                }

                // 3. INSERT INVENTORY
                string insertInventory = @"
            INSERT INTO inventory (product_id, quantity, expiration, supplier_id)
            VALUES (@pid, @qty, @exp, @sid);
        ";

                MySqlCommand cmdInventory = new MySqlCommand(insertInventory, con);
                cmdInventory.Parameters.AddWithValue("@pid", productId);
                cmdInventory.Parameters.AddWithValue("@qty", Convert.ToInt32(textBox4.Text));
                cmdInventory.Parameters.AddWithValue("@exp", dateTimePicker1.Value);
                cmdInventory.Parameters.AddWithValue("@sid", supplierId);

                cmdInventory.ExecuteNonQuery();

                MessageBox.Show("Item successfully added!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = @"
                    SELECT 
                        p.product_id AS item_id,
                        p.item_name,
                        p.category,
                        p.unit,
                        p.item_price,
                        i.quantity,
                        s.suppliers_name AS supplier,
                        i.expiration
                    FROM inventory i
                    INNER JOIN products p ON i.product_id = p.product_id
                    INNER JOIN supplier s ON i.supplier_id = s.suppliers_id;
                    ";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Value = DateTime.Today;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                // 1. Update Products table
                string updateProduct = @"
        UPDATE products 
        SET item_name = @name,
            category = @category,
            unit = @unit,
            item_price = @price
        WHERE product_id = @id;
    ";

                MySqlCommand cmd = new MySqlCommand(updateProduct, con);
                cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@category", textBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@unit", textBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox8.Text));
                cmd.Parameters.AddWithValue("@id", selectedProductId);

                cmd.ExecuteNonQuery();

                // 2. Update Inventory table
                string updateInventory = @"
        UPDATE inventory 
        SET quantity = @qty,
            expiration = @exp
        WHERE product_id = @id;
    ";

                MySqlCommand cmd2 = new MySqlCommand(updateInventory, con);
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(textBox4.Text));
                cmd2.Parameters.AddWithValue("@exp", dateTimePicker1.Value);
                cmd2.Parameters.AddWithValue("@id", selectedProductId);

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Updated successfully!");
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

                selectedProductId = Convert.ToInt32(row.Cells["item_id"].Value);

                textBox2.Text = row.Cells["item_name"].Value?.ToString();
                textBox3.Text = row.Cells["supplier"].Value?.ToString();
                textBox4.Text = row.Cells["quantity"].Value?.ToString();
                textBox6.Text = row.Cells["unit"].Value?.ToString();
                textBox7.Text = row.Cells["category"].Value?.ToString();
                textBox8.Text = row.Cells["item_price"].Value?.ToString();

                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["expiration"].Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select an item first.");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                MySqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1. DELETE INVENTORY (child table)
                    string deleteInventory = @"
                DELETE FROM inventory
                WHERE product_id = @id;
            ";

                    MySqlCommand cmd1 = new MySqlCommand(deleteInventory, con, transaction);
                    cmd1.Parameters.AddWithValue("@id", selectedProductId);
                    cmd1.ExecuteNonQuery();

                    // 2. DELETE PRODUCT (parent table)
                    string deleteProduct = @"
                DELETE FROM products
                WHERE product_id = @id;
            ";

                    MySqlCommand cmd2 = new MySqlCommand(deleteProduct, con, transaction);
                    cmd2.Parameters.AddWithValue("@id", selectedProductId);
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Item deleted successfully!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error deleting item: " + ex.Message);
                }
            }
        }
    }
}
