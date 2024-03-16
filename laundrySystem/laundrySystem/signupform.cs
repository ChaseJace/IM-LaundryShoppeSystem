using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laundrySystem
{
    public partial class signupform : Form
    {
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry";


        public signupform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string GenerateUniqueEmployeeId()
        {
            string employeeId;
            do
            {
               employeeId = GenerateEmployeeId(); 
            } while (IsEmployeeIdExists(employeeId)); 
            return employeeId;
        }

        private bool IsEmployeeIdExists(string employeeId)
        {
            string query = $"SELECT COUNT(*) FROM tbl_employee WHERE Emp_ID = '{employeeId}'";
            using (MySqlConnection connection = new MySqlConnection(MySQLConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; 
                }
            }
        }

        private void sign_in_Click(object sender, EventArgs e)
        {

            string employeeID = GenerateUniqueEmployeeId();
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

            string insert = $"INSERT INTO tbl_employee (Emp_ID, Emp_Lname, Emp_Fname, Emp_Initial, Emp_Age, Emp_Gender) " +
                            $"VALUES ('{employeeID}', '{lname}', '{fname}', '{initial}', '{age}', '{gender}')";

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(insert, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee added successfully");
                    this.Close();
                    loginForm loginForm = new loginForm();
                    loginForm.Show();

                }
                else
                {
                    MessageBox.Show("Failed to add employee");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query Error: " + ex.Message);
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

        
        private string GenerateEmployeeId()
        {
            int length = 11;
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                char randomChar;
                do
                {
                    randomChar = (char)random.Next(48, 58); // Generate digits (0-9)
                } while (!char.IsDigit(randomChar));
                sb.Append(randomChar);
            }
            return sb.ToString();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm loginForm = new loginForm();
            loginForm.Show();
        }
    }
}
