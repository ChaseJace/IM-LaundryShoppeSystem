using System;
using System.Windows.Forms;

public partial class InventoryForm : Form {
    private inventory_manager manager;

    public InventoryForm(inventory_manager manager) {
        InitializeComponent();
        this.manager = manager;
    }

    private void RefreshInventoryList() {
        dataGridViewInventory.DataSource = null;
        dataGridViewInventory.DataSource = manager.GetAllInventoryForms();
    }

    private void InventoryForm_Load(object sender, EventArgs e) {
        RefreshInventoryList();
    }

    private void buttonAddInventoryForm_Click(object sender, EventArgs e) {
        var newForm = new Inventory {
            laundry_id = Convert.ToInt32(textBoxLaundryId.Text),
            product_id = Convert.ToInt32(textBoxProductId.Text),
            quantity = Convert.ToInt32(textBoxQuantity.Text),
            unit = textBoxUnit.Text
        };
        manager.AddInventoryForm(newForm);
        RefreshInventoryList();
    }

    private void buttonUpdateInventoryForm_Click(object sender, EventArgs e) {
        if (dataGridViewInventory.SelectedRows.Count > 0) {
            var selectedForm = (Inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
            selectedForm.laundry_id = Convert.ToInt32(textBoxLaundryId.Text);
            selectedForm.product_id = Convert.ToInt32(textBoxProductId.Text);
            selectedForm.quantity = Convert.ToInt32(textBoxQuantity.Text);
            selectedForm.unit = textBoxUnit.Text;
            manager.UpdateInventoryForm(selectedForm);
            RefreshInventoryList();
        }
    }

    private void buttonDeleteInventoryForm_Click(object sender, EventArgs e) {
        if (dataGridViewInventory.SelectedRows.Count > 0) {
            var selectedForm = (Inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
            manager.DeleteInventoryForm(selectedForm.laundry_id, selectedForm.product_id);
            RefreshInventoryList();
        }
    }
}
