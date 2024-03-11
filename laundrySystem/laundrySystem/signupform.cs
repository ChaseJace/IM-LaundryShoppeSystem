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
            String fname = emp_Fname.Text;
            String lname = emp_Lname.Text;
            char initial;
            if (!string.IsNullOrEmpty(emp_initial.Text) && emp_initial.Text.Length == 1)
            {
                initial = emp_initial.Text[0];
            }
            else
            {
                initial = ' ';
            }

            char gender;
            if (!string.IsNullOrEmpty(emp_gender.Text) && emp_gender.Text.Length == 1)
            {
                char inputGender = char.ToUpper(emp_gender.Text[0]);
                if (inputGender == 'M' || inputGender == 'F' || inputGender == 'O')
                {
                    gender = inputGender;
                }
                else
                {
                    //gender = ' ';
                    Console.Write("e");
                }
            }
            else
            {
                //gender = ' ';
                Console.Write("e");
            }

            int age;
            if (int.TryParse(emp_age.Text, out age))
            {
                Console.Write("correct input");
            }
            else
            {
                Console.Write("wrong input");
            }
        }
    }
}
