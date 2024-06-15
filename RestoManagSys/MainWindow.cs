using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace RestoManagSys

{
    public partial class MainWindow : Form

    {
        private MySqlConnection connect;
        public MainWindow()
        {
            InitializeComponent();
            connect = new MySqlConnection("server=localhost; user id=root; password=; database=inventorydb");
            refresh();
        }
        private void refresh()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                // Retrieves all products 
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM inventory", connect);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridInventory.DataSource = table; // Binds product data for display 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Displays error message
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close(); // Ensures db connection is closed
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) { }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnInventory_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panelinv.Visible = true;
            panel4.Visible = false;
            panelReceipt.Visible = false;

            
            String qry1 = "SELECT * FROM inventory";
            
            MySqlCommand cmdStud1 = new MySqlCommand(qry1, connect);

            refresh();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
            panelinv.Visible = false;
        }

     

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Lemonade', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `inventory` WHERE `productID`= @productId", connect);
                cmd.Parameters.AddWithValue("@productId", this.txtProdid.Text);

                // Execute the command
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Deletion Successful!");
                    refresh(); // Refresh the data grid after deletion
                }
                else
                {
                    MessageBox.Show("No product found with the specified ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close(); // Close the connection
            }
        }

        private void btnSetPrice_Click(object sender, EventArgs e)
        {
            try
                {
                    if(connect.State == ConnectionState.Closed)
                    connect.Open();
               MySqlCommand cmd = new MySqlCommand("UPDATE inventory SET price = @price WHERE productID = @productID", connect);
                        cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);
                        cmd.Parameters.AddWithValue("@productID", this.txtProdid.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                    
                            MessageBox.Show("Price updated successfully!");
                     refresh();
                        }
                        else
                        {
                            MessageBox.Show("No product found with the specified ID.");
                        }
              
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
        private void btnStock_Click(object sender, EventArgs e) 
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE inventory SET numberOfStocks = @Stock WHERE productID = @productID", connect);
                cmd.Parameters.AddWithValue("@Stock", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@productID", this.txtProdid.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    MessageBox.Show("Stock updated successfully!");
                    refresh();
                }
                else
                {
                    MessageBox.Show("No product found with the specified ID.");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Creampuff', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Hot Coffee', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Spaghetti', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Lasagna', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Burger', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Donut', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO inventory(productName, numberOfStocks, price) VALUES('Croissant', @quantityToAdd, @price)", connect);
                cmd.Parameters.AddWithValue("@quantityToAdd", this.txtAddStock.Text);
                cmd.Parameters.AddWithValue("@price", this.txtPrice.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
    }
    }

