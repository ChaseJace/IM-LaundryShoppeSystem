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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
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

        private string GenerateEmpId()
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

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void butSales_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            laundryDB laundryDb = new laundryDB("datasource=127.0.0.1;port=3306;username=root;password=;database=db_laundry");

            string laundryID = GenerateLaundryId();
            DateTime date = this.date.Value; //gets the date selected by user
            int cusID = Convert.ToInt32(this.txtCustomer.Text);
            string empID = GenerateEmpId();
            string launType = comboLaundry.SelectedItem.ToString();
            int weight = Convert.ToInt32(this.txtWeight.Text);
            int cost = Convert.ToInt32(this.txtCost.Text);
            string payType = this.txtPayment.Text;
            string status = "Pending";



            string insertQuery = $"INSERT INTO tbl_laundry (Laundry_ID, Laundry_Date, Customer_ID, Employee_ID, Laundry_Type_ID, Weight, Cost, Subtotal, Status) VALUES ('{laundryID}', {date}, '{cusID}, {empID}, {launType}, {weight}, {cost}, {payType}, {status}')";
            laundryDb.ExecuteNonQuery(insertQuery);            // Assuming a method to execute queries without data retrieval

            // Handle success or failure (optional)
        }
    }
}
