namespace HairSalonApp
{
    partial class EmployeesUC
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
            btnDeleteEmployee = new Button();
            btnEditEmployee = new Button();
            btnNewEmployee = new Button();
            panel1 = new Panel();
            dgvEmployees = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // btnDeleteEmployee
            // 
            btnDeleteEmployee.Anchor = AnchorStyles.Bottom;
            btnDeleteEmployee.BackColor = Color.DarkRed;
            btnDeleteEmployee.Cursor = Cursors.Hand;
            btnDeleteEmployee.FlatAppearance.BorderSize = 0;
            btnDeleteEmployee.FlatStyle = FlatStyle.Flat;
            btnDeleteEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnDeleteEmployee.ForeColor = Color.WhiteSmoke;
            btnDeleteEmployee.Location = new Point(518, 443);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(219, 51);
            btnDeleteEmployee.TabIndex = 10;
            btnDeleteEmployee.Text = "Διαγραφή";
            btnDeleteEmployee.UseVisualStyleBackColor = false;
            btnDeleteEmployee.Click += btnDeleteEmployee_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.Anchor = AnchorStyles.Bottom;
            btnEditEmployee.BackColor = Color.DarkOrange;
            btnEditEmployee.Cursor = Cursors.Hand;
            btnEditEmployee.FlatAppearance.BorderSize = 0;
            btnEditEmployee.FlatStyle = FlatStyle.Flat;
            btnEditEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnEditEmployee.ForeColor = Color.WhiteSmoke;
            btnEditEmployee.Location = new Point(259, 443);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(219, 51);
            btnEditEmployee.TabIndex = 9;
            btnEditEmployee.Text = "Επεξεργασία";
            btnEditEmployee.UseVisualStyleBackColor = false;
            btnEditEmployee.Click += btnEditEmployee_Click;
            // 
            // btnNewEmployee
            // 
            btnNewEmployee.Anchor = AnchorStyles.Bottom;
            btnNewEmployee.BackColor = Color.Green;
            btnNewEmployee.Cursor = Cursors.Hand;
            btnNewEmployee.FlatAppearance.BorderSize = 0;
            btnNewEmployee.FlatStyle = FlatStyle.Flat;
            btnNewEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnNewEmployee.ForeColor = Color.WhiteSmoke;
            btnNewEmployee.Location = new Point(0, 443);
            btnNewEmployee.Name = "btnNewEmployee";
            btnNewEmployee.Size = new Size(219, 51);
            btnNewEmployee.TabIndex = 8;
            btnNewEmployee.Text = "Νέος Υπάλληλος";
            btnNewEmployee.UseVisualStyleBackColor = false;
            btnNewEmployee.Click += btnNewEmployee_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 442);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 51);
            panel1.TabIndex = 11;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.WhiteSmoke;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.Location = new Point(0, 31);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(738, 411);
            dgvEmployees.TabIndex = 12;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
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
            label1.Size = new Size(144, 31);
            label1.TabIndex = 13;
            label1.Text = "Προσωπικό";
            // 
            // EmployeesUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvEmployees);
            Controls.Add(btnDeleteEmployee);
            Controls.Add(btnEditEmployee);
            Controls.Add(btnNewEmployee);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "EmployeesUC";
            Size = new Size(738, 493);
            Load += EmployeesUC_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDeleteEmployee;
        private Button btnEditEmployee;
        private Button btnNewEmployee;
        private Panel panel1;
        private DataGridView dgvEmployees;
        private Label label1;
    }
}
