namespace HairSalonApp
{
    partial class NewAppointmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAppointmentForm));
            label1 = new Label();
            cmbCustomer = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            cmbService = new ComboBox();
            cmbEmployee = new ComboBox();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtTime = new TextBox();
            label5 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label1.Location = new Point(222, 20);
            label1.Name = "label1";
            label1.Size = new Size(98, 28);
            label1.TabIndex = 0;
            label1.Text = "Πελάτης:";
            // 
            // cmbCustomer
            // 
            cmbCustomer.Cursor = Cursors.Hand;
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(347, 20);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(151, 28);
            cmbCustomer.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label2.Location = new Point(222, 65);
            label2.Name = "label2";
            label2.Size = new Size(108, 28);
            label2.TabIndex = 2;
            label2.Text = "Υπηρεσία:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label3.Location = new Point(222, 111);
            label3.Name = "label3";
            label3.Size = new Size(123, 28);
            label3.TabIndex = 3;
            label3.Text = "Υπάλληλος:";
            // 
            // cmbService
            // 
            cmbService.Cursor = Cursors.Hand;
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(347, 65);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(151, 28);
            cmbService.TabIndex = 4;
            // 
            // cmbEmployee
            // 
            cmbEmployee.Cursor = Cursors.Hand;
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(347, 111);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(151, 28);
            cmbEmployee.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label4.Location = new Point(222, 191);
            label4.Name = "label4";
            label4.Size = new Size(134, 28);
            label4.TabIndex = 6;
            label4.Text = "Ημερομηνία:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Cursor = Cursors.Hand;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(380, 191);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(121, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // txtTime
            // 
            txtTime.Cursor = Cursors.IBeam;
            txtTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtTime.Location = new Point(376, 224);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(125, 34);
            txtTime.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label5.Location = new Point(222, 230);
            label5.Name = "label5";
            label5.Size = new Size(59, 28);
            label5.TabIndex = 9;
            label5.Text = "Ώρα:";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.BackColor = Color.Green;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnSave.ForeColor = Color.WhiteSmoke;
            btnSave.Location = new Point(179, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(175, 50);
            btnSave.TabIndex = 10;
            btnSave.Text = "Αποθήκευση";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            btnCancel.ForeColor = Color.WhiteSmoke;
            btnCancel.Location = new Point(364, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 50);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Ακύρωση";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 315);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 50);
            panel1.TabIndex = 12;
            // 
            // NewAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(720, 365);
            Controls.Add(label5);
            Controls.Add(txtTime);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(cmbEmployee);
            Controls.Add(cmbService);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbCustomer);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewAppointmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Δημιουργία Νέου Ραντεβού";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCustomer;
        private Label label2;
        private Label label3;
        private ComboBox cmbService;
        private ComboBox cmbEmployee;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private TextBox txtTime;
        private Label label5;
        private Button btnSave;
        private Button btnCancel;
        private Panel panel1;
    }
}