using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laundrySystem
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void butLog_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("admin") && txtPass.Text.Equals("123"))
            {
                mainForm mainForm = new mainForm();
                mainForm.Show();

                this.Hide();
            } else
            {
                MessageBox.Show("Wrong username or password. Please try again.");
            }
            
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
