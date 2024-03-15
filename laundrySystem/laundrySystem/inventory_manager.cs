using System;
using System.Collections.Generic;

public class inventory_manager {
    private List<inventory> inventoryForms;
    private List<product> products;

    public inventory_manager()  {
        inventoryForms = new List<inventory>();
        products = new List<product>();
    }

    public void AddProduct (product product) {
        product.product_id = products.Count + 1;
        products.Add(product);
    }

    public List<product> GetAllProducts() {
        return products;
    }

    public void UpdateProduct(product updated_product) {
        var existingProduct = products.Find(product => product.product_id == updated_product.product_id);
        if (existingProduct != null) {
            existingProduct.product_name = updated_product.product_name;
            existingProduct.product_price = updated_product.product_price;
            existingProduct.product_quantity = updated_product.product_quantity;
            existingProduct.prod_desc = updated_product.prod_desc;
        }
    }

    public void DeleteProduct(product deleted_product) {
        var existingProduct = products.Find(product => product.product_id == deleted_product.product_id);
        if (existingProduct != null) {
            products.Remove(existingProduct);
        }
    }

    public void AddInventoryForm(inventory inventoryForm) {
        inventoryForms.Add(inventoryForm);
    }

    public List<inventory> GetAllInventoryForms() {
        return inventoryForms;
    }

     public void UpdateInventoryForm(inventory updatedForm)
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
