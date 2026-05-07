namespace HairSalonApp
{
    partial class EmployeeForm
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
            btnSave = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            txtSpecialty = new TextBox();
            txtFirstName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
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
            btnSave.Location = new Point(180, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(175, 50);
            btnSave.TabIndex = 16;
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
            btnCancel.Location = new Point(365, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 50);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Ακύρωση";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button4);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 315);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 50);
            panel1.TabIndex = 18;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = Color.Green;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(699, -100);
            button1.Name = "button1";
            button1.Size = new Size(175, 50);
            button1.TabIndex = 10;
            button1.Text = "Αποθήκευση";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom;
            button2.BackColor = Color.Green;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(439, -50);
            button2.Name = "button2";
            button2.Size = new Size(175, 50);
            button2.TabIndex = 11;
            button2.Text = "Αποθήκευση";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom;
            button3.BackColor = Color.DarkRed;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            button3.ForeColor = Color.WhiteSmoke;
            button3.Location = new Point(624, -50);
            button3.Name = "button3";
            button3.Size = new Size(175, 50);
            button3.TabIndex = 12;
            button3.Text = "Ακύρωση";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom;
            button4.BackColor = Color.DarkRed;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            button4.ForeColor = Color.WhiteSmoke;
            button4.Location = new Point(884, -100);
            button4.Name = "button4";
            button4.Size = new Size(175, 50);
            button4.TabIndex = 11;
            button4.Text = "Ακύρωση";
            button4.UseVisualStyleBackColor = false;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtLastName.Location = new Point(363, 106);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 34);
            txtLastName.TabIndex = 31;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtPhone.Location = new Point(363, 146);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 34);
            txtPhone.TabIndex = 30;
            // 
            // txtSpecialty
            // 
            txtSpecialty.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtSpecialty.Location = new Point(363, 186);
            txtSpecialty.Name = "txtSpecialty";
            txtSpecialty.Size = new Size(125, 34);
            txtSpecialty.TabIndex = 29;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtFirstName.Location = new Point(363, 66);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 34);
            txtFirstName.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label5.Location = new Point(233, 109);
            label5.Name = "label5";
            label5.Size = new Size(107, 28);
            label5.TabIndex = 27;
            label5.Text = "Επώνυμο:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label4.Location = new Point(233, 149);
            label4.Name = "label4";
            label4.Size = new Size(115, 28);
            label4.TabIndex = 26;
            label4.Text = "Τηλέφωνο:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label3.Location = new Point(233, 189);
            label3.Name = "label3";
            label3.Size = new Size(124, 28);
            label3.TabIndex = 25;
            label3.Text = "Ειδικότητα:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label1.Location = new Point(233, 69);
            label1.Name = "label1";
            label1.Size = new Size(83, 28);
            label1.TabIndex = 24;
            label1.Text = "Όνομα:";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(720, 365);
            Controls.Add(txtLastName);
            Controls.Add(txtPhone);
            Controls.Add(txtSpecialty);
            Controls.Add(txtFirstName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Δημιουργία Νέου Υπαλλήλου";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtSpecialty;
        private TextBox txtFirstName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
    }
}