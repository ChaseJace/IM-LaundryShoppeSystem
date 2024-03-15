using System;
using System.Collections.Generic;

public class inventory_manager
{
    public void AddProduct(Product product)
    {
        try
        {
            // Validate product input
            if (!ValidateProduct(product))
            {
                throw new ArgumentException("Invalid product data.");
            }

            ProductForm.AddProductToDatabase(product);
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding product: " + ex.Message);
        }
    }

    public void UpdateProduct(Product updatedProduct)
    {
        try
        {
            // Validate updated product input
            if (!ValidateProduct(updatedProduct))
            {
                throw new ArgumentException("Invalid product data.");
            }

            ProductForm.UpdateProductInDatabase(updatedProduct);
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating product: " + ex.Message);
        }
    }

    private bool ValidateProduct(Product product)
    {
        // Validate product name
        if (string.IsNullOrWhiteSpace(product.product_name))
        {
            return false;
        }

        // Validate product price
        if (product.product_price <= 0)
        {
            return false;
        }

        // Validate product quantity
        if (product.product_quantity < 0)
        {
            return false;
        }

        return true;
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            return ProductForm.GetAllProductsFromDatabase();
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching products: " + ex.Message);
        }
    }

    public void DeleteProduct(Product productToDelete)
    {
        try
        {
            ProductForm.DeleteProductFromDatabase(productToDelete);
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting product: " + ex.Message);
        }
    }

    public void AddInventoryForm(Inventory inventoryForm)
    {
        try
        {
            // Validate inventory input
            if (!ValidateInventory(inventoryForm))
            {
                throw new ArgumentException("Invalid inventory form data.");
            }

            InventoryForm.AddInventoryFormToDatabase(inventoryForm);
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding inventory form: " + ex.Message);
        }
    }

    public void UpdateInventoryForm(Inventory updatedForm)
    {
        try
        {
            // Validate updated inventory input
            if (!ValidateInventory(updatedForm))
            {
                throw new ArgumentException("Invalid inventory form data.");
            }

            InventoryForm.UpdateInventoryFormInDatabase(updatedForm);
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating inventory form: " + ex.Message);
        }
    }

    private bool ValidateInventory(Inventory inventory)
    {
        // Validate inventory quantity
        if (inventory.quantity <= 0)
        {
            return false; // Quantity should be a positive integer
        }

        // Check for required fields
        if (inventory.laundry_id <= 0 || inventory.product_id <= 0 || string.IsNullOrWhiteSpace(inventory.unit))
        {
            return false; // Ensure all required fields are provided
        }

        // Check if product exists
        if (!ProductExists(inventory.product_id))
        {
            return false; // Product with the given ID does not exist
        }

        return true;
    }

    public List<Inventory> GetAllInventoryForms()
    {
        try
        {
            return InventoryForm.GetAllInventoryFormsFromDatabase();
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching inventory forms: " + ex.Message);
        }
    }

    public void DeleteInventoryForm(int laundryId, int productId)
    {
        try
        {
            InventoryForm.DeleteInventoryFormFromDatabase(laundryId, productId);
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting inventory form: " + ex.Message);
        }
    }
}
