using laundrySystem;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

public partial class ProductForm : Form
{
    private DataGridView dataGridViewProducts;
    private TextBox textBoxProductName;
    private TextBox textBoxProductPrice;
    private TextBox textBoxProductQuantity;
    private TextBox textBoxProductDescription;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button buttonAddProduct;
    private Button buttonUpdateProduct;
    private Button buttonDeleteProduct;
    private inventory_manager manager;

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

    private void InitializeComponent()
    {
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.textBoxProductQuantity = new System.Windows.Forms.TextBox();
            this.textBoxProductDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonUpdateProduct = new System.Windows.Forms.Button();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(1, 2);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new System.Drawing.Size(403, 332);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(534, 59);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(89, 20);
            this.textBoxProductName.TabIndex = 1;
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Location = new System.Drawing.Point(534, 98);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.Size = new System.Drawing.Size(89, 20);
            this.textBoxProductPrice.TabIndex = 2;
            // 
            // textBoxProductQuantity
            // 
            this.textBoxProductQuantity.Location = new System.Drawing.Point(534, 140);
            this.textBoxProductQuantity.Name = "textBoxProductQuantity";
            this.textBoxProductQuantity.Size = new System.Drawing.Size(89, 20);
            this.textBoxProductQuantity.TabIndex = 3;
            this.textBoxProductQuantity.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBoxProductDescription
            // 
            this.textBoxProductDescription.Location = new System.Drawing.Point(534, 178);
            this.textBoxProductDescription.Name = "textBoxProductDescription";
            this.textBoxProductDescription.Size = new System.Drawing.Size(89, 20);
            this.textBoxProductDescription.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Product Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Product Description";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(431, 240);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonAddProduct.TabIndex = 9;
            this.buttonAddProduct.Text = "ADD";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateProduct
            // 
            this.buttonUpdateProduct.Location = new System.Drawing.Point(548, 240);
            this.buttonUpdateProduct.Name = "buttonUpdateProduct";
            this.buttonUpdateProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateProduct.TabIndex = 10;
            this.buttonUpdateProduct.Text = "UPDATE";
            this.buttonUpdateProduct.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(490, 283);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteProduct.TabIndex = 11;
            this.buttonDeleteProduct.Text = "DELETE";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.ClientSize = new System.Drawing.Size(651, 430);
            this.Controls.Add(this.buttonDeleteProduct);
            this.Controls.Add(this.buttonUpdateProduct);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProductDescription);
            this.Controls.Add(this.textBoxProductQuantity);
            this.Controls.Add(this.textBoxProductPrice);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }
}
