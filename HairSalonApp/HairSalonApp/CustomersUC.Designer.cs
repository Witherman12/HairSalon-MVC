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
            btnCancelAppointment = new Button();
            btnEditAppointment = new Button();
            btnNewAppointment = new Button();
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
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.WhiteSmoke;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(0, 34);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(738, 459);
            dgvCustomers.TabIndex = 2;
            // 
            // btnCancelAppointment
            // 
            btnCancelAppointment.Anchor = AnchorStyles.Bottom;
            btnCancelAppointment.BackColor = Color.DarkRed;
            btnCancelAppointment.Cursor = Cursors.Hand;
            btnCancelAppointment.FlatStyle = FlatStyle.Flat;
            btnCancelAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnCancelAppointment.ForeColor = Color.WhiteSmoke;
            btnCancelAppointment.Location = new Point(518, 443);
            btnCancelAppointment.Name = "btnCancelAppointment";
            btnCancelAppointment.Size = new Size(220, 50);
            btnCancelAppointment.TabIndex = 10;
            btnCancelAppointment.Text = "Διαγραφή";
            btnCancelAppointment.UseVisualStyleBackColor = false;
            // 
            // btnEditAppointment
            // 
            btnEditAppointment.Anchor = AnchorStyles.Bottom;
            btnEditAppointment.BackColor = Color.DarkOrange;
            btnEditAppointment.Cursor = Cursors.Hand;
            btnEditAppointment.FlatStyle = FlatStyle.Flat;
            btnEditAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnEditAppointment.ForeColor = Color.WhiteSmoke;
            btnEditAppointment.Location = new Point(259, 443);
            btnEditAppointment.Name = "btnEditAppointment";
            btnEditAppointment.Size = new Size(220, 50);
            btnEditAppointment.TabIndex = 9;
            btnEditAppointment.Text = "Επεξεργασία";
            btnEditAppointment.UseVisualStyleBackColor = false;
            // 
            // btnNewAppointment
            // 
            btnNewAppointment.Anchor = AnchorStyles.Bottom;
            btnNewAppointment.BackColor = Color.Green;
            btnNewAppointment.Cursor = Cursors.Hand;
            btnNewAppointment.FlatStyle = FlatStyle.Flat;
            btnNewAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnNewAppointment.ForeColor = Color.WhiteSmoke;
            btnNewAppointment.Location = new Point(0, 443);
            btnNewAppointment.Name = "btnNewAppointment";
            btnNewAppointment.Size = new Size(220, 50);
            btnNewAppointment.TabIndex = 8;
            btnNewAppointment.Text = "Νέος Πελάτης";
            btnNewAppointment.UseVisualStyleBackColor = false;
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
            Controls.Add(btnCancelAppointment);
            Controls.Add(btnEditAppointment);
            Controls.Add(btnNewAppointment);
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
        private Button btnCancelAppointment;
        private Button btnEditAppointment;
        private Button btnNewAppointment;
        private Panel panel1;
    }
}
