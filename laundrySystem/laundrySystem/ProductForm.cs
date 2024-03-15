using System;
using System.Windows.Forms;

public partial class ProductForm : Form
{
    private inventory_manager manager;
    private laundryDB db;

    public ProductForm(inventory_manager manager, laundryDB db)
    {
        InitializeComponent();
        this.manager = manager;
        this.db = db;
    }

    private void RefreshProductList()
    {
        try
        {
            dataGridViewProducts.DataSource = null;
            dataGridViewProducts.DataSource = manager.GetAllProducts();
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

            var newProduct = new Product
            {
                product_name = textBoxProductName.Text,
                product_price = Convert.ToDecimal(textBoxProductPrice.Text),
                product_quantity = Convert.ToInt32(textBoxProductQuantity.Text),
                prod_desc = textBoxProductDescription.Text
            };

            string query = "INSERT INTO tbl_product (Product_Name, Product_Price, Product_Quantity, Product_Desc) VALUES (@Name, @Price, @Quantity, @Description)";
            db.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                { "@Name", newProduct.product_name },
                { "@Price", newProduct.product_price },
                { "@Quantity", newProduct.product_quantity },
                { "@Description", newProduct.product_desc }
            });

            RefreshProductList();
            ClearProductInputFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while adding the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonUpdateProduct_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateProductInput())
                return;

            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedProduct = (Product)dataGridViewProducts.SelectedRows[0].DataBoundItem;
                selectedProduct.product_name = textBoxProductName.Text;
                selectedProduct.product_price = Convert.ToDecimal(textBoxProductPrice.Text);
                selectedProduct.product_quantity = Convert.ToInt32(textBoxProductQuantity.Text);
                selectedProduct.prod_desc = textBoxProductDescription.Text;

                manager.UpdateProduct(selectedProduct);

                RefreshProductList();
                ClearProductInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while updating the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonDeleteProduct_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedProduct = (Product)dataGridViewProducts.SelectedRows[0].DataBoundItem;
                manager.DeleteProduct(selectedProduct);

                RefreshProductList();
                ClearProductInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while deleting the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
