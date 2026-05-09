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
            barrierBotomPanel = new Panel();
            btnEmployees = new Button();
            btnLogout = new Button();
            panel3 = new Panel();
            btnServices = new Button();
            panel2 = new Panel();
            btnCustomers = new Button();
            panel1 = new Panel();
            btnAppointments = new Button();
            barrierTopPanel = new Panel();
            blackPanel = new Panel();
            lblLiveDate = new Label();
            lblLiveTime = new Label();
            Topbar = new Panel();
            pictureBox1 = new PictureBox();
            lblCurrentUser = new Label();
            MainMenu = new Label();
            MainPanel = new Panel();
            timerClock = new System.Windows.Forms.Timer(components);
            Sidebar.SuspendLayout();
            blackPanel.SuspendLayout();
            Topbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Sidebar
            // 
            Sidebar.BackColor = Color.Gray;
            Sidebar.Controls.Add(btnReports);
            Sidebar.Controls.Add(barrierBotomPanel);
            Sidebar.Controls.Add(btnEmployees);
            Sidebar.Controls.Add(btnLogout);
            Sidebar.Controls.Add(panel3);
            Sidebar.Controls.Add(btnServices);
            Sidebar.Controls.Add(panel2);
            Sidebar.Controls.Add(btnCustomers);
            Sidebar.Controls.Add(panel1);
            Sidebar.Controls.Add(btnAppointments);
            Sidebar.Controls.Add(barrierTopPanel);
            Sidebar.Controls.Add(blackPanel);
            Sidebar.Dock = DockStyle.Left;
            Sidebar.Location = new Point(0, 0);
            Sidebar.Name = "Sidebar";
            Sidebar.Size = new Size(244, 553);
            Sidebar.TabIndex = 0;
            Sidebar.Paint += Sidebar_Paint_1;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.Transparent;
            btnReports.Cursor = Cursors.Hand;
            btnReports.Dock = DockStyle.Bottom;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnReports.ForeColor = Color.White;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.ImageIndex = 2;
            btnReports.ImageList = DashboardImageList;
            btnReports.Location = new Point(0, 403);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(10, 0, 0, 0);
            btnReports.Size = new Size(244, 50);
            btnReports.TabIndex = 5;
            btnReports.Text = "  Αναφορές";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
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
            // barrierBotomPanel
            // 
            barrierBotomPanel.BackColor = Color.Transparent;
            barrierBotomPanel.Dock = DockStyle.Bottom;
            barrierBotomPanel.Location = new Point(0, 453);
            barrierBotomPanel.Name = "barrierBotomPanel";
            barrierBotomPanel.Size = new Size(244, 50);
            barrierBotomPanel.TabIndex = 6;
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
            btnEmployees.Location = new Point(0, 335);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Padding = new Padding(10, 0, 0, 0);
            btnEmployees.Size = new Size(244, 50);
            btnEmployees.TabIndex = 3;
            btnEmployees.Text = "  Προσωπικό";
            btnEmployees.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployees.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Crimson;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderColor = Color.Black;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Popup;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnLogout.ForeColor = Color.Snow;
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
            btnLogout.Click += btnLogout_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 310);
            panel3.Name = "panel3";
            panel3.Size = new Size(244, 25);
            panel3.TabIndex = 2;
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
            btnServices.Location = new Point(0, 260);
            btnServices.Name = "btnServices";
            btnServices.Padding = new Padding(10, 0, 0, 0);
            btnServices.Size = new Size(244, 50);
            btnServices.TabIndex = 2;
            btnServices.Text = "  Υπηρεσίες";
            btnServices.TextAlign = ContentAlignment.MiddleLeft;
            btnServices.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += btnServices_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 235);
            panel2.Name = "panel2";
            panel2.Size = new Size(244, 25);
            panel2.TabIndex = 1;
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
            btnCustomers.Location = new Point(0, 185);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Padding = new Padding(10, 0, 0, 0);
            btnCustomers.Size = new Size(244, 50);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "  Πελάτες";
            btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 160);
            panel1.Name = "panel1";
            panel1.Size = new Size(244, 25);
            panel1.TabIndex = 0;
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
            btnAppointments.Location = new Point(0, 110);
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
            // barrierTopPanel
            // 
            barrierTopPanel.BackColor = Color.Transparent;
            barrierTopPanel.Dock = DockStyle.Top;
            barrierTopPanel.ForeColor = SystemColors.Control;
            barrierTopPanel.Location = new Point(0, 60);
            barrierTopPanel.Name = "barrierTopPanel";
            barrierTopPanel.Size = new Size(244, 50);
            barrierTopPanel.TabIndex = 0;
            // 
            // blackPanel
            // 
            blackPanel.BackColor = Color.Black;
            blackPanel.Controls.Add(lblLiveDate);
            blackPanel.Controls.Add(lblLiveTime);
            blackPanel.Dock = DockStyle.Top;
            blackPanel.Location = new Point(0, 0);
            blackPanel.Name = "blackPanel";
            blackPanel.Size = new Size(244, 60);
            blackPanel.TabIndex = 0;
            // 
            // lblLiveDate
            // 
            lblLiveDate.AutoSize = true;
            lblLiveDate.BackColor = Color.Black;
            lblLiveDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            lblLiveDate.ForeColor = Color.WhiteSmoke;
            lblLiveDate.Location = new Point(12, 16);
            lblLiveDate.Name = "lblLiveDate";
            lblLiveDate.Size = new Size(126, 28);
            lblLiveDate.TabIndex = 1;
            lblLiveDate.Text = "00/00/2000";
            // 
            // lblLiveTime
            // 
            lblLiveTime.AutoSize = true;
            lblLiveTime.BackColor = Color.Black;
            lblLiveTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            lblLiveTime.ForeColor = Color.WhiteSmoke;
            lblLiveTime.Location = new Point(144, 16);
            lblLiveTime.Name = "lblLiveTime";
            lblLiveTime.Size = new Size(94, 28);
            lblLiveTime.TabIndex = 0;
            lblLiveTime.Text = "00:00:00";
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
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DashboardForm";
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Sidebar.ResumeLayout(false);
            blackPanel.ResumeLayout(false);
            blackPanel.PerformLayout();
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
        private Label lblLiveDate;
        private Label lblLiveTime;
        private System.Windows.Forms.Timer timerClock;
        private Panel blackPanel;
        private Panel barrierBotomPanel;
        private Panel barrierTopPanel;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
    }
}