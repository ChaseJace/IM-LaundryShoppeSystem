using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

public partial class InventoryForm : Form
{
    private DataGridView dataGridViewInventory;
    private TextBox textBoxLaundryId;
    private TextBox textBoxProductId;
    private TextBox textBoxQuantity;
    private TextBox textBoxUnit;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button buttonAddInventoryForm;
    private Button buttonUpdateInventoryForm;
    private Button buttonDeleteInventoryForm;
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

            var newInventoryForm = new inventory
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
                var selectedForm = (inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
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
                var selectedForm = (inventory)dataGridViewInventory.SelectedRows[0].DataBoundItem;
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


    private void InitializeComponent()
    {
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.textBoxLaundryId = new System.Windows.Forms.TextBox();
            this.textBoxProductId = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddInventoryForm = new System.Windows.Forms.Button();
            this.buttonUpdateInventoryForm = new System.Windows.Forms.Button();
            this.buttonDeleteInventoryForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(1, 1);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewInventory.TabIndex = 0;
            // 
            // textBoxLaundryId
            // 
            this.textBoxLaundryId.Location = new System.Drawing.Point(355, 35);
            this.textBoxLaundryId.Name = "textBoxLaundryId";
            this.textBoxLaundryId.Size = new System.Drawing.Size(100, 20);
            this.textBoxLaundryId.TabIndex = 1;
            // 
            // textBoxProductId
            // 
            this.textBoxProductId.Location = new System.Drawing.Point(355, 61);
            this.textBoxProductId.Name = "textBoxProductId";
            this.textBoxProductId.Size = new System.Drawing.Size(100, 20);
            this.textBoxProductId.TabIndex = 2;
            this.textBoxProductId.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(355, 87);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantity.TabIndex = 3;
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(355, 113);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(100, 20);
            this.textBoxUnit.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Laundry ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantity";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unit";
            // 
            // buttonAddInventoryForm
            // 
            this.buttonAddInventoryForm.Location = new System.Drawing.Point(271, 177);
            this.buttonAddInventoryForm.Name = "buttonAddInventoryForm";
            this.buttonAddInventoryForm.Size = new System.Drawing.Size(75, 23);
            this.buttonAddInventoryForm.TabIndex = 9;
            this.buttonAddInventoryForm.Text = "ADD";
            this.buttonAddInventoryForm.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateInventoryForm
            // 
            this.buttonUpdateInventoryForm.Location = new System.Drawing.Point(380, 177);
            this.buttonUpdateInventoryForm.Name = "buttonUpdateInventoryForm";
            this.buttonUpdateInventoryForm.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateInventoryForm.TabIndex = 10;
            this.buttonUpdateInventoryForm.Text = "UPDATE";
            this.buttonUpdateInventoryForm.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteInventoryForm
            // 
            this.buttonDeleteInventoryForm.Location = new System.Drawing.Point(324, 216);
            this.buttonDeleteInventoryForm.Name = "buttonDeleteInventoryForm";
            this.buttonDeleteInventoryForm.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteInventoryForm.TabIndex = 11;
            this.buttonDeleteInventoryForm.Text = "DELETE";
            this.buttonDeleteInventoryForm.UseVisualStyleBackColor = true;
            // 
            // InventoryForm
            // 
            this.ClientSize = new System.Drawing.Size(480, 386);
            this.Controls.Add(this.buttonDeleteInventoryForm);
            this.Controls.Add(this.buttonUpdateInventoryForm);
            this.Controls.Add(this.buttonAddInventoryForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUnit);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxProductId);
            this.Controls.Add(this.textBoxLaundryId);
            this.Controls.Add(this.dataGridViewInventory);
            this.Name = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }
}
