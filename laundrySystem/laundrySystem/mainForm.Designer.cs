namespace laundrySystem
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblStatus = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.butSales = new System.Windows.Forms.Button();
            this.butInventory = new System.Windows.Forms.Button();
            this.butCustomer = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblLaundry = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.butClose = new System.Windows.Forms.Button();
            this.comboLaundry = new System.Windows.Forms.ComboBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.butClear = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butGcash = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tblStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblStatus
            // 
            this.tblStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tblStatus.ColumnCount = 2;
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.Controls.Add(this.listView1, 0, 0);
            this.tblStatus.Location = new System.Drawing.Point(17, 12);
            this.tblStatus.Name = "tblStatus";
            this.tblStatus.RowCount = 2;
            this.tblStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatus.Size = new System.Drawing.Size(902, 520);
            this.tblStatus.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(2, 2);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(447, 256);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // butSales
            // 
            this.butSales.Location = new System.Drawing.Point(934, 512);
            this.butSales.Name = "butSales";
            this.butSales.Size = new System.Drawing.Size(142, 21);
            this.butSales.TabIndex = 1;
            this.butSales.Text = "Sales";
            this.butSales.UseVisualStyleBackColor = true;
            this.butSales.Click += new System.EventHandler(this.butSales_Click);
            // 
            // butInventory
            // 
            this.butInventory.Location = new System.Drawing.Point(1083, 511);
            this.butInventory.Name = "butInventory";
            this.butInventory.Size = new System.Drawing.Size(161, 21);
            this.butInventory.TabIndex = 2;
            this.butInventory.Text = "Inventory";
            this.butInventory.UseVisualStyleBackColor = true;
            this.butInventory.Click += new System.EventHandler(this.butInventory_Click);
            // 
            // butCustomer
            // 
            this.butCustomer.Location = new System.Drawing.Point(1131, 113);
            this.butCustomer.Name = "butCustomer";
            this.butCustomer.Size = new System.Drawing.Size(98, 26);
            this.butCustomer.TabIndex = 3;
            this.butCustomer.Text = "Add Customer";
            this.butCustomer.UseVisualStyleBackColor = true;
            this.butCustomer.Click += new System.EventHandler(this.butCustomer_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(930, 72);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 24);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(930, 113);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(123, 24);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "Customer ID: ";
            // 
            // lblLaundry
            // 
            this.lblLaundry.AutoSize = true;
            this.lblLaundry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaundry.Location = new System.Drawing.Point(931, 152);
            this.lblLaundry.Name = "lblLaundry";
            this.lblLaundry.Size = new System.Drawing.Size(136, 24);
            this.lblLaundry.TabIndex = 6;
            this.lblLaundry.Text = "Laundry Type: ";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(930, 190);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(119, 24);
            this.lblWeight.TabIndex = 7;
            this.lblWeight.Text = "Weight (Kg): ";
            this.lblWeight.Click += new System.EventHandler(this.lblWeight_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(931, 229);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(62, 24);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Cost : ";
            this.lblCost.Click += new System.EventHandler(this.lblCost_Click);
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSub.Location = new System.Drawing.Point(930, 267);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(141, 24);
            this.lblSub.TabIndex = 9;
            this.lblSub.Text = "Payment Type :";
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(936, 337);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(145, 37);
            this.butAdd.TabIndex = 10;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(989, 74);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(240, 20);
            this.date.TabIndex = 14;
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(1215, 12);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(29, 23);
            this.butClose.TabIndex = 15;
            this.butClose.Text = "X";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // comboLaundry
            // 
            this.comboLaundry.FormattingEnabled = true;
            this.comboLaundry.Items.AddRange(new object[] {
            "Wash + Dry (forgor)",
            "HandWash",
            "Dry"});
            this.comboLaundry.Location = new System.Drawing.Point(1074, 154);
            this.comboLaundry.Name = "comboLaundry";
            this.comboLaundry.Size = new System.Drawing.Size(155, 21);
            this.comboLaundry.TabIndex = 16;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(1046, 117);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(79, 20);
            this.txtCustomer.TabIndex = 17;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(1046, 194);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(183, 20);
            this.txtWeight.TabIndex = 18;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(989, 233);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(240, 20);
            this.txtCost.TabIndex = 19;
            this.txtCost.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(1070, 271);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(159, 20);
            this.txtPayment.TabIndex = 20;
            this.txtPayment.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(1087, 337);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(142, 37);
            this.butClear.TabIndex = 21;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(1087, 380);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(142, 37);
            this.butDelete.TabIndex = 23;
            this.butDelete.Text = "Delete";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butUpdate
            // 
            this.butUpdate.Location = new System.Drawing.Point(936, 380);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(145, 37);
            this.butUpdate.TabIndex = 22;
            this.butUpdate.Text = "Update";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // butGcash
            // 
            this.butGcash.Location = new System.Drawing.Point(1166, 297);
            this.butGcash.Name = "butGcash";
            this.butGcash.Size = new System.Drawing.Size(63, 23);
            this.butGcash.TabIndex = 25;
            this.butGcash.Text = "Gcash";
            this.butGcash.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(968, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(241, 36);
            this.label15.TabIndex = 46;
            this.label15.Text = "CUSTOMER INFO";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1251, 547);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.butGcash);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.comboLaundry);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.date);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblLaundry);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.butCustomer);
            this.Controls.Add(this.butInventory);
            this.Controls.Add(this.butSales);
            this.Controls.Add(this.tblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tblStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblStatus;
        private System.Windows.Forms.Button butSales;
        private System.Windows.Forms.Button butInventory;
        private System.Windows.Forms.Button butCustomer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblLaundry;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.ComboBox comboLaundry;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butGcash;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label15;
    }
}