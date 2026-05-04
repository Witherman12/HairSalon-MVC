namespace HairSalonApp
{
    partial class DashboardForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            Sidebar = new Panel();
            btnReports = new Button();
            DashboardImageList = new ImageList(components);
            btnLogout = new Button();
            btnEmployees = new Button();
            btnServices = new Button();
            btnCustomers = new Button();
            btnAppointments = new Button();
            Topbar = new Panel();
            pictureBox1 = new PictureBox();
            lblCurrentUser = new Label();
            MainMenu = new Label();
            MainPanel = new Panel();
            Sidebar.SuspendLayout();
            Topbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Sidebar
            // 
            Sidebar.BackColor = Color.Gray;
            Sidebar.Controls.Add(btnReports);
            Sidebar.Controls.Add(btnLogout);
            Sidebar.Controls.Add(btnEmployees);
            Sidebar.Controls.Add(btnServices);
            Sidebar.Controls.Add(btnCustomers);
            Sidebar.Controls.Add(btnAppointments);
            Sidebar.Dock = DockStyle.Left;
            Sidebar.Location = new Point(0, 0);
            Sidebar.Name = "Sidebar";
            Sidebar.Size = new Size(244, 553);
            Sidebar.TabIndex = 0;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.Transparent;
            btnReports.Cursor = Cursors.Hand;
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnReports.ForeColor = Color.White;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.ImageIndex = 2;
            btnReports.ImageList = DashboardImageList;
            btnReports.Location = new Point(0, 200);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(10, 0, 0, 0);
            btnReports.Size = new Size(244, 50);
            btnReports.TabIndex = 5;
            btnReports.Text = "  Αναφορές";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = false;
            // 
            // DashboardImageList
            // 
            DashboardImageList.ColorDepth = ColorDepth.Depth32Bit;
            DashboardImageList.ImageStream = (ImageListStreamer)resources.GetObject("DashboardImageList.ImageStream");
            DashboardImageList.TransparentColor = Color.Transparent;
            DashboardImageList.Images.SetKeyName(0, "Calendar.png");
            DashboardImageList.Images.SetKeyName(1, "Customers.png");
            DashboardImageList.Images.SetKeyName(2, "Reports.png");
            DashboardImageList.Images.SetKeyName(3, "Services.png");
            DashboardImageList.Images.SetKeyName(4, "UserIcon.png");
            DashboardImageList.Images.SetKeyName(5, "Logout.png");
            DashboardImageList.Images.SetKeyName(6, "Employees.png");
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DodgerBlue;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderColor = Color.Black;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Popup;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnLogout.ForeColor = Color.Black;
            btnLogout.ImageAlign = ContentAlignment.MiddleRight;
            btnLogout.ImageIndex = 5;
            btnLogout.ImageList = DashboardImageList;
            btnLogout.Location = new Point(0, 503);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(0, 0, 10, 0);
            btnLogout.Size = new Size(244, 50);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Αποσύνδεση";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.Transparent;
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmployees.ImageIndex = 6;
            btnEmployees.ImageList = DashboardImageList;
            btnEmployees.Location = new Point(0, 150);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(10, 0, 0, 0);
            btnEmployees.Size = new Size(244, 50);
            btnEmployees.TabIndex = 3;
            btnEmployees.Text = "  Προσωπικό";
            btnEmployees.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployees.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployees.UseVisualStyleBackColor = false;
            // 
            // btnServices
            // 
            btnServices.BackColor = Color.Transparent;
            btnServices.Cursor = Cursors.Hand;
            btnServices.Dock = DockStyle.Top;
            btnServices.FlatAppearance.BorderSize = 0;
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnServices.ForeColor = Color.White;
            btnServices.ImageAlign = ContentAlignment.MiddleLeft;
            btnServices.ImageIndex = 3;
            btnServices.ImageList = DashboardImageList;
            btnServices.Location = new Point(0, 100);
            btnServices.Name = "btnServices";
            btnServices.Padding = new Padding(10, 0, 0, 0);
            btnServices.Size = new Size(244, 50);
            btnServices.TabIndex = 2;
            btnServices.Text = "  Υπηρεσίες";
            btnServices.TextAlign = ContentAlignment.MiddleLeft;
            btnServices.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServices.UseVisualStyleBackColor = false;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.Transparent;
            btnCustomers.Cursor = Cursors.Hand;
            btnCustomers.Dock = DockStyle.Top;
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomers.ImageIndex = 1;
            btnCustomers.ImageList = DashboardImageList;
            btnCustomers.Location = new Point(0, 50);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(10, 0, 0, 0);
            btnCustomers.Size = new Size(244, 50);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "  Πελάτες";
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomers.UseVisualStyleBackColor = false;
            // 
            // btnAppointments
            // 
            btnAppointments.BackColor = Color.Transparent;
            btnAppointments.Cursor = Cursors.Hand;
            btnAppointments.Dock = DockStyle.Top;
            btnAppointments.FlatAppearance.BorderSize = 0;
            btnAppointments.FlatStyle = FlatStyle.Flat;
            btnAppointments.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnAppointments.ForeColor = Color.White;
            btnAppointments.ImageAlign = ContentAlignment.MiddleLeft;
            btnAppointments.ImageIndex = 0;
            btnAppointments.ImageList = DashboardImageList;
            btnAppointments.Location = new Point(0, 0);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Padding = new Padding(10, 0, 0, 0);
            btnAppointments.Size = new Size(244, 50);
            btnAppointments.TabIndex = 0;
            btnAppointments.Text = "  Ραντεβού";
            btnAppointments.TextAlign = ContentAlignment.MiddleLeft;
            btnAppointments.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAppointments.UseVisualStyleBackColor = false;
            btnAppointments.Click += button1_Click;
            // 
            // Topbar
            // 
            Topbar.BackColor = Color.Indigo;
            Topbar.Controls.Add(pictureBox1);
            Topbar.Controls.Add(lblCurrentUser);
            Topbar.Controls.Add(MainMenu);
            Topbar.Dock = DockStyle.Top;
            Topbar.Location = new Point(244, 0);
            Topbar.Name = "Topbar";
            Topbar.Size = new Size(738, 60);
            Topbar.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(686, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            lblCurrentUser.ForeColor = Color.White;
            lblCurrentUser.Location = new Point(524, 16);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(158, 28);
            lblCurrentUser.TabIndex = 0;
            lblCurrentUser.Text = "Χρήστης: Admin";
            lblCurrentUser.Click += lblCurrentUser_Click;
            // 
            // MainMenu
            // 
            MainMenu.Anchor = AnchorStyles.Top;
            MainMenu.AutoSize = true;
            MainMenu.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 161);
            MainMenu.ForeColor = Color.White;
            MainMenu.Location = new Point(252, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(235, 38);
            MainMenu.TabIndex = 0;
            MainMenu.Text = "Κεντρικό Μενού";
            MainMenu.Click += label1_Click;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.WhiteSmoke;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(244, 60);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(738, 493);
            MainPanel.TabIndex = 2;
            MainPanel.Paint += panel1_Paint;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(MainPanel);
            Controls.Add(Topbar);
            Controls.Add(Sidebar);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 161);
            Name = "DashboardForm";
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Sidebar.ResumeLayout(false);
            Topbar.ResumeLayout(false);
            Topbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Sidebar;
        private Panel Topbar;
        private Panel MainPanel;
        private Label MainMenu;
        private Label lblCurrentUser;
        private PictureBox pictureBox1;
        private Button btnAppointments;
        private Button btnLogout;
        private Button btnEmployees;
        private Button btnServices;
        private Button btnCustomers;
        private Button btnReports;
        private ImageList DashboardImageList;
    }
}