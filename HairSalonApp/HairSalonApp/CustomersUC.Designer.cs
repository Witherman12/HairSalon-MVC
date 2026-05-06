namespace HairSalonApp
{
    partial class CustomersUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dgvCustomers = new DataGridView();
            btnDeleteCustomer = new Button();
            btnEditCustomer = new Button();
            btnNewCustomer = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(197, 31);
            label1.TabIndex = 1;
            label1.Text = "Αρχείο Πελατών";
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.WhiteSmoke;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(0, 31);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(738, 462);
            dgvCustomers.TabIndex = 2;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Anchor = AnchorStyles.Bottom;
            btnDeleteCustomer.BackColor = Color.DarkRed;
            btnDeleteCustomer.Cursor = Cursors.Hand;
            btnDeleteCustomer.FlatAppearance.BorderSize = 0;
            btnDeleteCustomer.FlatStyle = FlatStyle.Flat;
            btnDeleteCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnDeleteCustomer.ForeColor = Color.WhiteSmoke;
            btnDeleteCustomer.Location = new Point(518, 443);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(220, 50);
            btnDeleteCustomer.TabIndex = 10;
            btnDeleteCustomer.Text = "Διαγραφή";
            btnDeleteCustomer.UseVisualStyleBackColor = false;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnEditCustomer
            // 
            btnEditCustomer.Anchor = AnchorStyles.Bottom;
            btnEditCustomer.BackColor = Color.DarkOrange;
            btnEditCustomer.Cursor = Cursors.Hand;
            btnEditCustomer.FlatAppearance.BorderSize = 0;
            btnEditCustomer.FlatStyle = FlatStyle.Flat;
            btnEditCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnEditCustomer.ForeColor = Color.WhiteSmoke;
            btnEditCustomer.Location = new Point(259, 443);
            btnEditCustomer.Name = "btnEditCustomer";
            btnEditCustomer.Size = new Size(220, 50);
            btnEditCustomer.TabIndex = 9;
            btnEditCustomer.Text = "Επεξεργασία";
            btnEditCustomer.UseVisualStyleBackColor = false;
            btnEditCustomer.Click += btnEditCustomer_Click;
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Anchor = AnchorStyles.Bottom;
            btnNewCustomer.BackColor = Color.Green;
            btnNewCustomer.Cursor = Cursors.Hand;
            btnNewCustomer.FlatAppearance.BorderSize = 0;
            btnNewCustomer.FlatStyle = FlatStyle.Flat;
            btnNewCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnNewCustomer.ForeColor = Color.WhiteSmoke;
            btnNewCustomer.Location = new Point(0, 443);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(220, 50);
            btnNewCustomer.TabIndex = 8;
            btnNewCustomer.Text = "Νέος Πελάτης";
            btnNewCustomer.UseVisualStyleBackColor = false;
            btnNewCustomer.Click += btnNewCustomer_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 443);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 50);
            panel1.TabIndex = 11;
            // 
            // CustomersUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnEditCustomer);
            Controls.Add(btnNewCustomer);
            Controls.Add(panel1);
            Controls.Add(dgvCustomers);
            Controls.Add(label1);
            Name = "CustomersUC";
            Size = new Size(738, 493);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvCustomers;
        private Button btnDeleteCustomer;
        private Button btnEditCustomer;
        private Button btnNewCustomer;
        private Panel panel1;
    }
}
