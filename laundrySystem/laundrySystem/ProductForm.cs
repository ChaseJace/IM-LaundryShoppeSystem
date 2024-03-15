using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

public partial class ProductForm : Form
{
    private MySqlConnection connection;
    private string connectionString = "server=localhost;port=3306;database=mydatabase;username=root;password=password";

    public ProductForm()
    {
        InitializeComponent();
        connection = new MySqlConnection(connectionString);
    }

    private void RefreshProductList()
    {
        try
        {
            dataGridViewProducts.DataSource = null;
            string query = "SELECT * FROM tbl_product";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridViewProducts.DataSource = dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error refreshing product list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ProductForm_Load(object sender, EventArgs e)
    {
        RefreshProductList();
    }

    private void buttonAddProduct_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateProductInput())
                return;

            connection.Open();

            string insertQuery = "INSERT INTO tbl_product (Product_Name, Product_Price, Product_Quantity, Product_Desc) " +
                                 $"VALUES ('{textBoxProductName.Text}', '{textBoxProductPrice.Text}', '{textBoxProductQuantity.Text}', '{textBoxProductDescription.Text}')";
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();

            RefreshProductList();
            ClearProductInputFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while adding the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void buttonUpdateProduct_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateProductInput())
                return;

            connection.Open();

            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["Product_ID"].Value);
                string updateQuery = $"UPDATE tbl_product SET Product_Name = '{textBoxProductName.Text}', Product_Price = '{textBoxProductPrice.Text}', " +
                                     $"Product_Quantity = '{textBoxProductQuantity.Text}', Product_Desc = '{textBoxProductDescription.Text}' " +
                                     $"WHERE Product_ID = {productId}";
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();

                RefreshProductList();
                ClearProductInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while updating the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void buttonDeleteProduct_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();

            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["Product_ID"].Value);
                string deleteQuery = $"DELETE FROM tbl_product WHERE Product_ID = {productId}";
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                command.ExecuteNonQuery();

                RefreshProductList();
                ClearProductInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while deleting the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private bool ValidateProductInput()
    {
        if (string.IsNullOrWhiteSpace(textBoxProductName.Text))
        {
            MessageBox.Show("Please enter a valid product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!decimal.TryParse(textBoxProductPrice.Text, out _))
        {
            MessageBox.Show("Please enter a valid product price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!int.TryParse(textBoxProductQuantity.Text, out int quantity) || quantity <= 0)
        {
            MessageBox.Show("Please enter a valid product quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private void ClearProductInputFields()
    {
        textBoxProductName.Text = "";
        textBoxProductPrice.Text = "";
        textBoxProductQuantity.Text = "";
        textBoxProductDescription.Text = "";
    }
}
