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
    public partial class salesForm : Form
    {
        public salesForm()
        {
            InitializeComponent();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            mainForm.Show();

            this.Hide();
        }
    }
}
