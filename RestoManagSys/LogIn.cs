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
using MySql.Data.MySqlClient;

namespace RestoManagSys
{
    public partial class LogIn : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=;database=restaurantdb");
        MySqlCommand command;
        MySqlDataReader dr;
        public LogIn()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            // Open registration window
            Register reg = new Register();
            reg.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                connection.Open();
                string selectQuery = "SELECT * FROM userinformation WHERE Username = @Username AND Password = @Password";
                command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Username", txtUsername.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Text);
                dr = command.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
