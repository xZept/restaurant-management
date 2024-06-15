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

namespace RestoManagSys
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            // Set to no text.
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            // The password character is an asterisk.
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            txtPassword.MaxLength = 14;
            txtConfirmPassword.MaxLength = 14;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Register the account if passwords match
            if (txtConfirmPassword.Text == txtPassword.Text)
            {
                string connection = "server=localhost;user id=root;password=;database=restaurantdb";
                string query = "INSERT INTO userinformation(userName,password)VALUES('"+ this.txtUserName.Text + "','" + this.txtPassword.Text +"')";
                MySqlConnection conn = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr;
                conn.Open();
                dr = cmd.ExecuteReader();
                MessageBox.Show("Successfully registered!");
                conn.Close();
                this.Close();
            }
            
            // Display an error message if passwords do not match
            else
            {
                MessageBox.Show("Passwords do not match!");
            }
        }
    }
}
