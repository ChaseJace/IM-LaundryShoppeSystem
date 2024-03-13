using System;
using System.Collections.Generic;

public class inventory_manager {
    private List<Inventory> inventoryForms;
    private List<Product> products;

    public inventory_manager()  {
        inventoryForms = new List<Inventory>();
        products = new List<Product>();
    }

    public void AddProduct (Product product) {
        product.product_id = products.Count + 1;
        products.Add(product);
    }

    public List<Product> GetAllProducts() {
        return products;
    }

    public void UpdateProduct(Product updated_product) {
        var existingProduct = products.Find(product => product.product_id == updated_product.product_id);
        if (existingProduct != null) {
            existingProduct.product_name = updated_product.product_name;
            existingProduct.product_price = updated_product.product_price;
            existingProduct.product_quantity = updated_product.product_quantity;
            existingProduct.prod_desc = updated_product.prod_desc;
        }
    }

    public void DeleteProduct(Product deleted_product) {
        var existingProduct = products.Find(product => product.product_id == deleted_product.product_id);
        if (existingProduct != null) {
            products.Remove(existingProduct);
        }
    }

    public void AddInventoryForm(Inventory inventoryForm) {
        inventoryForms.Add(inventoryForm);
    }

    public List<Inventory> GetAllInventoryForms() {
        return inventoryForms;
    }

     public void UpdateInventoryForm(Inventory updatedForm)
    {
        var existingForm = inventoryForms.Find(form => form.laundry_id == updatedForm.laundry_id && form.product_id == updatedForm.product_id);
        if (existingForm != null)
        {
            existingForm.quantity = updatedForm.quantity;
            existingForm.unit = updatedForm.unit;
        }
    }

    public void DeleteInventoryForm(int laundryId, int productId)
    {
        var existingForm = inventoryForms.Find(form => form.laundry_id == laundryId && form.product_id == productId);
        if (existingForm != null)
        {
            inventoryForms.Remove(existingForm);
        }
    }
}
