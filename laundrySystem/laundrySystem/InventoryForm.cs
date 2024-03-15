using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class InventoryForm : Form
{
    private inventory_manager manager;
    private laundryDB db;

    public InventoryForm(inventory_manager manager, laundryDB db)
    {
        InitializeComponent();
        this.manager = manager;
        this.db = db;
    }

    private void RefreshInventoryList()
    {
        try
        {
            dataGridViewInventory.DataSource = null;
            dataGridViewInventory.DataSource = manager.GetAllInventoryForms();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error refreshing inventory list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InventoryForm_Load(object sender, EventArgs e)
    {
        RefreshInventoryList();
    }

    private void buttonAddInventoryForm_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInventoryInput())
                return;

            var newInventoryForm = new Inventory
            {
                laundry_id = Convert.ToInt32(textBoxLaundryId.Text),
                product_id = Convert.ToInt32(textBoxProductId.Text),
                quantity = Convert.ToInt32(textBoxQuantity.Text),
                unit = textBoxUnit.Text
            };

            string query = "INSERT INTO tbl_inventory (Laundry_ID, Product_ID, Quantity, Unit) VALUES (@LaundryID, @ProductID, @Quantity, @Unit)";
            db.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                { "@LaundryID", newInventoryForm.laundry_id },
                { "@ProductID", newInventoryForm.product_id },
                { "@Quantity", newInventoryForm.quantity },
                { "@Unit", newInventoryForm.unit }
            });

            RefreshInventoryList();
            ClearInventoryInputFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while adding the inventory form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonUpdateInventoryForm_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidateInventoryInput())
                return;

            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                var selectedForm = (Inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
                selectedForm.quantity = Convert.ToInt32(textBoxQuantity.Text);
                selectedForm.unit = textBoxUnit.Text;
                manager.UpdateInventoryForm(selectedForm);
                RefreshInventoryList();
                ClearInventoryInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while updating the inventory form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonDeleteInventoryForm_Click(object sender, EventArgs e)
    {
        try
        {
            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                var selectedForm = (Inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
                manager.DeleteInventoryForm(selectedForm.laundry_id, selectedForm.product_id);
                RefreshInventoryList();
                ClearInventoryInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while deleting the inventory form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool ValidateInventoryInput()
    {
        if (!int.TryParse(textBoxLaundryId.Text, out _) || Convert.ToInt32(textBoxLaundryId.Text) <= 0)
        {
            MessageBox.Show("Please enter a valid laundry ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!int.TryParse(textBoxProductId.Text, out _) || Convert.ToInt32(textBoxProductId.Text) <= 0)
        {
            MessageBox.Show("Please enter a valid product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!int.TryParse(textBoxQuantity.Text, out _) || Convert.ToInt32(textBoxQuantity.Text) <= 0)
        {
            MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private void ClearInventoryInputFields()
    {
        textBoxLaundryId.Text = "";
        textBoxProductId.Text = "";
        textBoxQuantity.Text = "";
        textBoxUnit.Text = "";
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // InventoryForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "InventoryForm";
            this.Load += new System.EventHandler(this.InventoryForm_Load_1);
            this.ResumeLayout(false);

    }

    private void InventoryForm_Load_1(object sender, EventArgs e)
    {

    }
}
