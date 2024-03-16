﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laundrySystem
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }



        private string GenerateLaundryId()
        {
            int length = 8; // Adjust the desired length of the ID
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                char randomChar;
                do
                {
                    randomChar = (char)random.Next(65, 91); // Generate uppercase letters (A-Z)
                } while (!char.IsLetterOrDigit(randomChar));
                sb.Append(randomChar);
            }
            return sb.ToString();
        }

        private string GenerateCustomerId()
        {
            int length = 8; // Adjust the desired length of the ID
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

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void lblWeight_Click(object sender, EventArgs e)
        {

        }

        private void lblCost_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butSales_Click(object sender, EventArgs e)
        {
            salesForm salesForm = new salesForm();
            salesForm.Show();

            this.Hide();
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtCustomer.Clear();
            date.Value = DateTime.Now;
            txtWeight.Clear();
            txtCost.Clear();
            txtPayment.Clear();
        }

        private void butGcash_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = !pictureBox1.Visible;
        }

        private void butCustomer_Click(object sender, EventArgs e)
        {
            string customerID = GenerateCustomerId();
            customerForm customerForm = new customerForm(customerID);
            this.Enabled = false;
            customerForm.ShowDialog();
            this.Enabled = true;

        }

        private void butInventory_Click(object sender, EventArgs e)
        {
            // input going to inventory

            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry";

            string laundryID = GenerateLaundryId();
            string date = this.date.Value.ToString("yyyy-MM-dd");
            int cusID;
            if (!int.TryParse(this.txtCustomer.Text, out cusID))
            {
                MessageBox.Show("Invalid Customer ID");
                return;
            }
            string empID = "emp_id"; //incomplete
            string launType = comboLaundry.SelectedItem.ToString();
            int weight;
            if (!int.TryParse(this.txtWeight.Text, out weight))
            {
                MessageBox.Show("Invalid Weight");
                return;
            }
            int cost;
            if (!int.TryParse(this.txtCost.Text, out cost))
            {
                MessageBox.Show("Invalid Cost");
                return;
            }
            string payType = this.txtPayment.Text;
            string status = "Pending";

            string insert = $"INSERT INTO tbl_laundry (Laundry_ID, Laundry_Date, Customer_ID, Employee_ID, Laundry_Type_ID, Weight, Cost, Subtotal, Status) " +
                            $"VALUES ('{laundryID}', '{date}', '{cusID}', '{empID}', '{launType}', '{weight}', '{cost}', '{payType}', '{status}')";

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(insert, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                int rowsAffected = commandDatabase.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Laundry added successfully");
                    listUsers(); // Refresh the list after adding a new entry
                }
                else
                {
                    MessageBox.Show("Failed to add laundry");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query Error: " + ex.Message);
            }
        }

        private void listUsers()
        {
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry";
            string query = "SELECT * FROM tbl_laundry";

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                

                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    Console.WriteLine("No rows Found");
                }

                databaseConnection.Close();
            } 
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void butUpdate_Click(object sender, EventArgs e) //incomplete
        {
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry";
            string update = "SELECT *FROM tbl_laundry"; //input values for upodate

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(update, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butDelete_Click(object sender, EventArgs e) //incomplete
        {
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry";
            string delete = "SELECT *FROM tbl_laundry"; 

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(delete, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                databaseConnection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        


    }
}
