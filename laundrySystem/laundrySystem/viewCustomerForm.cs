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
    public partial class viewCustomerForm : Form
    {
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry";

        public viewCustomerForm()
        {
            InitializeComponent();
        }

        private void viewCustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers(); // Call the method to load customers when the form loads
        }

        private void LoadCustomers()
        {
            string query = "SELECT Customer_ID, Cus_Lname, Cus_Fname, Cus_Initial, Cus_Gender, Cus_Age, Cus_ContactNum FROM tbl_Customer";

            using (MySqlConnection connection = new MySqlConnection(MySQLConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridViewCustomers.DataSource = dataTable; // Assuming dataGridViewCustomers is the name of your DataGridView control
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading customers: " + ex.Message);
                    }
                }
            }
        }
    }
}
