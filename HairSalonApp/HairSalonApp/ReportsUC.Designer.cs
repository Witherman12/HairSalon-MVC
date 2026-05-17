namespace HairSalonApp
{
    partial class ReportsUC
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
            tabControl1 = new TabControl();
            AppointmentsByDateGrid = new TabPage();
            panelFilters = new Panel();
            btnApplyFilter = new Button();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            dgvAppointmentsByDate = new DataGridView();
            EmployeeAppointmentsGrid = new TabPage();
            dgvEmployeeAppointments = new DataGridView();
            RevenueServiceGrid = new TabPage();
            dgvRevenueService = new DataGridView();
            UseServicesGrid = new TabPage();
            dgvServiceUsage = new DataGridView();
            btnRefresh = new Button();
            panel1 = new Panel();
            btnExportExcel = new Button();
            btnExportPdf = new Button();
            btnPrint = new Button();
            btnFilters = new Button();
            tabControl1.SuspendLayout();
            AppointmentsByDateGrid.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointmentsByDate).BeginInit();
            EmployeeAppointmentsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeAppointments).BeginInit();
            RevenueServiceGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenueService).BeginInit();
            UseServicesGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServiceUsage).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(125, 31);
            label1.TabIndex = 16;
            label1.Text = "Αναφορές";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(AppointmentsByDateGrid);
            tabControl1.Controls.Add(EmployeeAppointmentsGrid);
            tabControl1.Controls.Add(RevenueServiceGrid);
            tabControl1.Controls.Add(UseServicesGrid);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 161);
            tabControl1.Location = new Point(0, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(738, 411);
            tabControl1.TabIndex = 19;
            // 
            // AppointmentsByDateGrid
            // 
            AppointmentsByDateGrid.BackColor = Color.WhiteSmoke;
            AppointmentsByDateGrid.Controls.Add(panelFilters);
            AppointmentsByDateGrid.Controls.Add(dgvAppointmentsByDate);
            AppointmentsByDateGrid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            AppointmentsByDateGrid.Location = new Point(4, 37);
            AppointmentsByDateGrid.Name = "AppointmentsByDateGrid";
            AppointmentsByDateGrid.Padding = new Padding(3);
            AppointmentsByDateGrid.Size = new Size(730, 370);
            AppointmentsByDateGrid.TabIndex = 0;
            AppointmentsByDateGrid.Text = "Ραντεβού ανά Ημερομηνία";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.Gainsboro;
            panelFilters.Controls.Add(btnApplyFilter);
            panelFilters.Controls.Add(dtpFrom);
            panelFilters.Controls.Add(dtpTo);
            panelFilters.Controls.Add(label3);
            panelFilters.Controls.Add(label2);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(3, 3);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(724, 85);
            panelFilters.TabIndex = 4;
            panelFilters.Visible = false;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.BackColor = Color.SpringGreen;
            btnApplyFilter.FlatAppearance.BorderSize = 0;
            btnApplyFilter.FlatStyle = FlatStyle.Flat;
            btnApplyFilter.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnApplyFilter.ForeColor = Color.Black;
            btnApplyFilter.Location = new Point(3, 51);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(125, 31);
            btnApplyFilter.TabIndex = 23;
            btnApplyFilter.Text = "Εφαρμογή";
            btnApplyFilter.TextAlign = ContentAlignment.TopCenter;
            btnApplyFilter.UseVisualStyleBackColor = false;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(64, 6);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(250, 34);
            dtpFrom.TabIndex = 20;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(405, 7);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(250, 34);
            dtpTo.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(3, 12);
            label3.Name = "label3";
            label3.Size = new Size(55, 28);
            label3.TabIndex = 18;
            label3.Text = "Από:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(345, 12);
            label2.Name = "label2";
            label2.Size = new Size(54, 28);
            label2.TabIndex = 17;
            label2.Text = "Έως:";
            // 
            // dgvAppointmentsByDate
            // 
            dgvAppointmentsByDate.AllowUserToAddRows = false;
            dgvAppointmentsByDate.AllowUserToDeleteRows = false;
            dgvAppointmentsByDate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointmentsByDate.BackgroundColor = Color.GhostWhite;
            dgvAppointmentsByDate.BorderStyle = BorderStyle.None;
            dgvAppointmentsByDate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointmentsByDate.Dock = DockStyle.Fill;
            dgvAppointmentsByDate.Location = new Point(3, 3);
            dgvAppointmentsByDate.Name = "dgvAppointmentsByDate";
            dgvAppointmentsByDate.ReadOnly = true;
            dgvAppointmentsByDate.RowHeadersVisible = false;
            dgvAppointmentsByDate.RowHeadersWidth = 51;
            dgvAppointmentsByDate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointmentsByDate.Size = new Size(724, 364);
            dgvAppointmentsByDate.TabIndex = 3;
            dgvAppointmentsByDate.CellContentClick += dgvAppointmentsByDate_CellContentClick;
            // 
            // EmployeeAppointmentsGrid
            // 
            EmployeeAppointmentsGrid.BackColor = Color.WhiteSmoke;
            EmployeeAppointmentsGrid.Controls.Add(dgvEmployeeAppointments);
            EmployeeAppointmentsGrid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            EmployeeAppointmentsGrid.Location = new Point(4, 37);
            EmployeeAppointmentsGrid.Name = "EmployeeAppointmentsGrid";
            EmployeeAppointmentsGrid.Padding = new Padding(3);
            EmployeeAppointmentsGrid.Size = new Size(730, 370);
            EmployeeAppointmentsGrid.TabIndex = 1;
            EmployeeAppointmentsGrid.Text = "Ραντεβού ανά Υπάλληλο";
            // 
            // dgvEmployeeAppointments
            // 
            dgvEmployeeAppointments.AllowUserToAddRows = false;
            dgvEmployeeAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployeeAppointments.BackgroundColor = Color.GhostWhite;
            dgvEmployeeAppointments.BorderStyle = BorderStyle.None;
            dgvEmployeeAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployeeAppointments.Dock = DockStyle.Fill;
            dgvEmployeeAppointments.Location = new Point(3, 3);
            dgvEmployeeAppointments.Name = "dgvEmployeeAppointments";
            dgvEmployeeAppointments.ReadOnly = true;
            dgvEmployeeAppointments.RowHeadersVisible = false;
            dgvEmployeeAppointments.RowHeadersWidth = 51;
            dgvEmployeeAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployeeAppointments.Size = new Size(724, 364);
            dgvEmployeeAppointments.TabIndex = 2;
            // 
            // RevenueServiceGrid
            // 
            RevenueServiceGrid.BackColor = Color.WhiteSmoke;
            RevenueServiceGrid.Controls.Add(dgvRevenueService);
            RevenueServiceGrid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            RevenueServiceGrid.Location = new Point(4, 37);
            RevenueServiceGrid.Name = "RevenueServiceGrid";
            RevenueServiceGrid.Padding = new Padding(3);
            RevenueServiceGrid.Size = new Size(730, 370);
            RevenueServiceGrid.TabIndex = 2;
            RevenueServiceGrid.Text = "Έσοδα ανά Υπηρεσία";
            // 
            // dgvRevenueService
            // 
            dgvRevenueService.AllowUserToAddRows = false;
            dgvRevenueService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenueService.BackgroundColor = Color.GhostWhite;
            dgvRevenueService.BorderStyle = BorderStyle.None;
            dgvRevenueService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenueService.Dock = DockStyle.Fill;
            dgvRevenueService.Location = new Point(3, 3);
            dgvRevenueService.Name = "dgvRevenueService";
            dgvRevenueService.ReadOnly = true;
            dgvRevenueService.RowHeadersVisible = false;
            dgvRevenueService.RowHeadersWidth = 51;
            dgvRevenueService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenueService.Size = new Size(724, 364);
            dgvRevenueService.TabIndex = 2;
            dgvRevenueService.CellContentClick += dgvRevenueService_CellContentClick;
            // 
            // UseServicesGrid
            // 
            UseServicesGrid.BackColor = Color.WhiteSmoke;
            UseServicesGrid.Controls.Add(dgvServiceUsage);
            UseServicesGrid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            UseServicesGrid.Location = new Point(4, 37);
            UseServicesGrid.Name = "UseServicesGrid";
            UseServicesGrid.Padding = new Padding(3);
            UseServicesGrid.Size = new Size(730, 370);
            UseServicesGrid.TabIndex = 3;
            UseServicesGrid.Text = "Χρήση Υπηρεσιών";
            // 
            // dgvServiceUsage
            // 
            dgvServiceUsage.AllowUserToAddRows = false;
            dgvServiceUsage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServiceUsage.BackgroundColor = Color.GhostWhite;
            dgvServiceUsage.BorderStyle = BorderStyle.None;
            dgvServiceUsage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServiceUsage.Dock = DockStyle.Fill;
            dgvServiceUsage.Location = new Point(3, 3);
            dgvServiceUsage.Name = "dgvServiceUsage";
            dgvServiceUsage.ReadOnly = true;
            dgvServiceUsage.RowHeadersVisible = false;
            dgvServiceUsage.RowHeadersWidth = 51;
            dgvServiceUsage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServiceUsage.Size = new Size(724, 364);
            dgvServiceUsage.TabIndex = 1;
            dgvServiceUsage.CellContentClick += dataGridView4_CellContentClick;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom;
            btnRefresh.BackColor = Color.Sienna;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(175, 51);
            btnRefresh.TabIndex = 20;
            btnRefresh.Text = "Ανανέωση";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(btnExportExcel);
            panel1.Controls.Add(btnExportPdf);
            panel1.Controls.Add(btnPrint);
            panel1.Controls.Add(btnRefresh);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 442);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 51);
            panel1.TabIndex = 21;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Bottom;
            btnExportExcel.BackColor = Color.ForestGreen;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(563, -1);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(175, 51);
            btnExportExcel.TabIndex = 24;
            btnExportExcel.Text = "Εξαγωγή Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Anchor = AnchorStyles.Bottom;
            btnExportPdf.BackColor = Color.Crimson;
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(375, 0);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(175, 51);
            btnExportPdf.TabIndex = 23;
            btnExportPdf.Text = "Εξαγωγή PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Bottom;
            btnPrint.BackColor = Color.RoyalBlue;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(187, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(175, 51);
            btnPrint.TabIndex = 21;
            btnPrint.Text = "Εκτύπωση";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnFilters
            // 
            btnFilters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilters.BackColor = Color.Yellow;
            btnFilters.FlatAppearance.BorderSize = 0;
            btnFilters.FlatStyle = FlatStyle.Flat;
            btnFilters.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnFilters.ForeColor = Color.Black;
            btnFilters.Location = new Point(613, 0);
            btnFilters.Name = "btnFilters";
            btnFilters.Size = new Size(125, 31);
            btnFilters.TabIndex = 22;
            btnFilters.Text = "Φίλτρα";
            btnFilters.TextAlign = ContentAlignment.TopCenter;
            btnFilters.UseVisualStyleBackColor = false;
            btnFilters.Click += btnFilters_Click;
            // 
            // ReportsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnFilters);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "ReportsUC";
            Size = new Size(738, 493);
            Load += ReportsUC_Load;
            tabControl1.ResumeLayout(false);
            AppointmentsByDateGrid.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointmentsByDate).EndInit();
            EmployeeAppointmentsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeAppointments).EndInit();
            RevenueServiceGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRevenueService).EndInit();
            UseServicesGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServiceUsage).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TabControl tabControl1;
        private TabPage AppointmentsByDateGrid;
        private TabPage EmployeeAppointmentsGrid;
        private TabPage RevenueServiceGrid;
        private TabPage UseServicesGrid;
        private DataGridView dgvServiceUsage;
        private Button btnRefresh;
        private Panel panel1;
        private Button btnPrint;
        private Button btnExportPdf;
        private Button btnFilters;
        private DataGridView dgvAppointmentsByDate;
        private DataGridView dgvEmployeeAppointments;
        private DataGridView dgvRevenueService;
        private Button btnExportExcel;
        private Panel panelFilters;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnApplyFilter;
    }
}
