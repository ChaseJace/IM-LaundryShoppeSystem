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

namespace laundrySystem
{
    public partial class customerForm : Form
    {
        private string customerID;
        public customerForm(string customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }



        private void button2_Click(object sender, EventArgs e)
        {
         string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry";

        // Use the received customerID from mainForm
        string cusID = this.customerID;
            string cusLast = this.txtLName.Text;
            string cusFirst = this.txtFName.Text;
            string cusMI = this.txtMI.Text;
            string cusGender = this.txtGender.Text;
            int cusAge;
            if (!int.TryParse(this.txtAge.Text, out cusAge))
            {
                MessageBox.Show("Invalid Age");
                return;
            }
            string cusNum = this.txtContact.Text;

            // Assuming Address_ID is NULL in this scenario
            string insert = $"INSERT INTO tbl_Customer (Customer_ID, Address_ID, Cus_Lname, Cus_Fname, Cus_Initial, Cus_Gender, Cus_Age, Cus_ContactNum) " +
                            $"VALUES (@cusID, NULL, @cusLast, @cusFirst, @cusMI, @cusGender, @cusAge, @cusNum)";

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(insert, databaseConnection);
            commandDatabase.Parameters.AddWithValue("@cusID", cusID);
            commandDatabase.Parameters.AddWithValue("@cusLast", cusLast);
            commandDatabase.Parameters.AddWithValue("@cusFirst", cusFirst);
            commandDatabase.Parameters.AddWithValue("@cusMI", cusMI);
            commandDatabase.Parameters.AddWithValue("@cusGender", cusGender);
            commandDatabase.Parameters.AddWithValue("@cusAge", cusAge);
            commandDatabase.Parameters.AddWithValue("@cusNum", cusNum);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer added successfully");
                    ClearFields(); // Clear input fields
                }
                else
                {
                    MessageBox.Show("Failed to add customer");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query Error: " + ex.Message);
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }


        }

        private void ClearFields()
        {
            // Clear all input fields
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }

        private void butViewCus_Click(object sender, EventArgs e)
        {
            viewCustomerForm viewCustomerForm = new viewCustomerForm();

            this.Enabled = false;
            viewCustomerForm.ShowDialog();
            this.Enabled = true;

        }
    }
}
