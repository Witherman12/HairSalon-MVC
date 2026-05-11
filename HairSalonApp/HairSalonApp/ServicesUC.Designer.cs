namespace HairSalonApp
{
    partial class ServicesUC
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
            panel1 = new Panel();
            btnDeleteService = new Button();
            btnEditService = new Button();
            btnNewService = new Button();
            label1 = new Label();
            dgvServices = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(btnDeleteService);
            panel1.Controls.Add(btnEditService);
            panel1.Controls.Add(btnNewService);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 332);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(646, 38);
            panel1.TabIndex = 12;
            // 
            // btnDeleteService
            // 
            btnDeleteService.Anchor = AnchorStyles.Bottom;
            btnDeleteService.BackColor = Color.DarkRed;
            btnDeleteService.Cursor = Cursors.Hand;
            btnDeleteService.FlatAppearance.BorderSize = 0;
            btnDeleteService.FlatStyle = FlatStyle.Flat;
            btnDeleteService.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnDeleteService.ForeColor = Color.WhiteSmoke;
            btnDeleteService.Location = new Point(453, 0);
            btnDeleteService.Margin = new Padding(3, 2, 3, 2);
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new Size(192, 38);
            btnDeleteService.TabIndex = 13;
            btnDeleteService.Text = "Διαγραφή";
            btnDeleteService.UseVisualStyleBackColor = false;
            btnDeleteService.Click += btnDeleteService_Click;
            // 
            // btnEditService
            // 
            btnEditService.Anchor = AnchorStyles.Bottom;
            btnEditService.BackColor = Color.DarkOrange;
            btnEditService.Cursor = Cursors.Hand;
            btnEditService.FlatAppearance.BorderSize = 0;
            btnEditService.FlatStyle = FlatStyle.Flat;
            btnEditService.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnEditService.ForeColor = Color.WhiteSmoke;
            btnEditService.Location = new Point(227, 0);
            btnEditService.Margin = new Padding(3, 2, 3, 2);
            btnEditService.Name = "btnEditService";
            btnEditService.Size = new Size(192, 38);
            btnEditService.TabIndex = 13;
            btnEditService.Text = "Επεξεργασία";
            btnEditService.UseVisualStyleBackColor = false;
            btnEditService.Click += btnEditService_Click;
            // 
            // btnNewService
            // 
            btnNewService.Anchor = AnchorStyles.Bottom;
            btnNewService.BackColor = Color.Green;
            btnNewService.Cursor = Cursors.Hand;
            btnNewService.FlatAppearance.BorderSize = 0;
            btnNewService.FlatStyle = FlatStyle.Flat;
            btnNewService.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnNewService.ForeColor = Color.WhiteSmoke;
            btnNewService.Location = new Point(0, 0);
            btnNewService.Margin = new Padding(3, 2, 3, 2);
            btnNewService.Name = "btnNewService";
            btnNewService.Size = new Size(192, 38);
            btnNewService.TabIndex = 13;
            btnNewService.Text = "Νέα Υπηρεσία";
            btnNewService.UseVisualStyleBackColor = false;
            btnNewService.Click += btnNewService_Click;
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
            label1.Size = new Size(106, 25);
            label1.TabIndex = 13;
            label1.Text = "Υπηρεσίες";
            // 
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.BackgroundColor = Color.WhiteSmoke;
            dgvServices.BorderStyle = BorderStyle.None;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.Location = new Point(0, 25);
            dgvServices.Margin = new Padding(3, 2, 3, 2);
            dgvServices.Name = "dgvServices";
            dgvServices.RowHeadersWidth = 51;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(646, 307);
            dgvServices.TabIndex = 14;
            dgvServices.CellContentClick += dgvServices_CellContentClick;
            // 
            // ServicesUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvServices);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ServicesUC";
            Size = new Size(646, 370);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnNewService;
        private Button btnEditService;
        private Button btnDeleteService;
        private Label label1;
        private DataGridView dgvServices;
    }
}
