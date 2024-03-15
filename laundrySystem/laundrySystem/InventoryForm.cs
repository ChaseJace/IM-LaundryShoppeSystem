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

public partial class InventoryForm : Form
{   
    private inventory_manager manager;
    private MySqlConnection connection;
    private string connectionString = "server=localhost;port=3306;database=mydatabase;username=root;password=password";

    public InventoryForm(inventory_manager manager)
    {
        InitializeComponent();
        this.manager = manager;
        this.connection = new MySqlConnection(connectionString);
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

            connection.Open();

            var newInventoryForm = new Inventory
            {
                laundry_id = Convert.ToInt32(textBoxLaundryId.Text),
                product_id = Convert.ToInt32(textBoxProductId.Text),
                quantity = Convert.ToInt32(textBoxQuantity.Text),
                unit = textBoxUnit.Text
            };

            string insertQuery = $"INSERT INTO tbl_inventory (Laundry_ID, Product_ID, Quantity, Unit) " +
                                 $"VALUES ('{newInventoryForm.laundry_id}', '{newInventoryForm.product_id}', '{newInventoryForm.quantity}', '{newInventoryForm.unit}')";
            MySqlCommand commandDatabase = new MySqlCommand(insertQuery, connection);
            commandDatabase.CommandTimeout = 60;

            commandDatabase.ExecuteNonQuery();

            RefreshInventoryList();
            ClearInventoryInputFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while adding the inventory form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void buttonUpdateInventoryForm_Click(object sender, EventArgs e)
    {   
        try
        {
            if (!ValidateInventoryInput())
                return;

            connection.Open();

            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                var selectedForm = (Inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
                selectedForm.quantity = Convert.ToInt32(textBoxQuantity.Text);
                selectedForm.unit = textBoxUnit.Text;

                string updateQuery = $"UPDATE tbl_inventory SET Quantity = '{selectedForm.quantity}', Unit = '{selectedForm.unit}' " +
                                     $"WHERE Laundry_ID = '{selectedForm.laundry_id}' AND Product_ID = '{selectedForm.product_id}'";
                MySqlCommand commandDatabase = new MySqlCommand(updateQuery, connection);
                commandDatabase.CommandTimeout = 60;

                commandDatabase.ExecuteNonQuery();

                RefreshInventoryList();
                ClearInventoryInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while updating the inventory form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }

    private void buttonDeleteInventoryForm_Click(object sender, EventArgs e)
    {
        try
        {
            connection.Open();

            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                var selectedForm = (Inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
                string deleteQuery = $"DELETE FROM tbl_inventory WHERE Laundry_ID = '{selectedForm.laundry_id}' AND Product_ID = '{selectedForm.product_id}'";
                MySqlCommand commandDatabase = new MySqlCommand(deleteQuery, connection);
                commandDatabase.CommandTimeout = 60;

                commandDatabase.ExecuteNonQuery();

                RefreshInventoryList();
                ClearInventoryInputFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while deleting the inventory form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
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

}
