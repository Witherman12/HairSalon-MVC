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
            label1.Size = new Size(248, 31);
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
            dgvAppointments.Location = new Point(0, 34);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RowHeadersWidth = 51;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(738, 409);
            dgvAppointments.TabIndex = 1;
            dgvAppointments.CellContentClick += dgvAppointments_CellContentClick;
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
            btnEditAppointment.FlatStyle = FlatStyle.Flat;
            btnEditAppointment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnEditAppointment.ForeColor = Color.WhiteSmoke;
            btnEditAppointment.Location = new Point(259, 443);
            btnEditAppointment.Name = "btnEditAppointment";
            btnEditAppointment.Size = new Size(220, 50);
            btnEditAppointment.TabIndex = 3;
            btnEditAppointment.Text = "Επεξεργασία";
            btnEditAppointment.UseVisualStyleBackColor = false;
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
            btnCancelAppointment.TabIndex = 4;
            btnCancelAppointment.Text = "Ακύρωση/Διαγραφή";
            btnCancelAppointment.UseVisualStyleBackColor = false;
            // 
            // dtpDateFilter
            // 
            dtpDateFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDateFilter.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 161);
            dtpDateFilter.CalendarForeColor = SystemColors.ActiveCaptionText;
            dtpDateFilter.CalendarMonthBackground = Color.WhiteSmoke;
            dtpDateFilter.Cursor = Cursors.Hand;
            dtpDateFilter.Format = DateTimePickerFormat.Short;
            dtpDateFilter.Location = new Point(611, -2);
            dtpDateFilter.Name = "dtpDateFilter";
            dtpDateFilter.Size = new Size(127, 27);
            dtpDateFilter.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 443);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 50);
            panel1.TabIndex = 6;
            // 
            // AppointmentsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(dtpDateFilter);
            Controls.Add(btnCancelAppointment);
            Controls.Add(btnEditAppointment);
            Controls.Add(btnNewAppointment);
            Controls.Add(dgvAppointments);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "AppointmentsUC";
            Size = new Size(738, 493);
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
