﻿namespace laundrySystem
{
    partial class signupform
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.emp_Fname = new System.Windows.Forms.TextBox();
            this.emp_Lname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.emp_initial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emp_age = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.emmp_gender = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.emp_pass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sign_in = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Sign up form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name:";
            // 
            // emp_Fname
            // 
            this.emp_Fname.Location = new System.Drawing.Point(276, 139);
            this.emp_Fname.Name = "emp_Fname";
            this.emp_Fname.Size = new System.Drawing.Size(100, 20);
            this.emp_Fname.TabIndex = 2;
            // 
            // emp_Lname
            // 
            this.emp_Lname.Location = new System.Drawing.Point(276, 165);
            this.emp_Lname.Name = "emp_Lname";
            this.emp_Lname.Size = new System.Drawing.Size(100, 20);
            this.emp_Lname.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name:";
            // 
            // emp_initial
            // 
            this.emp_initial.Location = new System.Drawing.Point(276, 191);
            this.emp_initial.Name = "emp_initial";
            this.emp_initial.Size = new System.Drawing.Size(100, 20);
            this.emp_initial.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Initial:";
            // 
            // emp_age
            // 
            this.emp_age.Location = new System.Drawing.Point(276, 217);
            this.emp_age.Name = "emp_age";
            this.emp_age.Size = new System.Drawing.Size(100, 20);
            this.emp_age.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Age:";
            // 
            // emmp_gender
            // 
            this.emmp_gender.Location = new System.Drawing.Point(276, 243);
            this.emmp_gender.Name = "emmp_gender";
            this.emmp_gender.Size = new System.Drawing.Size(100, 20);
            this.emmp_gender.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Gender";
            // 
            // emp_pass
            // 
            this.emp_pass.Location = new System.Drawing.Point(276, 281);
            this.emp_pass.Name = "emp_pass";
            this.emp_pass.PasswordChar = '*';
            this.emp_pass.Size = new System.Drawing.Size(100, 20);
            this.emp_pass.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Password:";
            // 
            // sign_in
            // 
            this.sign_in.Location = new System.Drawing.Point(289, 321);
            this.sign_in.Name = "sign_in";
            this.sign_in.Size = new System.Drawing.Size(75, 23);
            this.sign_in.TabIndex = 13;
            this.sign_in.Text = "Sign in";
            this.sign_in.UseVisualStyleBackColor = true;
            // 
            // signupform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 382);
            this.Controls.Add(this.sign_in);
            this.Controls.Add(this.emp_pass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.emmp_gender);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.emp_age);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.emp_initial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emp_Lname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emp_Fname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "signupform";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emp_Fname;
        private System.Windows.Forms.TextBox emp_Lname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emp_initial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emp_age;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox emmp_gender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emp_pass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button sign_in;
    }
}