namespace HairSalonApp
{
    partial class AppointmentsUC
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
            dgvAppointments = new DataGridView();
            btnNewAppointment = new Button();
            btnEditAppointment = new Button();
            btnCancelAppointment = new Button();
            dtpDateFilter = new DateTimePicker();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
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
            label1.Size = new Size(205, 25);
            label1.TabIndex = 0;
            label1.Text = "Διαχείριση Ραντεβού";
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.WhiteSmoke;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.Location = new Point(0, 25);
            dgvAppointments.Margin = new Padding(3, 2, 3, 2);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RowHeadersWidth = 51;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(646, 307);
            dgvAppointments.TabIndex = 1;
            dgvAppointments.CellContentClick += dgvAppointments_CellContentClick;
            // 
            // btnNewAppointment
            // 
            btnNewAppointment.Anchor = AnchorStyles.Bottom;
            btnNewAppointment.BackColor = Color.Green;
            btnNewAppointment.Cursor = Cursors.Hand;
            btnNewAppointment.FlatAppearance.BorderSize = 0;
            btnNewAppointment.FlatStyle = FlatStyle.Flat;
            btnNewAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnNewAppointment.ForeColor = Color.WhiteSmoke;
            btnNewAppointment.Location = new Point(0, 332);
            btnNewAppointment.Margin = new Padding(3, 2, 3, 2);
            btnNewAppointment.Name = "btnNewAppointment";
            btnNewAppointment.Size = new Size(192, 38);
            btnNewAppointment.TabIndex = 2;
            btnNewAppointment.Text = "Νέο Ραντεβού";
            btnNewAppointment.UseVisualStyleBackColor = false;
            btnNewAppointment.Click += btnNewAppointment_Click;
            // 
            // btnEditAppointment
            // 
            btnEditAppointment.Anchor = AnchorStyles.Bottom;
            btnEditAppointment.BackColor = Color.DarkOrange;
            btnEditAppointment.Cursor = Cursors.Hand;
            btnEditAppointment.FlatAppearance.BorderSize = 0;
            btnEditAppointment.FlatStyle = FlatStyle.Flat;
            btnEditAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnEditAppointment.ForeColor = Color.WhiteSmoke;
            btnEditAppointment.Location = new Point(227, 332);
            btnEditAppointment.Margin = new Padding(3, 2, 3, 2);
            btnEditAppointment.Name = "btnEditAppointment";
            btnEditAppointment.Size = new Size(192, 38);
            btnEditAppointment.TabIndex = 3;
            btnEditAppointment.Text = "Επεξεργασία";
            btnEditAppointment.UseVisualStyleBackColor = false;
            btnEditAppointment.Click += btnEditAppointment_Click;
            // 
            // btnCancelAppointment
            // 
            btnCancelAppointment.Anchor = AnchorStyles.Bottom;
            btnCancelAppointment.BackColor = Color.DarkRed;
            btnCancelAppointment.Cursor = Cursors.Hand;
            btnCancelAppointment.FlatAppearance.BorderSize = 0;
            btnCancelAppointment.FlatStyle = FlatStyle.Flat;
            btnCancelAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnCancelAppointment.ForeColor = Color.WhiteSmoke;
            btnCancelAppointment.Location = new Point(453, 332);
            btnCancelAppointment.Margin = new Padding(3, 2, 3, 2);
            btnCancelAppointment.Name = "btnCancelAppointment";
            btnCancelAppointment.Size = new Size(192, 38);
            btnCancelAppointment.TabIndex = 4;
            btnCancelAppointment.Text = "Ακύρωση/Διαγραφή";
            btnCancelAppointment.UseVisualStyleBackColor = false;
            btnCancelAppointment.Click += btnCancelAppointment_Click_1;
            // 
            // dtpDateFilter
            // 
            dtpDateFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDateFilter.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 161);
            dtpDateFilter.CalendarForeColor = SystemColors.ActiveCaptionText;
            dtpDateFilter.CalendarMonthBackground = Color.WhiteSmoke;
            dtpDateFilter.Cursor = Cursors.Hand;
            dtpDateFilter.Format = DateTimePickerFormat.Short;
            dtpDateFilter.Location = new Point(535, -2);
            dtpDateFilter.Margin = new Padding(3, 2, 3, 2);
            dtpDateFilter.Name = "dtpDateFilter";
            dtpDateFilter.Size = new Size(112, 23);
            dtpDateFilter.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 332);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(646, 38);
            panel1.TabIndex = 6;
            // 
            // AppointmentsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(dtpDateFilter);
            Controls.Add(btnCancelAppointment);
            Controls.Add(btnEditAppointment);
            Controls.Add(btnNewAppointment);
            Controls.Add(dgvAppointments);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AppointmentsUC";
            Size = new Size(646, 370);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvAppointments;
        private Button btnNewAppointment;
        private Button btnEditAppointment;
        private Button btnCancelAppointment;
        private DateTimePicker dtpDateFilter;
        private Panel panel1;
    }
}
