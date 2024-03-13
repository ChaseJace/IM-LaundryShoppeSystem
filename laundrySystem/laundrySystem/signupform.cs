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
    public partial class signupform : Form
    {
        public signupform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            string fname = emp_Fname.Text;
            string lname = emp_Lname.Text;
            string password = emp_pass.Text;
            string initialText = emp_initial.Text;

            // Error handling for first name
            if (!IsValidName(fname))
            {
                MessageBox.Show("First name must start with a capital letter and cannot contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Error handling for last name
            if (!IsValidName(lname))
            {
                MessageBox.Show("Last name must start with a capital letter and cannot contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Error handling for initial
            char initial;
            if (!IsValidInitial(initialText, out initial))
            {
                MessageBox.Show("Initial must be a capital letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Error handling for gender
            char gender = ' ';
            if (!IsValidGender(emp_gender.Text, out gender))
            {
                MessageBox.Show("Invalid gender. Please enter 'M' for male or 'F' for female.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Error handling for age
            int age;
            if (!int.TryParse(emp_age.Text, out age))
            {
                MessageBox.Show("Invalid age. Please enter a valid integer number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            if (!char.IsUpper(name[0]))
                return false;
            if (name.Substring(1).Any(char.IsDigit))
                return false;
            return true;
        }

        private bool IsValidInitial(string initialText, out char initial)
        {
            if (string.IsNullOrEmpty(initialText) || initialText.Length != 1)
            {
                initial = ' ';
                return false;
            }
            initial = initialText[0];
            return char.IsUpper(initial);
        }

        private bool IsValidGender(string genderText, out char gender)
        {
            if (string.IsNullOrEmpty(genderText) || genderText.Length != 1)
            {
                gender = ' ';
                return false;
            }
            gender = char.ToUpper(genderText[0]);
            return gender == 'M' || gender == 'F';
        }
    }
}
