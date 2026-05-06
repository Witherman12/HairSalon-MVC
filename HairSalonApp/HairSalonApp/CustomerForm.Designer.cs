namespace HairSalonApp
{
    partial class CustomerForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtFirstName = new TextBox();
            txtNotes = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtLastName = new TextBox();
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
            btnSave.Location = new Point(179, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(175, 50);
            btnSave.TabIndex = 11;
            btnSave.Text = "Αποθήκευση";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
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
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Ακύρωση";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 315);
            panel1.Name = "panel1";
            panel1.Size = new Size(720, 50);
            panel1.TabIndex = 13;
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
            button1.Location = new Point(439, -50);
            button1.Name = "button1";
            button1.Size = new Size(175, 50);
            button1.TabIndex = 10;
            button1.Text = "Αποθήκευση";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom;
            button2.BackColor = Color.DarkRed;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(624, -50);
            button2.Name = "button2";
            button2.Size = new Size(175, 50);
            button2.TabIndex = 11;
            button2.Text = "Ακύρωση";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label1.Location = new Point(167, 50);
            label1.Name = "label1";
            label1.Size = new Size(83, 28);
            label1.TabIndex = 14;
            label1.Text = "Όνομα:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label2.Location = new Point(167, 210);
            label2.Name = "label2";
            label2.Size = new Size(124, 28);
            label2.TabIndex = 15;
            label2.Text = "Σημειώσεις:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label3.Location = new Point(167, 170);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 16;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label4.Location = new Point(167, 130);
            label4.Name = "label4";
            label4.Size = new Size(115, 28);
            label4.TabIndex = 17;
            label4.Text = "Τηλέφωνο:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            label5.Location = new Point(167, 90);
            label5.Name = "label5";
            label5.Size = new Size(107, 28);
            label5.TabIndex = 18;
            label5.Text = "Επώνυμο:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtFirstName.Location = new Point(297, 47);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 34);
            txtFirstName.TabIndex = 19;
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtNotes.Location = new Point(297, 207);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(250, 34);
            txtNotes.TabIndex = 20;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtEmail.Location = new Point(297, 167);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 34);
            txtEmail.TabIndex = 21;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtPhone.Location = new Point(297, 127);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 34);
            txtPhone.TabIndex = 22;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            txtLastName.Location = new Point(297, 87);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 34);
            txtLastName.TabIndex = 23;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(720, 365);
            Controls.Add(txtLastName);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtNotes);
            Controls.Add(txtFirstName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Δημιουργία Νέου Πελάτη";
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtFirstName;
        private TextBox txtNotes;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtLastName;
    }
}