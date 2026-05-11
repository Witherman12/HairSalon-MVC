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
            btnDeleteEmployee.Location = new Point(453, 332);
            btnDeleteEmployee.Margin = new Padding(3, 2, 3, 2);
            btnDeleteEmployee.Name = "btnDeleteEmployee";
            btnDeleteEmployee.Size = new Size(192, 38);
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
            btnEditEmployee.Location = new Point(227, 332);
            btnEditEmployee.Margin = new Padding(3, 2, 3, 2);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(192, 38);
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
            btnNewEmployee.Location = new Point(0, 332);
            btnNewEmployee.Margin = new Padding(3, 2, 3, 2);
            btnNewEmployee.Name = "btnNewEmployee";
            btnNewEmployee.Size = new Size(192, 38);
            btnNewEmployee.TabIndex = 8;
            btnNewEmployee.Text = "Νέος Υπάλληλος";
            btnNewEmployee.UseVisualStyleBackColor = false;
            btnNewEmployee.Click += btnNewEmployee_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 332);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(646, 38);
            panel1.TabIndex = 11;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.WhiteSmoke;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(0, 26);
            dgvEmployees.Margin = new Padding(3, 2, 3, 2);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(643, 307);
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
            label1.Size = new Size(121, 25);
            label1.TabIndex = 13;
            label1.Text = "Προσωπικό";
            // 
            // EmployeesUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(dgvEmployees);
            Controls.Add(btnDeleteEmployee);
            Controls.Add(btnEditEmployee);
            Controls.Add(btnNewEmployee);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmployeesUC";
            Size = new Size(646, 370);
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
