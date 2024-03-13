using System;
using System.Windows.Forms;

public partial class ProductForm : Form {
    private inventory_manager manager;

    public ProductForm(inventory_manager manager) {
        InitializeComponent();
        this.manager = manager;
    }

    private void RefreshProductList() {
        dataGridViewProducts.DataSource = null;
        dataGridViewProducts.DataSource = manager.GetAllProducts();
    }

    private void ProductForm_Load(object sender, EventArgs e) {
        RefreshProductList();
    }

    private void buttonAddProduct_Click(object sender, EventArgs e) {
        var newProduct = new Product {
            product_name = textBoxProductName.Text,
            product_price = Convert.ToDecimal(textBoxProductPrice.Text),
            product_quantity = Convert.ToInt32(textBoxProductQuantity.Text),
            prod_desc = textBoxProductDescription.Text
        };
        manager.AddProduct(newProduct);
        RefreshProductList();
    }

    private void buttonUpdateProduct_Click(object sender, EventArgs e) {
        if (dataGridViewProducts.SelectedRows.Count > 0) {
            var selectedProduct = (Product)dataGridViewProducts.SelectedRows[0].DataBoundItem;
            selectedProduct.product_name = textBoxProductName.Text;
            selectedProduct.product_price = Convert.ToDecimal(textBoxProductPrice.Text);
            selectedProduct.product_quantity = Convert.ToInt32(textBoxProductQuantity.Text);
            selectedProduct.prod_desc = textBoxProductDescription.Text;
            manager.UpdateProduct(selectedProduct);
            RefreshProductList();
        }
    }

    private void buttonDeleteProduct_Click(object sender, EventArgs e) {
        if (dataGridViewProducts.SelectedRows.Count > 0) {
            var selectedProduct = (Product)dataGridViewProducts.SelectedRows[0].DataBoundItem;
            manager.DeleteProduct(selectedProduct);
            RefreshProductList();
        }
    }    
}
