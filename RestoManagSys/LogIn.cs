using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoManagSys
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;
            string myUsername = "123";
            string myPassword = "123";
            username = txtUsername.Text;
            password = txtPassword.Text;

            if ((username.Equals(myUsername)) && (password.Equals(myPassword)))
            {
                MainWindow dboard  = new MainWindow();
                dboard.Show();
                Hide();

            }else
            {

            }

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
    }
}
